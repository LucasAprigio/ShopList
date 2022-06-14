using MySql.Data.MySqlClient;
using ShopListPr1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopListPr1.Controllers
{
    internal class LoginController
    {
        MySqlConnection conexao = new MySqlConnection();
        public LoginController()
        {
            conexao = Conexao.abrirConexao();
            conexao.Open();
        }

        public DataTable fazerLogin(Usuario user)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM usuario WHERE email=@email AND senha=@senha", conexao);
                cmd.Parameters.AddWithValue("@email", user.email);
                cmd.Parameters.AddWithValue("@senha", user.senha);

                MySqlDataReader dr = cmd.ExecuteReader();

                DataTable dt = new DataTable();
                dt.Load(dr);
                return dt;

            }
            catch (MySqlException)
            {
                return null;
            }
            finally
            {
                conexao.Close();
            }

        }
    }

    
}
