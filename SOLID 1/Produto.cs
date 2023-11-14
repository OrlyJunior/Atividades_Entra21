using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_1
{
    class Produto : ItoString
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }

        public string toString()
        {
            return $"Id: {Id}\nDescrição: {Descricao}\nPreço: {Preco}\n";
        }
    }
}