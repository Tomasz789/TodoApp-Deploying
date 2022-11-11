using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TodoApp.WeatherApiHelper.Models;

namespace TodoApp.WeatherApiHelper.Services
{
    public sealed class UserIpAddressApiHelper : HttpApiHelper<UserLocationModel>
    {
        private readonly WeatherApiService _ipServ;
        public UserIpAddressApiHelper(HttpClient client) : base(client)
        {
            client.BaseAddress = new Uri("http://ip-api.com/json/");
            _ipServ = new WeatherApiService();
        }

        public override async Task<UserLocationModel> GetResponseAsync()
        {
            string userIp;
          
            try
            {
                userIp = await _ipServ.GetUserIpAsync();

                if (string.IsNullOrEmpty(userIp))
                {
                    throw new InvalidOperationException(nameof(userIp));
                }

                string newPath = _client.BaseAddress.ToString() + userIp;
                var response = await _client.GetStringAsync(newPath);
                var deserializedRes = JsonConvert.DeserializeObject<UserLocationModel>(response.ToString());
                return deserializedRes;
            }
            catch
            {
                return null;
            }
        }
    }
}
