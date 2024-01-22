using System.Collections.Generic;
using API_2.Models;
using Microsoft.EntityFrameworkCore;

namespace API_2.Context
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
