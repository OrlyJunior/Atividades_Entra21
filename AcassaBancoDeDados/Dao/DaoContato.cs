using AcessaBancoDeDados.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessaBancoDeDados.Dao
{
    public class DaoContato
    {
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

                    ct.Id = Convert.ToInt32(dr["Id"]);
                    ct.Nome = Convert.ToString(dr["Nome"]);
                    ct.Numero = Convert.ToString(dr["Número"]);
                    ct.Cidade = Convert.ToString(dr["Cidade"]);

                    Console.WriteLine(ct.toString());
                }

                Console.WriteLine();

                return true;
            }
        }
    }
}