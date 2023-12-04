using MVC3.Interfaces;
using MVC3.Models;
using MySql.Data.MySqlClient;

namespace MVC3.Dao
{
    public class DaoLocais : ICrud<Local>
    {
        public Local consultar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Local> consultar()
        {
            List<Local> locais = new();

            MySqlConnection con = new();

            con.ConnectionString = Dados.Conexao.conecta();

            MySqlCommand cm = con.CreateCommand();

            try
            {
                cm.CommandText = @"select * from tb_locais";

                con.Open();

                cm.Connection = con;

                MySqlDataReader dr;
                dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    Local local = new();

                    local.Id = Convert.ToInt32(dr["id"]);
                    local.Nome = Convert.ToString(dr["nomelocal"]);
                    local.Rua = Convert.ToString(dr["rua"]);
                    local.Numero = Convert.ToInt32(dr["numero"]);
                    local.Bairro = Convert.ToString(dr["bairro"]);
                    local.Cidade = Convert.ToString(dr["cidade"]);
                    local.Cep = Convert.ToString(dr["CEP"]);
                    local.Estado = Convert.ToString(dr["uf"]);

                    locais.Add(local);
                }
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return locais;
        }

        public void deletar(Local local)
        {
            MySqlConnection con = new();

            con.ConnectionString = Dados.Conexao.conecta();

            MySqlCommand cm = con.CreateCommand();

            try
            {
                con.Open();

                cm.CommandText = @"delete from tb_locais where id = @id";

                cm.Parameters.Add("id", MySqlDbType.VarChar).Value = local.Id;

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

        public bool editar(Local local)
        {
            MySqlConnection con = new();

            con.ConnectionString = Dados.Conexao.conecta();

            MySqlCommand cm = con.CreateCommand();

            try
            {
                con.Open();

                cm.CommandText = @"update tb_contatos set nomelocal = @nome, rua = @rua, bairro = @bairro, cidade = @cidade, numero = @numero, CEP = @cep, uf = @estado where id = @id";

                cm.Parameters.Add("id", MySqlDbType.VarChar).Value = local.Id;
                cm.Parameters.Add("nome", MySqlDbType.VarChar).Value = local.Nome;
                cm.Parameters.Add("email", MySqlDbType.VarChar).Value = local.Email;
                cm.Parameters.Add("fone", MySqlDbType.VarChar).Value = local.Fone;

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

        public bool salvar(Local contato)
        {
            MySqlConnection con = new();

            con.ConnectionString = Dados.Conexao.conecta();

            MySqlCommand cm = con.CreateCommand();

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
