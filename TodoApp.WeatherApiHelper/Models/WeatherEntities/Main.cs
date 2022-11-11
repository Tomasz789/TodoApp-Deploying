using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.WeatherApiHelper.Models.WeatherEntities
{
    public class Main
    {
        public decimal Temp { get; set; }

        public decimal Feels_Like { get; set; }

        public decimal Temp_Min { get; set; }

        public decimal Temp_Max { get; set; }

        public int Pressure { get; set; }

        public int Humidity { get; set; }

    }
}
