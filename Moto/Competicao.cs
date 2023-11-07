using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto
{
    class Competicao : Moto
    {
        public int numeracao;

        public Competicao() 
        { 

        }

        public Competicao(string modelo, string marca, int cilindradas, string cor, int numeracao) : base(modelo, marca, cilindradas, cor)
        {
            this.numeracao = numeracao;
        }

        public string toString()
        {
            string padraoC = base.toString();
            return $"\n{padraoC}\nNumeração: {numeracao}";
        }
    }
}
