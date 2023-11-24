namespace ConectaMySQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool cont = true;

            DaoMySql produtos = new();
            DaoMySqlCategorias categorias = new();

            while (cont == true)
            {
                Console.Clear();

                cont = false;

                Console.WriteLine("Qual operação deseja realizar?\n1 - Adicionar categoria\n2 - Consultar todas as categorias\n3 - Consultar categoria por ID\n4 - Deletar categoria\n5 - Alterar categoria\n6 - Inserir produto");
                int op = int.Parse(Console.ReadLine());

                Console.Clear();

                if (op == 1)
                {
                    categorias.salvar();

                    Console.WriteLine("Deseja continuar?\n1 - Sim\n2 - Não");
                    int cont2 = int.Parse(Console.ReadLine());

                    if (cont2 == 1)
                    {
                        cont = true;
                    }
                }

                if (op == 2)
                {
                    categorias.consultar();

                    Console.WriteLine("Deseja continuar?\n1 - Sim\n2 - Não");
                    int cont2 = int.Parse(Console.ReadLine());

                    if (cont2 == 1)
                    {
                        cont = true;
                    }
                }

                if (op == 3)
                {
                    categorias.consultarId();

                    Console.WriteLine("Deseja continuar?\n1 - Sim\n2 - Não");
                    int cont2 = int.Parse(Console.ReadLine());

                    if (cont2 == 1)
                    {
                        cont = true;
                    }
                }

                if (op == 4)
                {
                    categorias.deletar();

                    Console.WriteLine("\nDeseja continuar?\n1 - Sim\n2 - Não");
                    int cont2 = int.Parse(Console.ReadLine());

                    if (cont2 == 1)
                    {
                        cont = true;
                    }
                }

                if (op == 5)
                {
                    categorias.alterar();

                    Console.WriteLine("\nDeseja continuar?\n1 - Sim\n2 - Não");
                    int cont2 = int.Parse(Console.ReadLine());

                    if (cont2 == 1)
                    {
                        cont = true;
                    }
                }

                if (op == 6)
                {
                    produtos.salvar();

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