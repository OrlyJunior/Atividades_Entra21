using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProdutosBD 
{
    class CrudCategorias : ICrud<Categoria>
    {
        public bool add()
        {
            Categoria cat = new Categoria();

            Console.WriteLine("Insira o nome da categoria que deseja adicionar:");
            cat.Nome = Console.ReadLine();

            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
                
                con.Open();

                SqlCommand sc = new SqlCommand();

                sc.CommandType = CommandType.Text;

                sc.CommandText = "insert into tb_categorias([Nome])values(@Nome)";

                sc.Parameters.Add("Nome", SqlDbType.NChar).Value = cat.Nome;

                sc.Connection = con;

                return sc.ExecuteNonQuery() > 0;
            }
        }

        public bool alterar()
        {
            throw new NotImplementedException();
        }

        public List<Categoria> consultar(List<Categoria> t)
        {
            using (SqlConnection con = new SqlConnection())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

                con.Open();

                SqlCommand sc = new SqlCommand();

                sc.CommandType = CommandType.Text;

                sc.CommandText = "select * from tb_categorias";

                sc.Connection = con;

                SqlDataReader sr;
                sr = sc.ExecuteReader();

                while (sr.Read())
                {
                    Categoria categ = new();

                    categ.Id = Convert.ToInt32(sr["Id"]);
                    categ.Nome = Convert.ToString(sr["Nome"]);

                    t.Add(categ);
                }

                return t;
            }
        }

        public bool mostrar(List<Categoria> t)
        {
            foreach(Categoria i in t)
            {
                Console.WriteLine(i.toString());
            }

            return true;
        }

        public bool consultarCategoria(List<Categoria> t)
        {
            Console.WriteLine("Qual o id da categoria que deseja consultar?");
            int id = int.Parse(Console.ReadLine());

            using (SqlConnection con = new())
            {
                con.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Produtos;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

                con.Open();

                SqlCommand sc = new();

                sc.CommandType = CommandType.Text;

                sc.CommandText = @"select * from tb_categorias";

                sc.Connection = con;

                SqlDataReader sr;
                sr = sc.ExecuteReader();

                while(sr.Read())
                {
                    if (Convert.ToInt32(sr["Id"]) == id)
                    {
                        Categoria category = new();

                        category.Id = Convert.ToInt32(sr["Id"]);
                        category.Nome = Convert.ToString(sr["Nome"]);

                        t.Add(category);

                        break;
                    }
                }
            }

            return true;
        }

        public bool deletar()
        {
            throw new NotImplementedException();
        }

        
    }
}
