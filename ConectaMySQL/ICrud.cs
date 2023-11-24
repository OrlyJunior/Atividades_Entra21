using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectaMySQL
{
    interface ICrud
    {
        public bool salvar();
        public bool consultar();
        public bool consultarId();
        public bool deletar();
        public bool alterar();
    }
}
