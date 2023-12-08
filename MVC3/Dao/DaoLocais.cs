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
                    local.Cep = Convert.ToString(dr["cep"]);
                    local.Estado = Convert.ToString(dr["estado"]);

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

                cm.CommandText = @"update tb_locais set nomelocal = @Nome, rua = @rua, bairro = @bairro, cidade = @cidade, numero = @numero, cep = @cep, estado = @uf where id = @id";

                cm.Parameters.Add("id", MySqlDbType.Int32).Value = local.Id;
                cm.Parameters.Add("Nome", MySqlDbType.VarChar).Value = local.Nome;
                cm.Parameters.Add("rua", MySqlDbType.VarChar).Value = local.Rua;
                cm.Parameters.Add("numero", MySqlDbType.Int32).Value = local.Numero;
                cm.Parameters.Add("bairro", MySqlDbType.VarChar).Value = local.Bairro;
                cm.Parameters.Add("cidade", MySqlDbType.VarChar).Value = local.Cidade;
                cm.Parameters.Add("CEP", MySqlDbType.VarChar).Value = local.Cep;
                cm.Parameters.Add("uf", MySqlDbType.VarChar).Value = local.Estado;

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

        public bool salvar(Local local)
        {
            MySqlConnection con = new();

            con.ConnectionString = Dados.Conexao.conecta();

            MySqlCommand cm = con.CreateCommand();

            try
            {
                con.Open();

                cm.CommandText = @"insert into tb_locais(nomelocal, rua, numero, bairro, cidade, cep, estado)values(@nomelocal, @rua, @numero, @bairro, @cidade, @CEP, @uf)";

                cm.Parameters.Add("nomelocal", MySqlDbType.VarChar).Value = local.Nome;
                cm.Parameters.Add("rua", MySqlDbType.VarChar).Value = local.Rua;
                cm.Parameters.Add("numero", MySqlDbType.Int32).Value = local.Numero;
                cm.Parameters.Add("bairro", MySqlDbType.VarChar).Value = local.Bairro;
                cm.Parameters.Add("cidade", MySqlDbType.VarChar).Value = local.Cidade;
                cm.Parameters.Add("CEP", MySqlDbType.VarChar).Value = local.Cep;
                cm.Parameters.Add("uf", MySqlDbType.VarChar).Value = local.Estado;

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
