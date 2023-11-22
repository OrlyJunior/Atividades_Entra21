using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosBD
{
    interface ICrud<T>
    {
        public bool add();

        public List<T> consultar(List<T> t);

        public bool mostrar(List<T> t);

        public bool consultarCategoria(List<T> t);

        public bool deletar();

        public bool alterar();
    }
}
