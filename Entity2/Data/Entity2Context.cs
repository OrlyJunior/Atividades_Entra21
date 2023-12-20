using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entity2.Models;

namespace Entity2.Data
{
    public class Entity2Context : DbContext
    {
        public Entity2Context (DbContextOptions<Entity2Context> options)
            : base(options)
        {
        }

        public DbSet<Entity2.Models.Contato> Contato { get; set; } = default!;

        public DbSet<Entity2.Models.Local>? Local { get; set; }

        public DbSet<Entity2.Models.Compromisso>? Compromisso { get; set; }

        public DbSet<Entity2.Models.Encapsulamento>? Encapsulamento { get; set; }
    }
}
