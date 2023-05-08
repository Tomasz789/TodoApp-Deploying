using Microsoft.Extensions.Configuration;

namespace TodoApp.WeatherApiHelper.Configs
{
    public class CaptchaConfig : IConfig
    {
        private readonly IConfiguration _config;

        public CaptchaConfig()
        {
            var builder = new ConfigurationBuilder().AddJsonFile(@"D:\Projekt\TodoApp-FinalVersion\TodoApp-Deploying\TodoApp.WeatherApiHelper\captchaconfig.json");
            _config = builder.Build();
        }

        public string SiteKey => _config["GoogleCaptcha:ClientKey"];

        public string SecretKey => _config["GoogleCaptcha:SecretKey"];
        public IConfiguration Config
        {
            get { return _config; }
        }
    }
}
