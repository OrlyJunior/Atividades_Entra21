using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entity2.Data;
using Entity2.Models;

namespace Entity2.Controllers
{
    public class CompromissosController : Controller
    {
        private readonly Entity2Context _context;

        public CompromissosController(Entity2Context context)
        {
            _context = context;
        }

        // GET: Compromissos
        public async Task<IActionResult> Index()
        {
            var compromissos = await _context.Compromisso.ToListAsync();

            foreach (var comp in compromissos)
            {
                comp.Local = await _context.Local.FirstOrDefaultAsync(l => l.Id == comp.LocalId);
                comp.Contato = await _context.Contato.FirstOrDefaultAsync(l => l.Id == comp.ContatoId);
            }

            return View(compromissos);
        }

        public async Task<IActionResult> Details(int? id)
        {
            var compromisso = await _context.Compromisso.FirstOrDefaultAsync(m => m.Id == id);

            compromisso.Local = await _context.Local.FirstOrDefaultAsync(l => l.Id == compromisso.LocalId);
            compromisso.Contato = await _context.Contato.FirstOrDefaultAsync(l => l.Id == compromisso.ContatoId);
            
            return View(compromisso);
        }

        [HttpGet]
        public IActionResult Create()
        {
            List<SelectListItem> Contato = new List<SelectListItem>();

            Contato = _context.Contato.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();

            ViewBag.contatos = Contato;

            List<SelectListItem> Local = new();

            Local = _context.Local.Select(l => new SelectListItem() { Text = l.Nome, Value = l.Id.ToString() }).ToList();

            ViewBag.locais = Local;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Id,ContatoId,LocalId,Dia,Descricao")] Compromisso compromisso)
        {
            compromisso.Local = new();
            compromisso.Local = await _context.Local.FirstOrDefaultAsync(l => l.Id == compromisso.LocalId);

            compromisso.Contato = new();
            compromisso.Contato = await _context.Contato.FirstOrDefaultAsync(l => l.Id == compromisso.ContatoId);

            _context.Add(compromisso);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Compromissos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            List<SelectListItem> Contato = new List<SelectListItem>();

            Contato = _context.Contato.Select(c => new SelectListItem() { Text = c.Nome, Value = c.Id.ToString() }).ToList();

            ViewBag.contatos = Contato;

            List<SelectListItem> Local = new();

            Local = _context.Local.Select(l => new SelectListItem() { Text = l.Nome, Value = l.Id.ToString() }).ToList();

            ViewBag.locais = Local;

            if (id == null || _context.Compromisso == null)
            {
                return NotFound();
            }

            var compromisso = await _context.Compromisso.FindAsync(id);
            if (compromisso == null)
            {
                return NotFound();
            }
            return View(compromisso);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ContatoId,LocalId,Dia,Descricao")] Compromisso compromisso)
        {
            if (id != compromisso.Id)
            {
                return NotFound();
            }

            try
            {
                _context.Update(compromisso);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompromissoExists(compromisso.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Compromisso == null)
            {
                return NotFound();
            }

            var compromisso = await _context.Compromisso.FirstOrDefaultAsync(m => m.Id == id);

            compromisso.Local = await _context.Local.FirstOrDefaultAsync(l => l.Id == compromisso.LocalId);
            compromisso.Contato = await _context.Contato.FirstOrDefaultAsync(l => l.Id == compromisso.ContatoId);

            if (compromisso == null)
            {
                return NotFound();
            }

            return View(compromisso);
        }

        // POST: Compromissos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Compromisso == null)
            {
                return Problem("Entity set 'Entity2Context.Compromisso'  is null.");
            }
            var compromisso = await _context.Compromisso.FindAsync(id);
            if (compromisso != null)
            {
                _context.Compromisso.Remove(compromisso);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CompromissoExists(int id)
        {
          return (_context.Compromisso?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
