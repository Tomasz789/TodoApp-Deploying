using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.WeatherApiHelper.Models.WeatherEntities;

namespace TodoApp.WeatherApiHelper.Models
{
    public class UserWeatherModel
    {
        public Location Location { get; set; }

        public Current Current { get; set; }

    }
}
