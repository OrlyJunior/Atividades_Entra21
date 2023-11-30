using Microsoft.AspNetCore.Mvc;

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
    }
}
