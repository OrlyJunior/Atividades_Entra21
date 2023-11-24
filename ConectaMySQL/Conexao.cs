using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ConectaMySQL
{
    class Conexao
    {
        public static MySqlConnection conecta()
        {
            string connString = @"Server=localhost;Database=produtos;Uid=root;Pwd=123456";
            MySqlConnection connection = new MySqlConnection(connString);
            return connection;
        }
    }
}
