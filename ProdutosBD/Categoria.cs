using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosBD
{
    class Categoria
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string toString()
        {
            return $"\nId: {Id}\nNome: {Nome}";
        }
    }
}
