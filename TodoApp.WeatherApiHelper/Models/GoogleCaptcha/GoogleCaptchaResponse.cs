using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.WeatherApiHelper.Models.GoogleCaptcha
{
    public class GoogleCaptchaResponse
    {
        public bool Success { get; set; }

        public DateTime Challenge_Ts { get; set; }

        public string HostName { get; set; }

        public string [] ErrorCodes { get; set; }
    }
}
