using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TodoApp.WeatherApiHelper.Configs;
using TodoApp.WeatherApiHelper.Models.GoogleCaptcha;

namespace TodoApp.WeatherApiHelper.Services
{
    public sealed class GoogleCaptchaApiHelper : HttpApiHelper<GoogleCaptchaResponse>
    {
        private readonly IConfig _config;
        public GoogleCaptchaApiHelper(HttpClient client, IConfig captchaConfig) : base(client)
        {
            client.BaseAddress = new Uri("https://www.google.com/recaptcha/api/siteverify");
            
            _config = captchaConfig;
        }

        public string CaptchaToken { get; set; }
        /// <summary>
        /// Post the captcha and get response.
        /// </summary>
        /// <returns>GoogleCaptchaResponse that represents response from the captcha. Otherwise null.</returns>
        public override async Task<GoogleCaptchaResponse> GetResponseAsync()
        {
            var requestParams = new Dictionary<string, string>()
            {
                { "secret", _config.SecretKey },
                {"response", CaptchaToken }
            };

            FormUrlEncodedContent httpContent = new FormUrlEncodedContent(requestParams);

            try
            {
                using (var sentRequest = await _client.PostAsync(_client.BaseAddress, httpContent))
                {
                    var code = sentRequest.EnsureSuccessStatusCode();

                    if (code.StatusCode != System.Net.HttpStatusCode.OK)
                    {
                        return null;
                    }
                    var res = await sentRequest.Content.ReadAsStringAsync();
                    var deserializedRes = JsonConvert.DeserializeObject<GoogleCaptchaResponse>(res);
                    return deserializedRes;
                }
            }
            catch
            {
                return null;
            }
            
        }
    }
}
