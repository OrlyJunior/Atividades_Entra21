using MVC3.Interfaces;
using MVC3.Models;
using MySql.Data.MySqlClient;

namespace MVC3.Dao
{
    public class DaoContato : ICrud<Contato>
    {
        public Contato consultar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contato> consultar()
        {
            List<Contato> contatos = new();

            MySqlConnection con = new();

            con.ConnectionString = Dados.Conexao.conecta();

            MySqlCommand cm = con.CreateCommand();

            try
            {
                cm.CommandText = @"select * from tb_contatos";

                con.Open();

                cm.Connection = con;

                MySqlDataReader dr;
                dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    Contato contato = new();

                    contato.Id = Convert.ToInt32(dr["id"]);
                    contato.Name = Convert.ToString(dr["nomecontato"]);
                    contato.Email = Convert.ToString(dr["email"]);
                    contato.Fone = Convert.ToString(dr["fone"]);

                    contatos.Add(contato);
                }
            }
            finally 
            { 
                if(con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }           

            return contatos;
        }

        public void deletar(Contato contato)
        {
            MySqlConnection con = new();

            con.ConnectionString = Dados.Conexao.conecta();

            MySqlCommand cm = con.CreateCommand();

            try
            {
                con.Open();

                cm.CommandText = @"delete from tb_contatos where id = @id";

                cm.Parameters.Add("id", MySqlDbType.VarChar).Value = contato.Id;

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

        public bool editar(Contato contato)
        {
            MySqlConnection con = new();

            con.ConnectionString = Dados.Conexao.conecta();

            MySqlCommand cm = con.CreateCommand();

            try
            {
                con.Open();

                cm.CommandText = @"update tb_contatos set nomecontato = @nome, email = @email, fone = @fone where id = @id";

                cm.Parameters.Add("id", MySqlDbType.VarChar).Value = contato.Id;
                cm.Parameters.Add("nome", MySqlDbType.VarChar).Value = contato.Name;
                cm.Parameters.Add("email", MySqlDbType.VarChar).Value = contato.Email;
                cm.Parameters.Add("fone", MySqlDbType.VarChar).Value = contato.Fone;

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

        public bool salvar(Contato contato)
        {
            MySqlConnection con = new();

            con.ConnectionString = Dados.Conexao.conecta();

            MySqlCommand cm =  con.CreateCommand();

            try
            {
                con.Open();

                cm.CommandText = @"insert into tb_contatos(nomecontato, email, fone)values(@nome, @email, @fone)";

                cm.Parameters.Add("nome", MySqlDbType.VarChar).Value = contato.Name;
                cm.Parameters.Add("email", MySqlDbType.VarChar).Value = contato.Email;
                cm.Parameters.Add("fone", MySqlDbType.VarChar).Value = contato.Fone;

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
