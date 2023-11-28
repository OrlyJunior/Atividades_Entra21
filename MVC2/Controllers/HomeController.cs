using Microsoft.AspNetCore.Mvc;
using MVC2.Models;
using System.Diagnostics;

namespace MVC2.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Teste()
        {
            List<Pessoa> pessoas = new List<Pessoa>();

            pessoas.Add(new Pessoa() { Id=1, Nome="Cléber", Email="cleber@gmail.com"});
            pessoas.Add(new Pessoa() { Id = 2, Nome = "Ângela", Email = "angela@gmail.com" });
            pessoas.Add(new Pessoa() { Id = 3, Nome = "Marcos", Email = "marcos@gmail.com" });

            return View(pessoas);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}