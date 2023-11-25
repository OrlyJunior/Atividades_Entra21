using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Digests;
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
            Console.WriteLine("Qual o id do produto que deseja alterar?");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine($"Qual será o novo nome do produto de ID {id}?");
            string nome = Console.ReadLine();

            Console.WriteLine($"Qual será o novo valor unitário do produto de ID {id}?");
            decimal valorU = decimal.Parse(Console.ReadLine());

            Console.WriteLine($"Qual será o novo estoque do produto de ID {id}?");
            int estoque = int.Parse(Console.ReadLine());

            Console.WriteLine($"Qual será o novo ID da categoria do produto de ID {id}?");
            int catId = int.Parse(Console.ReadLine());

            MySqlConnection con = Conexao.conecta();

            MySqlCommand command = con.CreateCommand();

            command.CommandText = $"update tb_produtos set nome = @nome, valorUnitario = @valU, estoque = @estoque, categoriaId = @catId where tb_produtos.id = {id}";

            command.Parameters.Add("nome", MySqlDbType.VarChar).Value = nome;
            command.Parameters.Add("valU", MySqlDbType.Decimal).Value = valorU;
            command.Parameters.Add("estoque", MySqlDbType.Int32).Value = estoque;
            command.Parameters.Add("catId", MySqlDbType.Int32).Value = catId;

            con.Open();

            MySqlDataReader dr;
            dr = command.ExecuteReader();

            return true;
        }

        public bool consultar()
        {
            MySqlConnection con = Conexao.conecta();

            MySqlCommand command = con.CreateCommand();

            command.CommandText = $@"select tb_produtos.id, tb_produtos.nome, valorUnitario, estoque, categoriaId, nomeCategoria from tb_produtos, tb_categorias where tb_produtos.categoriaId = tb_categorias.Id";

            con.Open();

            MySqlDataReader dr;
            dr = command.ExecuteReader();

            while (dr.Read())
            {
                Produto prod = new();

                prod.Id = Convert.ToInt32(dr["id"]);
                prod.Nome = Convert.ToString(dr["nome"]);
                prod.ValorUnitario = Convert.ToDecimal(dr["valorUnitario"]);
                prod.Estoque = Convert.ToInt32(dr["estoque"]);

                Categoria categ = new();

                categ.Id = Convert.ToInt32(dr["categoriaId"]);
                categ.Nome = Convert.ToString(dr["nomeCategoria"]);

                prod.categoria = categ;

                Console.WriteLine(prod.toString());
            }

            return true;
        }

        public bool consultarId()
        {
            MySqlConnection con = Conexao.conecta();

            MySqlCommand command = con.CreateCommand();

            Console.WriteLine("Insira o id da categoria que deseja consultar:");
            int id = int.Parse(Console.ReadLine());

            command.CommandText = $@"select tb_produtos.id, tb_produtos.nome, valorUnitario, estoque, categoriaId, nomeCategoria from tb_produtos, tb_categorias where tb_produtos.categoriaId = tb_categorias.Id and tb_produtos.categoriaId = {id}";

            con.Open();

            MySqlDataReader dr;
            dr = command.ExecuteReader();

            while (dr.Read())
            {
                Produto prod = new();

                prod.Id = Convert.ToInt32(dr["id"]);
                prod.Nome = Convert.ToString(dr["nome"]);
                prod.ValorUnitario = Convert.ToDecimal(dr["valorUnitario"]);
                prod.Estoque = Convert.ToInt32(dr["estoque"]);

                Categoria categ = new();

                categ.Id = Convert.ToInt32(dr["categoriaId"]);
                categ.Nome = Convert.ToString(dr["nomeCategoria"]);

                prod.categoria = categ;

                Console.WriteLine(prod.toString());
            }

            return true;
        }

        public bool deletar()
        {
            Console.WriteLine("Qual o id do produto que deseja deletar?");
            int id = int.Parse(Console.ReadLine());

            MySqlConnection con = Conexao.conecta();

            MySqlCommand command = con.CreateCommand();

            command.CommandText = $@"delete from tb_produtos where id = {id}";

            con.Open();

            MySqlDataReader dr;
            dr = command.ExecuteReader();

            return true;
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