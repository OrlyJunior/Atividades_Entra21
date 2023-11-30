using Microsoft.AspNetCore.Mvc;
using MVC3.Models;

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

        public IActionResult Details(Models.Local local)
        {
            Models.Local loca = locais.FirstOrDefault(ct => ct.Id == local.Id);

            return View(loca);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Models.Local local = locais.FirstOrDefault(ct => ct.Id == id);

            return View(local);
        }

        [HttpPost]
        public IActionResult Edit(Models.Local loca)
        {
            Models.Local local = locais.FirstOrDefault(ct => ct.Id == loca.Id);

            local.Nome = loca.Nome;
            local.Rua = loca.Rua;
            local.Numero = loca.Numero;
            local.Bairro = loca.Bairro;
            local.Cidade = loca.Cidade;
            local.Estado = loca.Estado;
            local.Cep = loca.Cep;

            return RedirectToAction("Local");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Models.Local local = locais.FirstOrDefault(ct => ct.Id == id);

            return View(local);
        }

        public IActionResult Delete(Models.Local loca)
        {
            Models.Local local = locais.FirstOrDefault(ct => ct.Id == loca.Id);

            locais.Remove(local);

            return RedirectToAction("Local");
        }
    }
}
