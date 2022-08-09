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
using ToDoList.WebApp.Models;

namespace ToDoList.WebApp.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositoryWrapper repository;

        public HomeController(IRepositoryWrapper repository, ILogger<HomeController> logger)
        {
            this.repository = repository;
            _logger = logger;

        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var lists = repository.TodoListRepository.GetAll()
                        .Include(y => y.Tasks)
                        .Select(x => x.Tasks.Where(y => y.EndDate.Day == DateTime.Today.Day
                         && y.Priority.Equals(Priority.HIGH) && y.Status != Todo.Domain.Entities.TodoTaskStatus.TaskStatus.Completed)).SelectMany(y => y.Select(k => k.TodoList));
                                    
          return View(lists.AsEnumerable());
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
