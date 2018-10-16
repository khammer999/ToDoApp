using Microsoft.AspNetCore.Mvc;

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
    }
}