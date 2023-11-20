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

            dao.consultar();

            /*if (dao.salvar(contato))
            {
                Console.WriteLine("Salvo");
            }*/
        }
    }
}