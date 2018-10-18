using System;
using Microsoft.AspNetCore.Mvc;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    public class HomeController: Controller
    {
        private IToDoRepository repo;

        public HomeController(IToDoRepository repo)
        {
            this.repo = repo;
        }

        public ViewResult Index()
        {

            var model = repo.GetAll();
            return View(model);

        }

        public ViewResult Details(int id)
        {
           var model =repo.GetById(id);
            return View(model);
        }

        public object Create()
        {
            return View();
        }

        [AcceptVerbs("POST")]
        public IActionResult Create(ToDo todo)
        {
            repo.Create(todo);

            return RedirectToAction("Index");
        }

        public ViewResult Delete(int id)
        {
            var model = repo.GetById(id);
            return View(model);
        }

        [AcceptVerbs("POST")]
        public IActionResult DeleteConfirmed(int id)
        {
            var todo = repo.GetById(id);
            repo.Delete(todo);
            return RedirectToAction("Index") ;
        }




    }
}