namespace SOLID_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CrudProduto crud = new();

            bool p = true;

            while (p)
            {
                Console.Clear();

                Console.WriteLine("O que deseja fazer?");
                Console.WriteLine("1 - Adicionar");
                Console.WriteLine("2 - Deletar");
                Console.WriteLine("3 - Alterar");
                Console.WriteLine("4 - Consultar todos");
                Console.WriteLine("5 - Consultar por id");

                int op = int.Parse(Console.ReadLine());

                if (op == 1)
                {
                    Produto produto = new();

                    crud.salvar(produto);
                }
                else if (op == 4)
                {
                    Console.Clear();

                    crud.consultarTodos();

                    Console.ReadKey();
                }
                else if (op == 5)
                {
                    Console.Clear();

                    crud.consultar();

                    Console.ReadKey();
                }
                else if (op == 2)
                {
                    Console.Clear();

                    crud.deletar();

                    Console.ReadKey();
                }
                else if(op == 3)
                {
                    Console.Clear();

                    crud.alterar();

                    Console.ReadKey();
                }
            }
        }
    }
}