using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Claims;
using Todo.Domain.Entities;
using TodoApp.DAL.Wrappers;
using ToDoList.WebApp.Models.ViewModels;

namespace ToDoList.WebApp.Controllers
{
    public class NoteController : Controller
    {
        private readonly IRepositoryWrapper _repo;
        public NoteController(IRepositoryWrapper repository)
        {
            _repo = repository;
        }

        [Authorize]
        public IActionResult Index()
        {
            var model = _repo.NoteRepository.GetAll();
            return View(model);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        public IActionResult Edit(int? id)
        {
            return View();
        }

        [Authorize]
        public IActionResult Delete(int? id)
        {
            var noteToDelete = _repo.NoteRepository.GetOneByCondition(x => x.Id == id);
            return View(noteToDelete);
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(CreateNoteViewModel vm)
        {
            var listUserId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var note = new Note()
            {
                Title = vm.Title,
                Text = vm.Text,
                UserId = listUserId
            };

            _repo.NoteRepository.Create(note);
            _repo.Save();

            return RedirectToAction("Index");
        }

        [HttpPost]
        [Authorize]

        public IActionResult Edit(int? id, UpdateNoteViewModel vm)
        {
            var modelToUpdate = _repo.NoteRepository.GetOneByCondition(x => x.Id == id);

            if (ModelState.IsValid)
            {
                modelToUpdate.Title = vm.Title;
                modelToUpdate.Text = vm.Text;
                _repo.NoteRepository.Update(modelToUpdate);
                _repo.Save();
            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        [Authorize]
        public IActionResult DeleteConfirmation(int? id)
        {
            var noteToDelete = _repo.NoteRepository.GetOneByCondition(x => x.Id == id);
            _repo.NoteRepository.Delete(noteToDelete);
            _repo.Save();
            return RedirectToAction("Index");
        }
    }
}
