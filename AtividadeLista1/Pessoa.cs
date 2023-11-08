using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtividadeLista1
{
    class Pessoa
    {
        public string Nome { get; set; }
        public int Numero { get; set; }

        public Pessoa() { }

        public Pessoa(string Nome, int Numero)
        {
            this.Nome = Nome;
            this.Numero = Numero;
        }

        public string toString()
        {
            return $"{Nome}\n{Numero}";
        }
    }
}
