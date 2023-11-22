namespace ProdutosBD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CrudCategorias crudC = new();
            CrudProduto crudP = new();

            bool cont = true;

            while (cont == true)
            {
                Console.Clear();

                List<Categoria> categorias = new();

                List<Produto> produtos = new List<Produto>();

                cont = false;

                Console.WriteLine("Qual operação deseja realizar?\n1 - Adicionar categoria\n2 - Consultar todas as categorias\n3 - Consultar a categoria pelo id\n4 - Deletar categoria\n5 - Alterar categoria\n6 - Adicionar produto\n7 - Consultar todos os produtos\n8 - Consultar produtos por categoria\n9 - Deletar produto\n10 - Editar produto");
                int op = int.Parse(Console.ReadLine());

                Console.Clear();

                if(op == 1)
                {
                    crudC.add();

                    Console.WriteLine("\nDeseja continuar?\n1 - Sim\n2 - Não");
                    int cont2 = int.Parse(Console.ReadLine());

                    if(cont2 == 1)
                    {
                        cont = true;
                    }
                }

                if (op == 2)
                {
                    crudC.consultar(categorias);

                    crudC.mostrar(categorias);

                    Console.WriteLine("\nDeseja continuar?\n1 - Sim\n2 - Não");
                    int cont2 = int.Parse(Console.ReadLine());

                    if (cont2 == 1)
                    {
                        cont = true;
                    }
                }

                if(op == 3)
                {
                    crudC.consultarCategoria(categorias);

                    crudC.mostrar(categorias);

                    Console.WriteLine("\nDeseja continuar?\n1 - Sim\n2 - Não");
                    int cont2 = int.Parse(Console.ReadLine());

                    if (cont2 == 1)
                    {
                        cont = true;
                    }
                }

                if (op == 4)
                {
                    crudC.deletar();

                    Console.WriteLine("\nDeseja continuar?\n1 - Sim\n2 - Não");
                    int cont2 = int.Parse(Console.ReadLine());

                    if (cont2 == 1)
                    {
                        cont = true;
                    }
                }

                if (op == 5)
                {
                    crudC.alterar();

                    Console.WriteLine("\nDeseja continuar?\n1 - Sim\n2 - Não");
                    int cont2 = int.Parse(Console.ReadLine());

                    if (cont2 == 1)
                    {
                        cont = true;
                    }
                }

                if (op == 6)
                {
                    crudP.add();

                    Console.WriteLine("\nDeseja continuar?\n1 - Sim\n2 - Não");
                    int cont2 = int.Parse(Console.ReadLine());

                    if (cont2 == 1)
                    {
                        cont = true;
                    }
                }

                if (op == 7)
                {
                    crudP.consultar(produtos);

                    crudP.mostrar(produtos);

                    Console.WriteLine("\nDeseja continuar?\n1 - Sim\n2 - Não");
                    int cont2 = int.Parse(Console.ReadLine());

                    if (cont2 == 1)
                    {
                        cont = true;
                    }
                }

                if (op == 8)
                {
                    crudP.consultarCategoria(produtos);

                    crudP.mostrar(produtos);

                    Console.WriteLine("\nDeseja continuar?\n1 - Sim\n2 - Não");
                    int cont2 = int.Parse(Console.ReadLine());

                    if (cont2 == 1)
                    {
                        cont = true;
                    }
                }

                if (op == 9)
                {
                    crudP.deletar();

                    Console.WriteLine("\nDeseja continuar?\n1 - Sim\n2 - Não");
                    int cont2 = int.Parse(Console.ReadLine());

                    if (cont2 == 1)
                    {
                        cont = true;
                    }
                }

                if (op == 10)
                {
                    crudP.alterar();

                    Console.WriteLine("\nDeseja continuar?\n1 - Sim\n2 - Não");
                    int cont2 = int.Parse(Console.ReadLine());

                    if (cont2 == 1)
                    {
                        cont = true;
                    }
                }
            }
        }
    }
}