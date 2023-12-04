using Microsoft.AspNetCore.Mvc;
using MVC3.Models;
using MVC3.Dao;
using MVC3.Dados;

namespace MVC3.Controllers
{
    public class ContatoController : Controller
    {
        DaoContato DaoC = new();

        public IActionResult Contato()
        {
            Dados.Dados.contatos = DaoC.consultar();

            return View(Dados.Dados.contatos);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Contato contato)
        {
            DaoC.salvar(contato);

            return RedirectToAction("Contato");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Models.Contato cont = Dados.Dados.contatos.FirstOrDefault(ct => ct.Id == id); 

            return View(cont);
        }

        [HttpPost]
        public IActionResult Edit(Contato contato)
        {
            DaoC.editar(contato);

            return RedirectToAction("Contato");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Models.Contato cont = Dados.Dados.contatos.FirstOrDefault(ct => ct.Id == id);

            return View(cont);
        }

        [HttpPost]
        public IActionResult Delete(Models.Contato contato)
        {
            DaoC.deletar(contato);

            return RedirectToAction("Contato");
        }

        public IActionResult Details(Models.Contato cont)
        {
            Models.Contato contato = Dados.Dados.contatos.FirstOrDefault(ct => ct.Id == cont.Id);

            return View(contato);
        }

        [HttpGet]
        public IActionResult Consultar()
        {
            return View();
        }
    }
}
