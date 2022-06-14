using MySql.Data.MySqlClient;
using ShopListPr1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopListPr1.Controllers
{
    internal class ListaController
    {
        MySqlConnection conexao = new MySqlConnection();

             public ListaController()
             {
                conexao = Conexao.abrirConexao();
                conexao.Open();
              }
        public bool salvarLista(Lista Lista)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("INSERT INTO lista (produto,preco,email,quantidade,total)" +
                                                    "VALUES (@produto,@preco,@email,@quantidade,@total)", conexao);

                cmd.Parameters.AddWithValue("@produto", Lista.produto);
                cmd.Parameters.AddWithValue("@preco", Lista.preco);
                cmd.Parameters.AddWithValue("@email", Lista.email);
                cmd.Parameters.AddWithValue("@quantidade", Lista.quantidade);
                cmd.Parameters.AddWithValue("@total", Lista.total);

                cmd.ExecuteNonQuery();

                return true;
            }
            catch (MySqlException)
            {
                return false;

            }
            finally
            {
                conexao.Close();
            }
        }
    }
}
