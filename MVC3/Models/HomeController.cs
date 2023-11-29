using Microsoft.AspNetCore.Mvc;

namespace MVC3.Models
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
