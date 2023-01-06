using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
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

        public AccountController(IRepositoryWrapper wrapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            repositoryWrapper = wrapper;
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
            return View();
        }

        [Authorize]

        public async Task<IActionResult> ChangeUserNameAsync(UserCredentialsViewModel vm)
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
                //var passwordToken = await userManager.GeneratePasswordResetTokenAsync(user);
               // var passwordResult = await userManager.ResetPasswordAsync(user, passwordToken, vm.Password);
                await signInManager.UserManager.UpdateAsync(user);
            }

            return View();
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
                    if (user != null)
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

        public IActionResult GetPersonalDataPartialView()
        {
            return PartialView("PersonalDataEditPage", new AppUserViewModel());
        }

        public IActionResult GetAccountCredentialPartialView()
        {
            return PartialView("AccountCredentialsPage", new UserCredentialsViewModel());
        }

        public IActionResult GetAccountDetailsPartialView()
        {
            return PartialView("GetAccountDetailsPartialView", new AppUser());
        }
    }
}
