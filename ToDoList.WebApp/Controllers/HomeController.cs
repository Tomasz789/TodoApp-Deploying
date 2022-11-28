using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using Todo.Domain.Entities.TodoTaskStatus;
using TodoApp.DAL.Wrappers;
using TodoApp.WeatherApiHelper.Services;
using ToDoList.WebApp.Models;
using ToDoList.WebApp.Models.Home;

namespace ToDoList.WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositoryWrapper repository;
        private readonly WeatherApiHelper weatherApi;
        private readonly UserIpAddressApiHelper userIpAddressApiHelper;

        public HomeController(IRepositoryWrapper repository, ILogger<HomeController> logger, WeatherApiHelper weatherApi, UserIpAddressApiHelper userIpAddressApiHelper)
        {
            this.repository = repository;
            _logger = logger;
            this.userIpAddressApiHelper = userIpAddressApiHelper;
            this.weatherApi = weatherApi;

        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var lists = repository.TodoListRepository.GetAll()
                        .Include(y => y.Tasks)
                        .Select(x => x.Tasks.Where(y => y.EndDate.Day == DateTime.Today.Day
                         && y.Priority.Equals(Priority.HIGH) && y.Status != Todo.Domain.Entities.TodoTaskStatus.TaskStatus.Completed)).SelectMany(y => y.Select(k => k.TodoList));

            if (lists.Count() > 3)
            {
                lists = lists.Take(3);
            }

            var userLocation = await userIpAddressApiHelper.GetResponseAsync();
            weatherApi.UserCity = userLocation.City;
            var weatherModel = await weatherApi.GetResponseAsync();
            return View(new HomePageViewModel()
            {
                Lists = lists,
                Weather = new DailyWeatherViewModel()
                {
                    Temp_C = weatherModel.Current.Temp_C,
                    Cloud = weatherModel.Current.Cloud,
                    Temp_FeelsLike_C = weatherModel.Current.Feelslike_C,
                    Humidity = weatherModel.Current.Humidity,
                    Wind_Dir = weatherModel.Current.Wind_Dir,
                    Pressure_Mb = weatherModel.Current.Pressure_Mb,
                    Wind_Kph = weatherModel.Current.Wind_Kph,
                    Icon = weatherModel.Current.Condition.Icon
                }
            }); 
                                    
        }

        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
