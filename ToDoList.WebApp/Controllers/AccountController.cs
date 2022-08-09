﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TodoApp.DAL.Wrappers;
using ToDoList.WebApp.Models;
using ToDoList.WebApp.Models.ViewModels;

namespace ToDoList.WebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IRepositoryWrapper repositoryWrapper;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(IRepositoryWrapper wrapper, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            repositoryWrapper = wrapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register(RegisterAccountViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser() { UserName = vm.UserName, Email = vm.Email };
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

        [AllowAnonymous]
        public IActionResult Login()
        {
            return View();
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
    }
}
