using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Text;
using TodoApp.WeatherApiHelper.Models.GoogleCaptcha;

namespace TodoApp.WeatherApiHelper.Configs
{
    public interface IConfig
    {
        public string SiteKey { get; }

        public string SecretKey { get; }
        public IConfiguration Config { get; }
    }
}
