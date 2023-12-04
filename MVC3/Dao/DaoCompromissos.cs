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
                cm.CommandText = @"select tb_compromissos.id, descricao, data, contato, tb_contatos.id, nomecontato, tb_locais.id, nomelocal from tb_compromissos, tb_contatos, tb_locais";

                con.Open();

                cm.Connection = con;

                MySqlDataReader dr;
                dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    Compromisso compromisso = new Compromisso();

                    compromisso.Id = Convert.ToInt32(dr["id"]);
                    compromisso.Descricao = Convert.ToString(dr["descricao"]);
                    compromisso.DataHora = Convert.ToDateTime(dr["data"]);
                    compromisso.ContatoC.Id = Convert.ToInt32(dr["tb_contatos.id"]);
                    compromisso.LocalC.Id = Convert.ToInt32(dr["tb_locais.id"]);
                    compromisso.ContatoC.Name = Convert.ToString(dr["tb_contatos.nomecontato"]);
                    compromisso.LocalC.Nome = Convert.ToString(dr["tb_locais.nomelocal"]);

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
                cm.Parameters.Add("contato", MySqlDbType.Int32).Value = compromisso.ContatoC.Id;
                cm.Parameters.Add("local", MySqlDbType.Int32).Value = compromisso.LocalC.Id;

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
