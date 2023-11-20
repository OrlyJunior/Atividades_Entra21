using AcessaBancoDeDados.Entidades;
using System.Data;
using System.Data.SqlClient;

namespace AcessaBancoDeDados.Dao
{


    public class DaoContato
    {
        List<Contato> contatos = new();

        public bool salvar(Contato contato)
        {
            using (SqlConnection con = new())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Contatos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlCommand cn = new();

                cn.CommandType = CommandType.Text;

                cn.CommandText = "insert into tb_contatos([Nome], [Número], [Cidade]) values(@nome, @numero, @cidade)";

                cn.Parameters.Add("nome", SqlDbType.VarChar).Value = contato.Nome;
                cn.Parameters.Add("numero", SqlDbType.VarChar).Value = contato.Numero;
                cn.Parameters.Add("cidade", SqlDbType.VarChar).Value = contato.Cidade;

                con.Open();

                cn.Connection = con;

                return cn.ExecuteNonQuery() > 0;
            }
        }

        public bool consultar()
        {
            using (SqlConnection con = new())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Contatos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlCommand cn = new();

                con.Open();

                cn.CommandType = CommandType.Text;

                cn.CommandText = "select * from tb_contatos";

                cn.Connection = con;

                SqlDataReader dr;

                dr = cn.ExecuteReader();

                while (dr.Read())
                {
                    Contato ct = new();

                    int idAnt = Convert.ToInt32(dr["ID"]);

                    ct.Id = Convert.ToInt32(dr["Id"]);
                    ct.Nome = Convert.ToString(dr["Nome"]);
                    ct.Numero = Convert.ToString(dr["Número"]);
                    ct.Cidade = Convert.ToString(dr["Cidade"]);

                    contatos.Add(ct);
                }

                foreach (Contato i in contatos)
                {
                    Console.WriteLine(i.toString());
                }

                Console.WriteLine();

                return true;
            }
        }

        public bool consultaId()
        {
            using (SqlConnection con = new())
            {
                Console.WriteLine("Qual id quer consultar?");
                int id = int.Parse(Console.ReadLine());

                Console.WriteLine();

                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Contatos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlCommand cn = new();

                con.Open();

                cn.CommandType = CommandType.Text;

                cn.CommandText = "select * from tb_contatos";

                cn.Connection = con;

                SqlDataReader dr;

                dr = cn.ExecuteReader();

                while (dr.Read())
                {
                    if (Convert.ToInt32(dr["Id"]) == id)
                    {
                        Contato ct = new();

                        ct.Id = Convert.ToInt32(dr["Id"]);
                        ct.Nome = Convert.ToString(dr["Nome"]);
                        ct.Numero = Convert.ToString(dr["Número"]);
                        ct.Cidade = Convert.ToString(dr["Cidade"]);

                        Console.WriteLine(ct.toString());

                        break;
                    }
                }

                Console.WriteLine();

                return true;
            }
        }

        public bool deletar()
        {
            using (SqlConnection con = new())
            {
                Console.WriteLine("Qual id deseja apagar?");
                int id = int.Parse(Console.ReadLine());

                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Contatos;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlCommand cn = new();

                cn.CommandType = CommandType.Text;

                cn.CommandText = $"delete from tb_contatos where Id = {id}";

                con.Open();

                cn.Connection = con;

                return cn.ExecuteNonQuery() > 0;
            }
        }
    }
}