using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using TodoApp.DAL.Wrappers;
using ToDoList.WebApp.Models;
using ToDoList.WebApp.Models.AppUserViewModels;
using ToDoList.WebApp.Models.ViewModels;

namespace ToDoList.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;
        private readonly IHostingEnvironment hostingEnv;

        public AccountController(IRepositoryWrapper wrapper, IHostingEnvironment env, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            repositoryWrapper = wrapper;
            hostingEnv = env;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public IActionResult ChangeUserNameAsync()
        {
            return RedirectToAction("Edit");
        }

        [Authorize]
        [HttpPost]
        public async Task ChangeUserNameAsync(UserCredentialsViewModel vm)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await userManager.FindByIdAsync(userId);

            if (user.UserName == vm.UserName)
            {
                TempData["ErrorMsg"] = "User name must be different.";
            }

            if (ModelState.IsValid)
            {
                user.UserName = vm.UserName;
                await signInManager.UserManager.UpdateAsync(user);
            }

//            return RedirectToAction("Edit");
        }

        [Authorize]

        public async Task<IActionResult> ChangeUserPassword(UserCredentialsViewModel vm)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var user = await userManager.FindByIdAsync(userId);

            if (ModelState.IsValid)
            {
                var passwordToken = await userManager.GeneratePasswordResetTokenAsync(user);
                var passwordResult = await userManager.ResetPasswordAsync(user, passwordToken, vm.Password);

                if (passwordResult.Succeeded)
                {
                    await signInManager.UserManager.UpdateAsync(user);
                }
            }

            return RedirectToAction("Edit");
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterAccountViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser() { UserName = vm.UserName, Email = vm.Email};
              
                var result = await userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(vm);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var res = await signInManager.PasswordSignInAsync(vm.UserName, vm.Password, vm.RememberUser, false); 
                if (res.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            ModelState.AddModelError(string.Empty, "Login failed");
            return View(vm);
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Login(string returnUrl)
        {
            var loginModel = new LoginViewModel()
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync())
                                        .ToList(),
            };

            return View(loginModel);
        }

        [AllowAnonymous]
        [HttpPost]

        public IActionResult LoginByExternalProvider(string returnUrl, string provider)
        {
            var redirectUrl = Url.Action("ExternalLoginCallback", "Account",
                               new { ReturnUrl = returnUrl });
            var prop = signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return new ChallengeResult(provider, prop);
        }

        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginCallback(string returnUrl = null, string remoteError = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            var loginModel = new LoginViewModel()
            {
                ReturnUrl = returnUrl,
                ExternalLogins = (await signInManager.GetExternalAuthenticationSchemesAsync()).ToList(),
            };

            if (remoteError != null)
            {
                ModelState.AddModelError(string.Empty, $"An error occured from {remoteError}");
                return View("Login", loginModel);
            }

            var signInInfo = await signInManager.GetExternalLoginInfoAsync();

            if (signInInfo == null)
            {
                ModelState.AddModelError(string.Empty, "Cannot obtain login information");
                return View("Login", loginModel);
            }

            var signInRes = await signInManager.ExternalLoginSignInAsync(signInInfo.LoginProvider, signInInfo.ProviderKey, false, true);    // sign user

            if (signInRes.Succeeded)
            {
                return LocalRedirect(returnUrl);
            }
            else
            {
                var userEmail = signInInfo.Principal.FindFirstValue(ClaimTypes.Email);  // get user email

                if (userEmail != null)
                {
                    var user = await userManager.FindByEmailAsync(userEmail);  // find user and check if exists

                    // add when user doesn't exist
                    if (user == null)
                    {
                        user = new AppUser()
                        {
                            Email = signInInfo.Principal.FindFirstValue(ClaimTypes.Email),
                            UserName = signInInfo.Principal.FindFirstValue(ClaimTypes.Email)
                        };

                        await userManager.CreateAsync(user);        // add new user by Google email

                    }

                    await userManager.AddLoginAsync(user, signInInfo);
                    await signInManager.SignInAsync(user, isPersistent: false);

                    return LocalRedirect(returnUrl);
                }
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Edit(AppUserViewModel vm)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);

            if (ModelState.IsValid)
            {
                user.FirstName = vm.FirstName;
                user.LastName = vm.LastName;
                user.City = vm.City;
                user.Country = vm.Country;
                user.BirthDate = vm.BirthDate;
                
                await userManager.UpdateAsync(user);
                return View();
            }

            return RedirectToAction("Edit");
        }

        [HttpPost]
        public async Task<IActionResult> UploadUserImage(AppUserViewModel vm)
        {
            if (vm.Photo == null)
            {
                return RedirectToAction("Edit");
            }

            string uniquePath = null;

            var imgUploadPath = Path.Combine(hostingEnv.WebRootPath, "appimg");
            uniquePath = $"{Guid.NewGuid()}_{vm.Photo.FileName}";
            string filePath = Path.Combine(imgUploadPath,uniquePath);
            vm.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);

            user.PhotoPath = uniquePath;
            await userManager.UpdateAsync(user);

            return View();
        }
        //-----------invoking partial views------------------
        public async Task<IActionResult> GetPersonalDataPartialView()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var user = await userManager.FindByIdAsync(userId);

            var vm = new AppUserViewModel()
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Country = user.Country,
                City = user.City,
                BirthDate = user.BirthDate,
            };

            return PartialView("PersonalDataEditPage", vm);
        }

        public IActionResult GetAccountCredentialPartialView()
        {
            return PartialView("AccountCredentialsPage", new UserCredentialsViewModel());
        }

        public IActionResult GetAccountDetailsPartialView()
        {
            return PartialView("AccountDetailsPartialView", new AppUser());
        }
    }
}
