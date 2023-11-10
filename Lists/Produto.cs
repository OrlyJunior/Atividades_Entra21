using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lists
{
    class Produto
    {
        public int Id { get; set; }
        public string Desc { get; set; }
        public double Preco { get; set; }

        public string toString()
        {
            return $"\nId: {Id}\nDescrição: {Desc}\nPreço: {Preco}";
        }
    }
}
