using System;
using System.Collections.Generic;
using System.Text;

namespace TodoApp.WeatherApiHelper.Models.WeatherEntities
{
    public class Current
    {
        public long Last_Updated_Epoch { get; set; }

        public DateTime Last_Updated { get; set;}

        public float Temp_C { get; set; }

        public float Temp_F { get; set; }

        public int Is_Day { get; set; }

        public Condition Condition { get; set; }

        public float Wind_Mph { get; set; }

        public float Wind_Kph { get; set; }

        public float Wind_Degree { get; set; }

        public string Wind_Dir { get; set; }

        public float Pressure_Mb { get; set; }

        public float Pressure_In { get; set; }

        public float Precip_Mm { get; set; }

        public float Precip_In { get; set; }

        public int Humidity { get; set; }

        public int Cloud { get; set; }

        public float Feelslike_C { get; set; }

        public float Feelslike_F { get; set; }

        public float Vis_Km { get; set; }

        public float Vis_Miles { get; set; }

        public float Uv { get; set; }

        public float Gust_Mph { get; set; }

        public float Gust_Kph { get; set; }
    }
}
