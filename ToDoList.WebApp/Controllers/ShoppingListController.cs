using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using Todo.Domain.Entities;
using TodoApp.DAL.Wrappers;
using ToDoList.WebApp.Models.ViewModels;

namespace ToDoList.WebApp.Controllers
{
    public class ShoppingListController : Controller
    {
        private readonly IRepositoryWrapper repo;
        public ShoppingListController(IRepositoryWrapper repository)
        {
            repo = repository;
        }
        public IActionResult Index()
        {
            var shoppinglists = repo.ShoppingListRepository.GetAll();
            return View(shoppinglists);
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateShoppingListViewModel vm)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            if (ModelState.IsValid)
            {
                var shoppingList = new ShoppingList()
                {
                    Title = vm.Title,
                    Description = vm.Description,
                    UserId = userId,
                    DueDate = vm.DueDate,
                };

                repo.ShoppingListRepository.Create(shoppingList);
                repo.Save();
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(UpdateShoppingListViewModel vm, int? id)
        {
            var shoppingListToUpdate = repo.ShoppingListRepository.GetOneByCondition(x => x.Id == id);

            if (ModelState.IsValid)
            {
                shoppingListToUpdate.Title = vm.Title;
                shoppingListToUpdate.Description = vm.Description;
                shoppingListToUpdate.DueDate = vm.DueDate;
            }

            return RedirectToAction("Index");
        }
    }
}
