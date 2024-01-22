using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Autenticacao.Context;
using Autenticacao.Models;
using Microsoft.IdentityModel.Tokens;
using Autenticacao.Models.Config;
using Autenticacao.Dtos;

namespace Autenticacao.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AuthContext _context;

        public UsersController(AuthContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> Getusuarios()
        {
            return await _context.usuarios.ToListAsync();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            _context.usuarios.Add(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("login")]
        public async Task<ActionResult<dynamic>> PostLogin(UserDto user)
        {
            string token = "";

            var users = await _context.usuarios.ToListAsync();
            var logado = (from u in users where u.Nome == user.Nome & u.Senha == user.Senha select u).ToList();

            if (!logado.IsNullOrEmpty())
            {
                token = TokenService.GenerateToken(logado[0]);
            }
            
            return new { token = token};
        }

        private bool UserExists(int id)
        {
            return _context.usuarios.Any(e => e.Id == id);
        }
    }
}