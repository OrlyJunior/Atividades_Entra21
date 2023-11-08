using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeListas2
{
    class Produto
    {
        public int id { get; set; }
        public string desc { get; set; }
        public double preco { get; set; }



        public string toString()
        {
            return $"Id: {id}\nDescrição: {desc}\nPreço: {preco}\n";
        }
    }
}
