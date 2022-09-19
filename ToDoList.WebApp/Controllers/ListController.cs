using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        public ListController(IRepositoryWrapper repository, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            this.repository = repository;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        //GET:
        [Authorize]
        public ViewResult Index(SortListViewModel vm, int page = 1, int itemsPerPage = 10, string sortOrder = "asc", string SearchString = "")
        {
            ViewBag.CreatedDateSortParam = string.IsNullOrEmpty(sortOrder) ? "asc" : "desc";
            ViewBag.UpdatedDateSortParam = string.IsNullOrEmpty(sortOrder) ? "updated_asc" : "updated_desc";
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var lists = repository.TodoListRepository.GetByCondition(u => u.UserId == userId).Include(y => y.Tasks).Skip((page - 1) * itemsPerPage).Take(itemsPerPage);
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

        public IActionResult Stats(int? listId)
        {
            var tasks = repository.TodoTaskRepository.GetAll();
            var lists = repository.TodoListRepository.GetAll();
            var selected = new List<SelectListItem>();
            
            foreach (var list in lists)
            {
                selected.Add(new SelectListItem() { Text = list.Title, Value = list.Id.ToString() });
            }
            ViewBag.UserLists = selected;
            return View(new TaskStatsViewModel()
            {
                TasksCount = tasks.Count(),
                TasksDoneCount = tasks.Where(x => x.Status.Equals(Todo.Domain.Entities.TodoTaskStatus.TaskStatus.Completed)).Count(),
                TasksInProgressCount = tasks.Where(x => x.Status.Equals(Todo.Domain.Entities.TodoTaskStatus.TaskStatus.InProgress)).Count(),
                TasksNotStarted = tasks.Where(x => x.Status.Equals(Todo.Domain.Entities.TodoTaskStatus.TaskStatus.NotStarted)).Count(),
                TaskDoneInCurrentList = repository.TodoListRepository.GetAll().Include(x => x.Tasks).Where(l => l.Id == listId).Count()
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
        [Authorize]
        public IActionResult Create(CreateTaskListViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            var listUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var list = new TodoList()
            {
                Title = vm.Title,
                Description = vm.Description,
                UserId = listUserId,
            };
            this.repository.TodoListRepository.Create(list);
            this.repository.Save();
            return  RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(int? id, UpdateTaskListViewModel vm)
        {
            var listToUpdate = repository.TodoListRepository.GetOneByCondition(x => x.Id == id);
            listToUpdate.Description = vm.Description;
            listToUpdate.Title = vm.Title;
            
            repository.TodoListRepository.Update(listToUpdate);
            repository.Save();
            return RedirectToAction("Index");
        }

        [HttpPost]

        public IActionResult Stats(TodoListStatsViewModel vm)
        {
            //var list = vm.CurrentTaskId;
            var x = ViewBag.UserLists;
            var list = repository.TodoListRepository.GetOneByCondition(x => x.Id == vm.Id);
            var tasks = repository.TodoTaskRepository.GetAll();

            return View(new TaskStatsViewModel()
            {
                TasksCount = tasks.Count(),
                TasksDoneCount = tasks.Where(x => x.Status.Equals(Todo.Domain.Entities.TodoTaskStatus.TaskStatus.Completed)).Count(),
                TasksInProgressCount = tasks.Where(x => x.Status.Equals(Todo.Domain.Entities.TodoTaskStatus.TaskStatus.InProgress)).Count(),
                TasksNotStarted = tasks.Where(x => x.Status.Equals(Todo.Domain.Entities.TodoTaskStatus.TaskStatus.NotStarted)).Count(),
               // TaskDoneInCurrentList = list.Tasks.Where(x => x.Status.Equals(Todo.Domain.Entities.TodoTaskStatus.TaskStatus.Completed)).Count(),
            });

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
