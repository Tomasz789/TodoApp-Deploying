﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TodoApp.WeatherApiHelper.Models;

namespace TodoApp.WeatherApiHelper.Services
{
    public class WeatherApiHelper : HttpApiHelper<UserWeatherModel>
    {
        private string url;
        public WeatherApiHelper(HttpClient client) : base(client)
        {
            url = "https://weatherapi-com.p.rapidapi.com/current.json?q=" + this.UserCity;
            client.BaseAddress = new Uri(url);
        }

        public string UserCity { get; set; }
        public override async Task<UserWeatherModel> GetResponseAsync()
        {
            var userRequest = new HttpRequestMessage()
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri(url + this.UserCity),
                Headers =
                {
                    { "X-RapidAPI-Key", "31f4e162c5msh8bfe2ba75548632p156626jsna45e61ea834b" },
                    { "X-RapidAPI-Host", "weatherapi-com.p.rapidapi.com" }
                }
            };

            try
            {
                using (var response = await _client.SendAsync(userRequest))
                {
                    response.EnsureSuccessStatusCode();
                    var httpRes = await response.Content.ReadAsStringAsync();
                    var model = JsonConvert.DeserializeObject<UserWeatherModel>(httpRes);
                    return model;
                }
            }
            catch
            {
                return null;
            }
        }
    }
}

