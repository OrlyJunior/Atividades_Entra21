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
                cm.CommandText = @"select tb_compromissos.id, descricao, data, status, contatoId, localId, tb_contatos.id, nomecontato, rua, bairro, numero, estado, cep, cidade, email, fone, tb_locais.id, nomelocal from tb_compromissos, tb_contatos, tb_locais where tb_compromissos.contatoId = tb_contatos.Id and tb_compromissos.localId = tb_locais.id";

                con.Open();

                cm.Connection = con;

                MySqlDataReader dr;
                dr = cm.ExecuteReader();

                while (dr.Read())
                {
                    Compromisso compromisso = new Compromisso();

                    compromisso.ContatoC = new();
                    compromisso.LocalC = new();

                    compromisso.Id = Convert.ToInt32(dr["id"]);
                    compromisso.Descricao = Convert.ToString(dr["descricao"]);
                    compromisso.DataHora = Convert.ToDateTime(dr["data"]);

                    compromisso.Data = $"{Convert.ToString(compromisso.DataHora.Day)}/" +
                        $"{Convert.ToString(compromisso.DataHora.Month)}/" +
                        $"{Convert.ToString(compromisso.DataHora.Year)}";

                    compromisso.Hora = Convert.ToString(compromisso.DataHora.TimeOfDay);

                    compromisso.ContatoC.Id = Convert.ToInt32(dr["contatoId"]);
                    compromisso.ContatoC.Name = Convert.ToString(dr["nomecontato"]);
                    compromisso.ContatoC.Email = Convert.ToString(dr["email"]);
                    compromisso.ContatoC.Fone = Convert.ToString(dr["fone"]);

                    compromisso.LocalC.Id = Convert.ToInt32(dr["localId"]);
                    compromisso.LocalC.Nome = Convert.ToString(dr["nomelocal"]);
                    compromisso.LocalC.Rua = Convert.ToString(dr["rua"]);
                    compromisso.LocalC.Bairro = Convert.ToString(dr["bairro"]);
                    compromisso.LocalC.Numero = Convert.ToInt32(dr["numero"]);
                    compromisso.LocalC.Cidade = Convert.ToString(dr["cidade"]);
                    compromisso.LocalC.Cep = Convert.ToString(dr["cep"]);
                    compromisso.LocalC.Estado = Convert.ToString(dr["estado"]);

                    compromisso.Status = Convert.ToString(dr["status"]);

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

                cm.CommandText = @"insert into tb_compromissos(descricao, data, contatoId, localId, status)values(@descricao, @data, @contato, @local, @status)";

                cm.Parameters.Add("descricao", MySqlDbType.VarChar).Value = compromisso.Descricao;
                cm.Parameters.Add("data", MySqlDbType.DateTime).Value = compromisso.DataHora;
                cm.Parameters.Add("contato", MySqlDbType.Int32).Value = compromisso.ContatoC.Id;
                cm.Parameters.Add("local", MySqlDbType.Int32).Value = compromisso.LocalC.Id;
                cm.Parameters.Add("status", MySqlDbType.VarChar).Value = compromisso.Status;

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
