using Microsoft.AspNetCore.Mvc;
using MVC2.Models;

namespace MVC2.Controllers
{
    public class DivController : Controller
    {
        public IActionResult Div()
        {
            List<Pessoa> pessoas = new();

            pessoas.Add(new Pessoa() { Id = 1, Nome = "Cléber", Email = "cleber@gmail.com" });
            pessoas.Add(new Pessoa() { Id = 2, Nome = "Ângela", Email = "angela@gmail.com" });
            pessoas.Add(new Pessoa() { Id = 3, Nome = "Marcos", Email = "marcos@gmail.com" });

            return View(pessoas);
        }
    }
}
