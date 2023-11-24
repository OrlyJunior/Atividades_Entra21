using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectaMySQL
{
    class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Estoque { get; set; }
        public Categoria categoria { get; set; }


        public string toString()
        {
            return $"Id: {Id}\nNome: {Nome}\nValor unitário: {ValorUnitario}\nEstoque: {Estoque}\nCategoria: {categoria.Id} | {categoria.Nome}\n";
        }
    }
}
