using System.IO;

namespace ExercícioArquivo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            

            Crud crud = new();

            bool cont = true;

            while(cont == true)
            {
                Console.Clear();

                Console.WriteLine("Qual operação deseja realizar?\n1 - Adicionar\n2 - Mostrar\n3 - Deletar\n4 - Alterar");
                int op = int.Parse(Console.ReadLine());

                if (op == 1)
                {
                    crud.add();
                }

                if (op == 2)
                {
                    crud.show();

                    Console.ReadKey();
                }

                if (op == 3)
                {
                    crud.deletar();

                    Console.ReadKey();
                }

                if(op == 4)
                {
                    crud.alterar();

                    Console.ReadKey();
                }
            }
        }
    }
}