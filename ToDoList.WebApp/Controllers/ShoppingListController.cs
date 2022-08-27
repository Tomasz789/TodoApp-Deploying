using Microsoft.AspNetCore.Mvc;

namespace ToDoList.WebApp.Controllers
{
    public class ShoppingListController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
