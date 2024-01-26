using API_2.Interfaces;
using API_2.Models;
using API_2.Conexao;
using MySql.Data.MySqlClient;

namespace API_2.Dao
{
    public class DaoUsers : ICrud<User>
    {
        public bool alterar(User usuario)
        {
            MySqlConnection con = new();

            con.ConnectionString = Conexao.Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = "update tb_users set nome = @nome, roles = @role, senha = @senha where id = @id";

                cm.Parameters.Add("id", MySqlDbType.Int32).Value = usuario.Id;
                cm.Parameters.Add("nome", MySqlDbType.VarChar).Value = usuario.Nome;
                cm.Parameters.Add("role", MySqlDbType.VarChar).Value = usuario.Role;
                cm.Parameters.Add("senha", MySqlDbType.VarChar).Value = usuario.Senha;

                cm.Connection = con;

                MySqlDataReader dr;

                dr = cm.ExecuteReader();

            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return true;
        }

        public List<User> consultar()
        {
            List<User> usuarios = new();

            MySqlConnection con = new();

            con.ConnectionString = Conexao.Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = "select * from tb_users";

                MySqlDataReader dr;

                cm.Connection = con;

                dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    User usuario = new();

                    usuario.Id = Convert.ToInt32(dr["id"]);
                    usuario.Nome = Convert.ToString(dr["nome"]);
                    usuario.Role = Convert.ToString(dr["roles"]);
                    usuario.Senha = Convert.ToString(dr["senha"]);

                    usuarios.Add(usuario);
                }
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return usuarios;
        }

        public void deletar(int id)
        {
            MySqlConnection con = new();

            con.ConnectionString = Conexao.Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = "delete from tb_users where id = @id";

                cm.Parameters.Add("id", MySqlDbType.Int32).Value = id;

                cm.Connection = con;

                MySqlDataReader dr;

                dr = cm.ExecuteReader();

            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }
        }

        public bool inserir(User usuario)
        {
            MySqlConnection con = new();

            con.ConnectionString = Conexao.Conexao.conecta();

            con.Open();

            try
            {
                MySqlCommand cm = con.CreateCommand();

                cm.CommandText = "insert into tb_users(nome, roles, senha)values(@nome, @role, @senha)";

                cm.Parameters.Add("nome", MySqlDbType.VarChar).Value = usuario.Nome;
                cm.Parameters.Add("role", MySqlDbType.VarChar).Value = usuario.Role;
                cm.Parameters.Add("senha", MySqlDbType.VarChar).Value = usuario.Senha;

                cm.Connection = con;

                cm.ExecuteNonQuery();
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return true;
        }
    }
}