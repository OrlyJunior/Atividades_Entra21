using Microsoft.AspNetCore.Mvc;
using MVC3.Models;

namespace MVC3.Controllers
{
    public class CompromissoController : Controller
    {
        public IActionResult Compromisso()
        {
            return View(Dados.Dados.compromissos);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Models.Compromisso comp)
        {
            comp.Id = Dados.Dados.compromissos.Count + 1;
            try
            {
                comp.Local = Dados.Dados.locais[comp.LocalId - 1].Nome;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                comp.Local = "Não definido";
            }

            try
            {
                comp.Contato = Dados.Dados.contatos[comp.ContatoId - 1].Name;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                comp.Contato = "Não definido";
            }

            comp.Data = $"{Convert.ToString(comp.DataHora.Day)}/{Convert.ToString(comp.DataHora.Month)}/{Convert.ToString(comp.DataHora.Year)}";
            comp.Hora = Convert.ToString(comp.DataHora.TimeOfDay);

            Dados.Dados.compromissos.Add(comp);

            return RedirectToAction("Compromisso");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Models.Compromisso comp = Dados.Dados.compromissos.FirstOrDefault(cp => cp.Id == id);

            return View(comp);
        }

        [HttpPost]
        public IActionResult Edit(Models.Compromisso comp)
        {
            Models.Compromisso compro = Dados.Dados.compromissos.FirstOrDefault(cp => cp.Id == comp.Id);

            compro.Id = comp.Id;
            compro.LocalId = comp.LocalId;
            compro.Hora = comp.Hora = Convert.ToString(comp.DataHora.TimeOfDay);
            compro.Status = comp.Status;
            compro.Data = comp.Data = $"{Convert.ToString(comp.DataHora.Day)}/{Convert.ToString(comp.DataHora.Month)}/{Convert.ToString(comp.DataHora.Year)}";
            compro.ContatoId = comp.ContatoId;

            try
            {
                comp.Local = Dados.Dados.locais[comp.LocalId - 1].Nome;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                comp.Local = "Não definido";
            }

            try
            {
                comp.Contato = Dados.Dados.contatos[comp.ContatoId - 1].Name;
            }
            catch (System.ArgumentOutOfRangeException)
            {
                comp.Contato = "Não definido";
            }

            return RedirectToAction("Compromisso");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Models.Compromisso comp = Dados.Dados.compromissos.FirstOrDefault(cp => cp.Id == id);

            return View(comp);
        }

        [HttpPost]
        public IActionResult Delete(Models.Compromisso comp)
        {
            Models.Compromisso compro = Dados.Dados.compromissos.FirstOrDefault(cp => cp.Id == comp.Id);

            Dados.Dados.compromissos.Remove(compro);

            return RedirectToAction("Compromisso");
        }

        public IActionResult Details(Models.Compromisso comp)
        {
            Models.Compromisso compro = Dados.Dados.compromissos.FirstOrDefault(cp => cp.Id == comp.Id);

            return View(compro);
        }
    }
}
