﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.WeatherApiHelper.Models.WeatherEntities
{
    public class Weather
    {

         public int Id { get; set; }

         public string Main { get; set; }

         public string Description { get; set; }

         public string Icon { get; set; }
    }
}
