using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Heranca
{
    class Pessoa
    {
        public int Id { get; set; }
        public string PessoaNome { get; set; }

        public string toString()
        {
            return $"Id: {Id}\nNome: {PessoaNome}";
        }

        public Pessoa()
        {

        }

        public Pessoa(int Id, string PessoaNome)
        {
            this.Id = Id;
            this.PessoaNome= PessoaNome;
        }
    }
}
