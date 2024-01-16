using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_2.Context;
using API_2.Models;

namespace API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly Context.Context _context;

        public ProdutosController(Context.Context context)
        {
            _context = context;
        }

        // GET: api/Produtos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            List<Produto> produtos = new List<Produto>();

            produtos = await _context.Produtos.ToListAsync();

            foreach (var i in produtos)
            {
                i.Category = await _context.Categorias.FirstOrDefaultAsync(ct => ct.Id == i.CategoriaId);
            }

            return produtos;
        }

        // GET: api/Produtos/5
        [HttpGet("/api/[controller]/searchById{id}")]
        public async Task<ActionResult<Produto>> GetProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if (produto == null)
            {
                return NotFound();
            }

            produto.Category = await _context.Categorias.FirstOrDefaultAsync(ct => ct.Id == produto.CategoriaId);

            return produto;
        }

        // PUT: api/Produtos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduto(int id, Produto produto)
        {
            if (id != produto.Id)
            {
                return BadRequest();
            }

            produto.Category = await _context.Categorias.FirstOrDefaultAsync(ct => ct.Id == produto.Category.Id);
            produto.CategoriaId = produto.Category.Id;

            _context.Entry(produto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProdutoExists(id))
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

        [HttpPost]
        public async Task<ActionResult<Produto>> PostProduto(Produto produto)
        {
            produto.Category = await _context.Categorias.FirstOrDefaultAsync(ct => ct.Id == produto.Category.Id);
            produto.CategoriaId = produto.Category.Id;

            _context.Produtos.Add(produto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduto", new { id = produto.Id }, produto);
        }

        // DELETE: api/Produtos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduto(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);
            if (produto == null)
            {
                return NotFound();
            }

            _context.Produtos.Remove(produto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpGet("{categoriaId}")]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutosCategoria(int categoriaId)
        {
            List<Produto> produtos = new List<Produto>();

            produtos = (from produto in _context.Produtos where produto.CategoriaId == categoriaId select produto).ToList();

            foreach (var i in produtos)
            {
                i.Category = await _context.Categorias.FirstOrDefaultAsync(ct => ct.Id == i.CategoriaId);
            }

            return produtos;
        }

        private bool ProdutoExists(int id)
        {
            return _context.Produtos.Any(e => e.Id == id);
        }
    }
}
