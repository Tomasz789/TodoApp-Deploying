using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using TodoApp.EmailService.Services;
using TodoApp.WeatherApiHelper.Configs;
using TodoApp.WeatherApiHelper.Services;
using ToDoList.WebApp.Models.ViewModels;

namespace ToDoList.WebApp.Controllers
{
    public class ReportController : Controller
    {
        private readonly IEmailSender emailSender;
        private readonly GoogleCaptchaApiHelper captchaApi;
        private readonly IConfig captchaConfig;
        public ReportController(IEmailSender sender, IConfig captchaConfig ,GoogleCaptchaApiHelper captchaApiHelper)
        {
            emailSender = sender;
            captchaApi = captchaApiHelper;
            this.captchaConfig = captchaConfig;
        }

        [Authorize]
        [HttpGet]
        public IActionResult Send()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult EndPage(string msg = "Ok")
        {
            ViewBag.Message = msg;
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Send(ReportMessageViewModel vm)
        {
            string finalMsg = "Your email has been succesfully sent!";
            int mailRes = -1;
            var userMail = User.FindFirstValue(ClaimTypes.Email);
            captchaApi.CaptchaToken = vm.CaptchaToken;
            var res = captchaApi.GetResponseAsync().Result;

            if (res.Success && ModelState.IsValid)
            {
                 mailRes = emailSender.SendEmail(userMail, vm.Title, vm.Content);
            }

            if (mailRes == -1)
            {
                finalMsg = "Unable to send email!";
            }

            return RedirectToAction("EndPage", "Report", new { msg = finalMsg});
        }
    }
}
