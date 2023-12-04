using Microsoft.AspNetCore.Mvc;
using MVC3.Dao;
using MVC3.Models;

namespace MVC3.Controllers
{
    public class LocalController : Controller
    {
        DaoLocais DaoL = new();
        public IActionResult Local()
        {
            Dados.Dados.locais = DaoL.consultar();

            return View(Dados.Dados.locais);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Models.Local local)
        {
            DaoL.salvar(local);

            return RedirectToAction("Local");
        }

        public IActionResult Details(Models.Local local)
        {
            Models.Local loca = Dados.Dados.locais.FirstOrDefault(ct => ct.Id == local.Id);

            return View(loca);
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Models.Local local = Dados.Dados.locais.FirstOrDefault(ct => ct.Id == id);

            return View(local);
        }

        [HttpPost]
        public IActionResult Edit(Models.Local loca)
        {
            DaoL.editar(loca);

            return RedirectToAction("Local");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Models.Local local = Dados.Dados.locais.FirstOrDefault(ct => ct.Id == id);

            return View(local);
        }

        [HttpPost]
        public IActionResult Delete(Models.Local loca)
        {
            DaoL.deletar(loca);

            return RedirectToAction("Local");
        }

        [HttpGet]
        public IActionResult Consultar()
        {
            return View();
        }
    }
}
