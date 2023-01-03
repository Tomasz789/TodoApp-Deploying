using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
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

        [Authorize]
        public IActionResult Index(SearchShoppingListViewModel vm, string shoppingListTitle = "")
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var shoppinglists = repo.ShoppingListRepository.GetByCondition(u => u.UserId == userId);
            shoppinglists = shoppinglists.Where(x => x.CreatedDate >= vm.CreatedDateFrom && x.CreatedDate <= vm.CreatedDateTo);
            shoppinglists = shoppinglists.Where(x => x.DueDate >= vm.DueDateFrom && x.DueDate <= vm.DueDateTo);

            if (!string.IsNullOrEmpty(shoppingListTitle))
            {
                shoppinglists = shoppinglists.Where(x => x.Title.Contains(shoppingListTitle));
            }


            switch (vm.OrderByCreatedDateType)
            {
                case "Ascending":
                    {
                        shoppinglists = shoppinglists.OrderBy(x => x.CreatedDate);
                    }
                    break;
                case "Descening":
                    {
                        shoppinglists.OrderByDescending(x => x.CreatedDate);
                    }
                    break;
            }

            switch (vm.OrderByDueDateType)
            {
                case "Ascending":
                    {
                        shoppinglists = shoppinglists.OrderBy(x => x.DueDate);
                    }
                    break;
                case "Descening":
                    {
                        shoppinglists.OrderByDescending(x => x.DueDate);
                    }
                    break;
            }
           
            return View(shoppinglists);
        }

        [Authorize]
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Edit()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public IActionResult Remove(int? id) 
        {
            var shoppingListToDelete = repo.ShoppingListRepository.GetOneByCondition(x => x.Id == id);

            return View(shoppingListToDelete); 
        }

        [Authorize]
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

        [Authorize]
        [HttpPost]
        public IActionResult Edit(int? id, UpdateShoppingListViewModel vm)
        {
            var shoppingListToUpdate = repo.ShoppingListRepository.GetOneByCondition(x => x.Id == id);

            if (ModelState.IsValid)
            {
                shoppingListToUpdate.Title = vm.Title;
                shoppingListToUpdate.Description = vm.Description;
                shoppingListToUpdate.DueDate = vm.DueDate;
                repo.Save();
            }

            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpPost]
        public IActionResult RemoveConfirmation(int? id)
        {
            var listToDelete = repo.ShoppingListRepository.GetOneByCondition(x => x.Id == id);

            if (listToDelete != null)
            {
                repo.ShoppingListRepository.Delete(listToDelete);
                repo.Save();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Delete");
        }
    }
}
