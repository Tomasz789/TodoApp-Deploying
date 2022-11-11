using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.WeatherApiHelper.Services
{
    public sealed class WeatherApiService
    {
        private const string _ipApiUri = "https://api.ipify.org";
        private readonly HttpClient _client;

        public WeatherApiService()
        {
            _client = new HttpClient();
        }

        public async Task<string> GetUserIpAsync()
        {
            string _userIp = string.Empty;

            try
            {
                _userIp = await _client.GetStringAsync(_ipApiUri);
            }
            catch
            {
                return string.Empty;
            }

            return _userIp;
        }
    }
}
