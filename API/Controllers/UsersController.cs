using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_2.Context;
using API_2.Dao;
using API_2.Models;
using API_2.Listas;
using API_2.Dtos;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace API_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class UsersController : ControllerBase
    {
        public DaoUsers daoU = new();

        private readonly Context.Context _context;

        public UsersController(Context.Context context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsuarios()
        {
            Listas.Listas.listaUsuarios = daoU.consultar();

            return Listas.Listas.listaUsuarios;
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = Listas.Listas.listaUsuarios.FirstOrDefault(us => us.Id == id);

            return user;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            daoU.consultar();

            daoU.alterar(user);

            return NoContent();
        }

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("/api/[controller]")]
        [EnableCors]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            daoU.consultar();

            daoU.inserir(user);

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [HttpPost("Login")]
        public async Task<ActionResult<dynamic>> PostLogin(UserDto user)
        {
            string token = "";

            var logado = (from usuar in daoU.consultar() where usuar.Senha == user.Senha & usuar.Nome == user.Nome select usuar).ToList();

            if (!logado.IsNullOrEmpty())
            {
                token = Data.Token.GeraToken(logado[0]);
            }

            return new { token = token };
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            daoU.consultar();

            daoU.deletar(id);

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Usuarios.Any(e => e.Id == id);
        }
    }
}
