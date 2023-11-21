using AcessaBancoDeDados.Dao;
using AcessaBancoDeDados.Entidades;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace AcessaBancoDeDados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Contato contato = new Contato("asdasd", "123456789", "Blumenau");

            DaoContato dao = new();

            bool cont = true;

            while (cont == true)
            {
                Console.Clear();

                cont = false;

                Console.WriteLine("Qual operação deseja realizar?\n1 - Salvar\n2 - Deletar\n3 - Alterar\n4 - Consultar todos\n5 - Consultar por id");
                int op = int.Parse(Console.ReadLine());

                if (op == 1)
                {
                    dao.salvar(contato);

                    Console.WriteLine("Deseja continuar?\n1 - Sim\n2 - Não");

                    int opCont = int.Parse(Console.ReadLine());

                    if (opCont == 1)
                    {
                        cont = true;
                    }
                }

                if(op == 2)
                {
                    dao.deletar();

                    Console.WriteLine("Deseja continuar?\n1 - Sim\n2 - Não");
                    int opCont = int.Parse(Console.ReadLine());

                    if(opCont == 1)
                    {
                        cont = true;
                    }
                }

                if (op == 4)
                {
                    dao.consultar();

                    Console.WriteLine("Deseja continuar?\n1 - Sim\n2 - Não");
                    int opCont = int.Parse(Console.ReadLine());

                    if (opCont == 1)
                    {
                        cont = true;
                    }
                }

                if(op == 5)
                {
                    dao.consultaId();

                    Console.WriteLine("Deseja continuar?\n1 - Sim\n2 - Não");
                    int opCont = int.Parse(Console.ReadLine());

                    if (opCont == 1)
                    {
                        cont = true;
                    }
                }
            }
        }
    }
}