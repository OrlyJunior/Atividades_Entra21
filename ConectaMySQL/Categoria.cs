using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectaMySQL
{
    class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string toString()
        {
            return $"Id: {Id}\nNome: {Nome}\n";
        }
    }
}
