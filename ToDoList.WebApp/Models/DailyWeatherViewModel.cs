namespace ToDoList.WebApp.Models
{
    public class DailyWeatherViewModel
    {
        public float Temp_C { get; set; }

        public float Temp_FeelsLike_C { get; set; }

        public float Wind_Kph { get; set; }

        public string Wind_Dir { get; set; }

        public float Pressure_Mb { get; set; }

        public int Humidity { get; set; }

        public int Cloud { get; set; }

        public string Icon { get; set; }
    }
}
