using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConectaMySQL
{
    class DaoMySql : ICrud
    {
        public bool alterar()
        {
            throw new NotImplementedException();
        }

        public bool consultar()
        {
            throw new NotImplementedException();
        }

        public bool consultarId()
        {
            throw new NotImplementedException();
        }

        public bool deletar()
        {
            throw new NotImplementedException();
        }

        public bool salvar()
        {
            Console.WriteLine("Qual o nome do produto que deseja adicionar?");
            string nome = Console.ReadLine();

            Console.WriteLine("Qual o valor unitário do produto que deseja adicionar?");
            decimal valU = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Qual o estoque do produto que deseja adicionar?");
            int estoque = int.Parse(Console.ReadLine());

            Console.WriteLine("Qual o ID da categoria do produto que deseja adicionar?");
            int categoria = int.Parse(Console.ReadLine());

            MySqlConnection con = Conexao.conecta();

            MySqlCommand command = con.CreateCommand();

            command.CommandText = "insert into tb_produtos(nome, valorUnitario, estoque, categoriaId)values(@nome, @valorUnitario, @estoque, @categoriaId)";

            command.Parameters.Add("nome", MySqlDbType.VarChar).Value = nome;
            command.Parameters.Add("valorUnitario", MySqlDbType.Decimal).Value = valU;
            command.Parameters.Add("estoque", MySqlDbType.Int32).Value = estoque;
            command.Parameters.Add("categoriaId", MySqlDbType.Int32).Value = categoria;

            con.Open();

            command.ExecuteNonQuery();

            return true;
        }
    }
}