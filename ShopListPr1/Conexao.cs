using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopListPr1
{
    internal class Conexao
    {
        static string server = "localhost";
        static string port = "3306";
        static string username = "root";
        static string password = "";
        static string database = "dbshoplist";

        public static MySqlConnection abrirConexao()
        {
            MySqlConnection conexao = new MySqlConnection();

            try
            {
                conexao = new MySqlConnection($"server={server};port={port};username={username};password={password};database={database}") ;
                return conexao;
            }
            catch (MySqlException)
            {
                return null;
               
            }
        }
    }
}
