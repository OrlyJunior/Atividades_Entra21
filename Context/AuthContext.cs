using Microsoft.EntityFrameworkCore;

namespace Autenticacao.Context
{
    public class AuthContext : DbContext
    {
        public AuthContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Autenticacao.Models.User> usuarios { get; set; }
    }
}
