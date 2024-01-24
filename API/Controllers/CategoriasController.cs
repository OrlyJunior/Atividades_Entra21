using API_2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class CategoriasController : ControllerBase
    {
        private readonly Context.Context _context;

        public CategoriasController(Context.Context context)
        {
            _context = context;
        }

        // GET: api/Categorias
        [HttpGet]
        [EnableCors]
        [Authorize(Roles = "Funcionário,Gerente,Administrador")]

        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategorias()
        {
            return await _context.Categorias.ToListAsync();
        }

        // GET: api/Categorias/5
        [HttpGet("{id}")]
        [EnableCors]
        [Authorize(Roles = "Funcionário,Gerente")]
        public async Task<ActionResult<Categoria>> GetCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);

            if (categoria == null)
            {
                return NotFound();
            }

            return categoria;
        }

        // PUT: api/Categorias/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("/api/[controller]/{id}")]
        [Authorize(Roles = "Gerente")]
        public async Task<IActionResult> PutCategoria(int id, Categoria categoria)
        {
            if (id != categoria.Id)
            {
                return BadRequest();
            }

            _context.Entry(categoria).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CategoriaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPost("/api/[controller]")]
        [Authorize(Roles = "Funcionário")]
        public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
        {
            _context.Categorias.Add(categoria);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCategoria", new { id = categoria.Id }, categoria);
        }

        [HttpDelete("/api/[controller]/{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteCategoria(int id)
        {
            var categoria = await _context.Categorias.FindAsync(id);
            if (categoria == null)
            {
                return NotFound();
            }

            _context.Categorias.Remove(categoria);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("/api/[controller]/{desc}")]
        [Authorize(Roles = "Funcionário,Gerente,Administrador")]
        public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoriasDesc(string desc)
        {
            List<Categoria> categorias = _context.Categorias.Where(categoria => ContaLetrasIguais(categoria.Nome.ToLower(), desc.ToLower()) >= 3).ToList();

            return categorias;
        }

        private int ContaLetrasIguais(string palavra1, string palavra2)
        {
            return palavra1.Zip(palavra2, (c1, c2) => c1 == c2 ? 1 : 0).Sum();
        }
        private bool CategoriaExists(int id)
        {
            return _context.Categorias.Any(e => e.Id == id);
        }
    }
}
