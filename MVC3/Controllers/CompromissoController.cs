using Microsoft.AspNetCore.Mvc;
using MVC3.Models;

namespace MVC3.Controllers
{
    public class CompromissoController : Controller
    {
        static List<Models.Compromisso> compromissos = new();
        public IActionResult Compromisso()
        {
            return View(compromissos);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Models.Compromisso comp)
        {
            comp.Id = compromissos.Count + 1;
            comp.Data = $"{Convert.ToString(comp.DataHora.Day)}/{Convert.ToString(comp.DataHora.Month)}/{Convert.ToString(comp.DataHora.Year)}";
            comp.Hora = Convert.ToString(comp.DataHora.TimeOfDay);

            compromissos.Add(comp);

            return RedirectToAction("Compromisso");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Models.Compromisso comp = compromissos.FirstOrDefault(cp => cp.Id == id);

            return View(comp);
        }

        [HttpPost]
        public IActionResult Edit(Models.Compromisso comp)
        {
            Models.Compromisso compro = compromissos.FirstOrDefault(cp => cp.Id == comp.Id);

            compro.Id = comp.Id;
            compro.LocalId = comp.LocalId;
            compro.Hora = comp.Hora = Convert.ToString(comp.DataHora.TimeOfDay);
            compro.Status = comp.Status;
            compro.Data = comp.Data = $"{Convert.ToString(comp.DataHora.Day)}/{Convert.ToString(comp.DataHora.Month)}/{Convert.ToString(comp.DataHora.Year)}";
            compro.ContatoId = comp.ContatoId;

            return RedirectToAction("Compromisso");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Models.Compromisso comp = compromissos.FirstOrDefault(cp => cp.Id == id);

            return View(comp);
        }

        [HttpPost]
        public IActionResult Delete(Models.Compromisso comp)
        {
            Models.Compromisso compro = compromissos.FirstOrDefault(cp => cp.Id == comp.Id);

            compromissos.Remove(compro);

            return RedirectToAction("Compromisso");
        }
    }
}
