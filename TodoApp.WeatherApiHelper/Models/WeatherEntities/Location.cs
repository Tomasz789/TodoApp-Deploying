using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.WeatherApiHelper.Models.WeatherEntities
{
    public class Location
    {
        public string Name { get; set; }

        public string Region { get; set; }

        public float Lat { get; set; }

        public float Lon { get; set; }

        public string Tz_Id { get; set; }

        public long LocalTimeEpoch { get; set; }

        public DateTime LocalTime { get; set; }
    }
}
