using MySql.Data.MySqlClient;
using System.Data;

namespace ConectaMySQL
{
    class DaoMySqlCategorias : ICrud
    {
        public bool salvar()
        {
            Console.WriteLine("Insira o nome da categoria que deseja inserir:");
            string nome = Console.ReadLine();

            MySqlConnection con = Conexao.conecta();

            MySqlCommand command = con.CreateCommand();

            try
            {
                command.CommandText = "insert into tb_categorias(nomeCategoria)values(@nome)";

                command.Parameters.Add("nome", MySqlDbType.VarChar).Value = nome;

                con.Open();

                command.ExecuteNonQuery();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            return true;
        }

        public bool consultar()
        {
            MySqlConnection con = Conexao.conecta();

            MySqlCommand command = con.CreateCommand();

            try
            {
                command.CommandText = "select * from tb_categorias";

                con.Open();

                MySqlDataReader dr;
                dr = command.ExecuteReader();

                while (dr.Read())
                {
                    Categoria categ = new();

                    categ.Id = Convert.ToInt32(dr["id"]);
                    categ.Nome = Convert.ToString(dr["nomeCategoria"]);

                    Console.WriteLine(categ.toString());
                }
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return true;
        }

        public bool consultarId()
        {
            Console.WriteLine("Insira o id da categoria que deseja consultar:");
            int id = int.Parse(Console.ReadLine());

            MySqlConnection con = Conexao.conecta();

            MySqlCommand command = con.CreateCommand();

            try
            {
                command.CommandText = "select * from tb_categorias";

                con.Open();

                MySqlDataReader dr;
                dr = command.ExecuteReader();

                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["id"]) == id)
                    {
                        Categoria categ = new();

                        categ.Id = Convert.ToInt32(dr["id"]);
                        categ.Nome = Convert.ToString(dr["nomeCategoria"]);

                        Console.WriteLine(categ.toString());

                        break;
                    }
                }
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

            return true;
        }

        public bool deletar()
        {
            Console.WriteLine("Insira qual o ID da categoria que deseja deletar:");
            int id = Convert.ToInt32(Console.ReadLine());

            MySqlConnection con = Conexao.conecta();

            MySqlCommand command = con.CreateCommand();

            try
            {
                command.CommandText = $@"delete from tb_categorias where id = {id}";


                con.Open();

                MySqlDataReader dr;
                dr = command.ExecuteReader();

            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }  
            }

            return true;
        }

        public bool alterar()
        {
            Console.WriteLine("Qual o ID da categoria que deseja alterar?");
            int id = int.Parse(Console.ReadLine());

            Console.WriteLine($"Qual será o novo nome do produto de ID {id}?");
            string nome = Console.ReadLine();

            MySqlConnection con = Conexao.conecta();

            MySqlCommand command = con.CreateCommand();

            try 
            {
                command.CommandText = $@"update tb_categorias set nomeCategoria = @nome where id = {id}";

                command.Parameters.Add("nome", MySqlDbType.VarChar).Value = nome;
                con.Open();

                MySqlDataReader dr;
                dr = command.ExecuteReader();
            }
            finally
            {
                if (con.State == ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return true;
        }
    }
}
