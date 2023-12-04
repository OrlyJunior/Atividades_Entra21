using MVC3.Interfaces;
using MVC3.Models;
using MySql.Data.MySqlClient;

namespace MVC3.Dao
{
    public class DaoCompromissos : ICrud<Compromisso>
    {
        public Compromisso consultar(int id)
        {
            throw new NotImplementedException();
        }

        public List<Compromisso> consultar()
        {
            List<Compromisso> compromissos = new();

            MySqlConnection con = new();

            con.ConnectionString = Dados.Conexao.conecta();

            MySqlCommand cm = con.CreateCommand();

            try
            {
                cm.CommandText = @"select * from tb_compromissos";

                con.Open();

                cm.Connection = con;

                MySqlDataReader dr;
                dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    Compromisso compromisso = new();

                    compromisso.Id = Convert.ToInt32(dr["id"]);
                    compromisso.Descricao = Convert.ToString(dr["descricao"]);
                    compromisso.DataHora = Convert.ToDateTime(dr["data"]);
                    compromisso.Contato.Id = Convert.ToInt32(dr["contato"]);
                    compromisso.Local.Id = Convert.ToInt32(dr["local"]);

                    compromissos.Add(compromisso);
                }
            }
            finally
            {
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
            }

            return compromissos;
        }

        public void deletar(Compromisso t)
        {
            throw new NotImplementedException();
        }

        public bool editar(Compromisso t)
        {
            throw new NotImplementedException();
        }

        public bool salvar(Compromisso compromisso)
        {
            MySqlConnection con = new();

            con.ConnectionString = Dados.Conexao.conecta();

            MySqlCommand cm = con.CreateCommand();

            try
            {
                con.Open();

                cm.CommandText = @"insert into tb_compromissos(descricao, data, contato, local)values(@descricao, @data, @contato, @local)";

                cm.Parameters.Add("descricao", MySqlDbType.VarChar).Value = compromisso.Descricao;
                cm.Parameters.Add("data", MySqlDbType.DateTime).Value = compromisso.DataHora;
                cm.Parameters.Add("contato", MySqlDbType.Int32).Value = compromisso.Contato.Id;
                cm.Parameters.Add("local", MySqlDbType.Int32).Value = compromisso.Local.Id;

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
