using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeListas2
{
    class Produto
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public double Preco { get; set; }

        public string toString()
        {
            return $"Id: {Id}\nDescrição: {Desc}\nPreço: {Preco}\n";
        }
    }
}
