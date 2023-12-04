using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC3.Dao;

namespace MVC3.Controllers
{
    public class CompromissoController : Controller
    {
        DaoCompromissos DaoComp = new();
        public IActionResult Compromisso()
        {
            Dados.Dados.compromissos = DaoComp.consultar();

            return View(Dados.Dados.compromissos);
        }

        [HttpGet]
        public IActionResult Criar()
        {
            List<SelectListItem> Contato = new List<SelectListItem>();

            Contato = Dados.Dados.contatos.Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() }).ToList();

            ViewBag.contatos = Contato;

            List<SelectListItem> Local = new();

            Local = Dados.Dados.locais.Select(l => new SelectListItem() { Text = l.Nome, Value = l.Id.ToString() }).ToList();

            ViewBag.locais = Local;

            return View();
        }

        [HttpPost]
        public IActionResult Criar(Models.Compromisso comp)
        {
            DaoComp.salvar(comp);

            Models.Local lc = Dados.Dados.locais.FirstOrDefault(c => c.Id == comp.LocalC.Id);
            comp.LocalC = lc;

            Models.Contato ct = Dados.Dados.contatos.FirstOrDefault(c => c.Id == comp.ContatoC.Id);
            comp.ContatoC = ct;

            comp.Data = $"{Convert.ToString(comp.DataHora.Day)}/{Convert.ToString(comp.DataHora.Month)}/{Convert.ToString(comp.DataHora.Year)}";
            comp.Hora = Convert.ToString(comp.DataHora.TimeOfDay);

            

            Dados.Dados.compromissos.Add(comp);

            return RedirectToAction("Compromisso");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Models.Compromisso comp = Dados.Dados.compromissos.FirstOrDefault(cp => cp.Id == id);

            List<SelectListItem> Contato = new List<SelectListItem>();

            Contato = Dados.Dados.contatos.Select(c => new SelectListItem() { Text = c.Name, Value = c.Id.ToString() }).ToList();

            ViewBag.contatos = Contato;

            List<SelectListItem> Local = new();

            Local = Dados.Dados.locais.Select(l => new SelectListItem() { Text = l.Nome, Value = l.Id.ToString() }).ToList();

            ViewBag.locais = Local;

            return View(comp);
        }

        [HttpPost]
        public IActionResult Edit(Models.Compromisso comp)
        {
            Models.Compromisso compro = Dados.Dados.compromissos.FirstOrDefault(cp => cp.Id == comp.Id);

            compro.Id = comp.Id;
            compro.Descricao = comp.Descricao;

            Models.Local lc = Dados.Dados.locais.FirstOrDefault(c => c.Id == comp.LocalC.Id);
            compro.LocalC = lc;

            compro.Hora = comp.Hora = Convert.ToString(comp.DataHora.TimeOfDay);
            compro.Status = comp.Status;
            compro.Data = comp.Data = $"{Convert.ToString(comp.DataHora.Day)}/{Convert.ToString(comp.DataHora.Month)}/{Convert.ToString(comp.DataHora.Year)}";

            Models.Contato ct = Dados.Dados.contatos.FirstOrDefault(c => c.Id == comp.ContatoC.Id);
            compro.ContatoC = ct;

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
