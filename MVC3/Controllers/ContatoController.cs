using Microsoft.AspNetCore.Mvc;
using MVC3.Models;

namespace MVC3.Controllers
{
    public class ContatoController : Controller
    {
        static List<Models.Contato> contatos = new();
        public IActionResult Contato()
        {
            return View(contatos);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(MVC3.Models.Contato contato)
        {
            contato.Id = contatos.Count + 1;

            contatos.Add(contato);

            return RedirectToAction("Contato");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Models.Contato cont = contatos.FirstOrDefault(ct => ct.Id == id); 

            return View(cont);
        }

        [HttpPost]
        public IActionResult Edit(Models.Contato contato)
        {
            Models.Contato cont = contatos.FirstOrDefault(ct => ct.Id == contato.Id);
            cont.Name = contato.Name;
            cont.Email = contato.Email;
            cont.Fone = contato.Fone;

            return RedirectToAction("Contato");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Models.Contato cont = contatos.FirstOrDefault(ct => ct.Id == id);

            return View(cont);
        }

        [HttpPost]
        public IActionResult Delete(Models.Contato contato)
        {
            Models.Contato cont = contatos.FirstOrDefault(ct => ct.Id == contato.Id);

            contatos.Remove(cont);

            return RedirectToAction("Contato");
        }

        public IActionResult Details(Models.Contato cont)
        {
            Models.Contato contato = contatos.FirstOrDefault(ct => ct.Id == cont.Id);

            return View(contato);
        }
    }
}
