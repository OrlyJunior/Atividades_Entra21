using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heranca
{
    class Cliente : Pessoa
    {
        public int cpf { get; set; }
        public int fone { get; set; }

        public string toString()
        {
            string padrao = base.toString();
            return $"{padrao}\nCPF: {cpf}\nTelefone: {fone}\n";
        }
        public Cliente()
        {

        }

        public Cliente(int Id, string PessoaNome, int cpf, int fone) : base(Id, PessoaNome)
        {
            this.cpf = cpf;
            this.fone = fone;
        }
    } 
}
