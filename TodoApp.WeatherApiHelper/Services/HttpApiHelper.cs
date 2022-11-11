using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace TodoApp.WeatherApiHelper.Services
{
    public abstract class HttpApiHelper<T> where T : class
    {
        protected readonly HttpClient _client;

        public HttpApiHelper(HttpClient client)
        {
            _client = client;
            _client.Timeout = new TimeSpan(0, 0, 30);
            _client.DefaultRequestHeaders.Clear();
        }

        public abstract Task<T> GetResponseAsync();
    }
}
