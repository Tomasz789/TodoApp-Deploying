using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Todo.Domain.Entities;
using TodoApp.DAL.Wrappers;
using ToDoList.WebApp.Models.Paging;
using ToDoList.WebApp.Models.ViewModels;
using ToDoList.WebApp.Models.ViewModels.PagingVM;
using ToDoList.WebApp.Models.ViewModels.Sort;

namespace ToDoList.WebApp.Controllers
{
    [Authorize]
    public class ListController : Controller
    {
        private readonly IRepositoryWrapper repository;
        private readonly SignInManager<Microsoft.AspNetCore.Identity.IdentityUser> signInManager;
        private readonly UserManager<Microsoft.AspNetCore.Identity.IdentityUser> userManager;
        public ListController(IRepositoryWrapper repository, UserManager<Microsoft.AspNetCore.Identity.IdentityUser> userManager, SignInManager<Microsoft.AspNetCore.Identity.IdentityUser> signInManager)
        {
            this.repository = repository;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        //GET:
        public ViewResult Index(SortListViewModel vm, int page = 1, int itemsPerPage = 5, string sortOrder = "asc", string SearchString = "")
        {
            ViewBag.CreatedDateSortParam = string.IsNullOrEmpty(sortOrder) ? "asc" : "desc";
            ViewBag.UpdatedDateSortParam = string.IsNullOrEmpty(sortOrder) ? "updated_asc" : "updated_desc";
            var lists = repository.TodoListRepository.GetAll().Include(y => y.Tasks).Skip((page - 1) * itemsPerPage).Take(itemsPerPage);
            lists = lists.Where(x => x.CreatedDate >= vm.CreatedDateMin && x.CreatedDate <= vm.CreatedDateMax);

            if (!string.IsNullOrEmpty(SearchString))
            {
                lists = lists.Where(x => x.Title.Contains(SearchString.ToLowerInvariant()));
            }

            switch (sortOrder)
            {
                case "asc":
                    {
                        lists = lists.OrderBy(x => x.CreatedDate);
                    }
                    break;
                case "desc":
                    {
                        lists = lists.OrderByDescending(x => x.CreatedDate);
                    }
                    break;
                case "updated_asc":
                    {
                        lists = lists.OrderBy(x => x.Updated);
                    }
                    break;
                case "updated_desc":
                    {
                        lists = lists.OrderByDescending(x => x.Updated);
                    }
                    break;
                default:
                    {
                        lists = lists.OrderBy(x => x.Id);
                    }
                    break;
            }


            return View(new TaskListsPagingViewModel()
            {
                Lists = lists,
                PagingInfo = new PagingInfo() { CurrentPage = page, TotalItems = lists.Count(), ItemsPerPage = itemsPerPage }
            });
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Delete(int? id)
        {
            var listToDelete = repository.TodoListRepository.GetOneByCondition(x => x.Id == id);
            return View(listToDelete);
        }

        public IActionResult Details(int? id)
        {
            var listToView = repository.TodoListRepository.GetAll().Include(y => y.Tasks).FirstOrDefault(x => x.Id == id);
            return View(listToView);
        }

        // POST:
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateTaskListViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var list = new TodoList(vm.Title, vm.Description);
            this.repository.TodoListRepository.Create(list);
            this.repository.Save();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(int? id, UpdateTaskListViewModel vm)
        {
            var listToUpdate = repository.TodoListRepository.GetOneByCondition(x => x.Id == id);
            listToUpdate.SetDescription(vm.Description);
            listToUpdate.SetTitle(vm.Title);

            repository.TodoListRepository.Update(listToUpdate);
            repository.Save();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult RemoveConfirmation(int? id)
        {
            var listToDelete = repository.TodoListRepository.GetOneByCondition(x => x.Id == id);

            if (listToDelete != null)
            {
                var tasks = repository.TodoTaskRepository.GetAll().Where(y => y.TaskListId == id);

                if (tasks.Any())
                {
                    foreach (var task in tasks)
                    {
                        repository.TodoTaskRepository.Delete(task);
                    }
                }

                repository.TodoListRepository.Delete(listToDelete);
                repository.Save();
                return RedirectToAction("Index");
            }

            return RedirectToAction("Delete");
        }
    }
}
