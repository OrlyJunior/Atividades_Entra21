using Microsoft.AspNetCore.Mvc;

namespace MVC3.Controllers
{
    public class LocalController : Controller
    {
        static List<Models.Local> locais = new();
        public IActionResult Local()
        {
            return View(locais);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Models.Local local)
        {
            local.Id = locais.Count + 1;

            locais.Add(local);

            return RedirectToAction("Local");
        }
    }
}
