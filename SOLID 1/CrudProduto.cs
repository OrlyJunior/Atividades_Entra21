using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_1
{
    class CrudProduto
    {
        List<Produto> produtos = new();

        public bool salvar(Produto prod)
        {
            produtos.Add(prod);

            Console.WriteLine("Produto adicionado com sucesso.");

            return true;
        }

        public bool consultar()
        {
            Console.WriteLine("Insira o id que quer encontrar:");
            int consulta = int.Parse(Console.ReadLine());

            foreach (Produto i in produtos)
            {
                if (i.Id == consulta)
                {
                    Console.WriteLine(i.toString());
                }
            }

            return true;
        }

        public bool consultarTodos()
        {
            foreach(Produto i in produtos)
            {
                Console.WriteLine(i.toString());
            }

            return true;
        }

        public bool deletar()
        {
            Console.WriteLine("Insira o id do produto que deseja deletar: ");
            int deleta = int.Parse(Console.ReadLine());

            for(int i = 0; i < produtos.Count; i++)
            {
                if (produtos[i].Id == deleta)
                {
                    produtos.RemoveAt(i);
                }
            }

            Console.WriteLine("Produto deletado com sucesso.");

            return true;
        }

        public bool alterar()
        {
            Produto produto = new();

            Console.WriteLine("Insira o novo id do Produto:");
            produto.Id = int.Parse(Console.ReadLine());

            Console.WriteLine("Insira a nova descrição do Produto:");
            produto.Descricao = Console.ReadLine();

            Console.WriteLine("Insira o novo preço do Produto:");
            produto.Preco = double.Parse(Console.ReadLine());

            Console.WriteLine("Insira o id do produto que deseja alterar: ");
            int altera = int.Parse(Console.ReadLine());

            for (int i = 0; i < produtos.Count; i++)
            {
                if (produtos[i].Id == altera)
                {
                    produtos[i] = produto;

                    break;
                }
            }

            Console.WriteLine("Produto alterado com sucesso.");

            return true;
        }
    }
}
