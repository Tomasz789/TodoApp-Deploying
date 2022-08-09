using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using Todo.Domain.Entities;
using TodoApp.DAL.Wrappers;
using ToDoList.WebApp.Models.ViewModels;
using ToDoList.WebApp.Models.ViewModels.TaskViewModels;

namespace ToDoList.WebApp.Controllers
{
    public class TaskController : Controller
    {
        private readonly IRepositoryWrapper repository;

        public TaskController(IRepositoryWrapper repository)
        {
            this.repository = repository;
        }
        public IActionResult Index(SortTasksViewModel vm, int? listId)
        {
            var tasks = this.repository.TodoTaskRepository.GetAll().Include(y => y.TodoList).Where(x => x.TaskListId == listId);
            return View(tasks);
        }

        public IActionResult Search(SortTasksViewModel vm)
        {
            var tasks = this.repository.TodoTaskRepository.GetAll().Include(y => y.TodoList)
                .Select(x => x).Where(x => x.CreatedDate >= vm.CreatedDateFrom && x.CreatedDate <= vm.CreatedDateTo)
                                .Where(y => y.EndDate > vm.EndDateFrom && y.EndDate <= vm.EndDateTo)
                                .Where(a => a.Status.Equals(vm.Status))
                                .Where(b => b.Priority.Equals(vm.Priority));

            return View("TaskTableSummary", tasks);

        }
        public IActionResult Create(int? id)
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }

        public IActionResult Detail(int? id)
        {
            var model = repository.TodoTaskRepository.GetAll()
                .Include(y => y.TodoList)
                .Select(x => x)
                .FirstOrDefault(x => x.Id == id);
            return View(model);
        }
        public IActionResult Delete(int? id)
        {
            var itemToRemove = repository.TodoTaskRepository.GetOneByCondition(x => x.Id == id);
            return View(itemToRemove);
        }

        [HttpPost]
        public IActionResult Create(int? id, CreateTaskViewModel vm)
        {
           
            var taskList = repository.TodoListRepository.GetAll().Include(x => x.Tasks).FirstOrDefault(y => y.Id == id);
            var task = new TodoTask(vm.Title, vm.Description, vm.EndDate, vm.StatusList);
            task.TaskListId = (int)id;
            task.Priority = vm.PriorityList;
            this.repository.TodoTaskRepository.Create(task);
            taskList.AddTaskToList(task);
            this.repository.Save();

            return RedirectToAction("Index", "List");
        }

        [HttpPost]
        public IActionResult Edit(int? id, UpdateTaskViewModel vm)
        {

            var taskToUpdate = repository.TodoTaskRepository.GetOneByCondition(x => x.Id == id);
            taskToUpdate.SetTaskTitle(vm.Title);
            taskToUpdate.Description = vm.Description;
            taskToUpdate.SetEndDate(vm.EndDate);
            taskToUpdate.Priority = vm.PriorityList;
            taskToUpdate.Status = vm.StatusList;

            repository.TodoTaskRepository.Update(taskToUpdate);
            repository.Save();
            var listToRouteId = repository.TodoTaskRepository.GetAll().Where(x => x.Id == id).Select(x => x.TodoList).First();

            return RedirectToAction("Details", "List", listToRouteId);

        }

        [HttpPost]
        public IActionResult RemoveConfirmation(int? id)
        {
            var taskToRemove = repository.TodoTaskRepository.GetOneByCondition(x => x.Id == id);
            if (taskToRemove != null)
            {
                var listToRouteId = repository.TodoTaskRepository.GetAll().Where(x => x.Id == id).Select(x => x.TodoList).First();

                repository.TodoTaskRepository.Delete(taskToRemove);
                repository.Save();
                return RedirectToAction("Details", "List", listToRouteId);

            }

            return RedirectToAction("Delete", id);
        }

        public IActionResult Complete(int? id)
        {
            var taskToComplete = repository.TodoTaskRepository.GetAll().Include(y => y.TodoList).FirstOrDefault(x => x.Id==id); 

            taskToComplete.Status = Todo.Domain.Entities.TodoTaskStatus.TaskStatus.Completed;

            repository.TodoTaskRepository.Update(taskToComplete);
            repository.Save();

            return RedirectToAction("Index", "List");
        }
    }
}
