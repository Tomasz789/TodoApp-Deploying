using System;
using System.Collections.Generic;
using System.Text;
using TodoApp.WeatherApiHelper.Models.WeatherEntities;

namespace TodoApp.WeatherApiHelper.Models
{
    public class UserWeatherModel
    {
        public Coord Coord { get; set; }

        public Weather [] Weather { get; set; }

        public string Base { get; set; }

        public Main Main { get; set; }

        public int Visibility { get; set; }
    }
}
