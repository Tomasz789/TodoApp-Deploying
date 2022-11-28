using System.Collections;
using System.Collections.Generic;
using Todo.Domain.Entities;
using TodoApp.WeatherApiHelper.Models;

namespace ToDoList.WebApp.Models.Home
{
    public class HomePageViewModel
    {
        public IEnumerable<TodoList> Lists { get; set; }

        public DailyWeatherViewModel Weather { get; set; }
    }
}
