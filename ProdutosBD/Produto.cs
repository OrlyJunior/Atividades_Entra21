using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosBD
{
    class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorUnitario { get; set; }
        public int Estoque { get; set; }
        public int CategoriaId { get; set; }

        public Categoria categoria { get; set; }

        public string toString()
        {
            return $"\nId: {Id}\nNome: {Nome}\nValor Unitário: {ValorUnitario}\nEstoque: {Estoque}\nId Categoria: {categoria.Id} | Categoria: {categoria.Nome}";
        }
    }
}
