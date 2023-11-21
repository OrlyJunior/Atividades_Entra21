namespace ProdutosBD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Produto> produtos = new List<Produto>();

            CrudCategorias crudC = new();
            CrudProduto crudP = new();

            bool cont = true;

            while (cont == true)
            {
                Console.Clear();

                cont = false;

                Console.WriteLine("Qual operação deseja realizar?\n1 - Adicionar categoria\n2 - Consultar categorias\n3 - Adicionar produto\n4 - Consultar produto\n5 - Consultar por categoria\n6 - Deletar produto\n7 - Editar produto");
                int op = int.Parse(Console.ReadLine());

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
                    crudC.consultar();

                    Console.WriteLine("\nDeseja continuar?\n1 - Sim\n2 - Não");
                    int cont2 = int.Parse(Console.ReadLine());

                    if (cont2 == 1)
                    {
                        cont = true;
                    }
                }

                if (op == 3)
                {
                    crudP.add();

                    Console.WriteLine("\nDeseja continuar?\n1 - Sim\n2 - Não");
                    int cont2 = int.Parse(Console.ReadLine());

                    if (cont2 == 1)
                    {
                        cont = true;
                    }
                }

                if (op == 4)
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

                if (op == 5)
                {
                    crudP.consultarCategoria();

                    Console.WriteLine("\nDeseja continuar?\n1 - Sim\n2 - Não");
                    int cont2 = int.Parse(Console.ReadLine());

                    if (cont2 == 1)
                    {
                        cont = true;
                    }
                }

                if(op == 6)
                {
                    crudP.deletar();

                    Console.WriteLine("\nDeseja continuar?\n1 - Sim\n2 - Não");
                    int cont2 = int.Parse(Console.ReadLine());

                    if (cont2 == 1)
                    {
                        cont = true;
                    }
                }

                if (op == 7)
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