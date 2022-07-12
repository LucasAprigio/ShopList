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
    public class ListaController
    {
        MySqlConnection conexao = new MySqlConnection();

        public ListaController()
        {
            conexao = Conexao.abrirConexao();
            
        }
        public bool salvarLista(Lista Lista)
        {
            try
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("INSERT INTO lista (email,produto,preco,quantidade,total)" +
                                                    "VALUES (@email,@produto,@preco,@quantidade,@total)", conexao);
               
                cmd.Parameters.AddWithValue("@email", Lista.email);
                cmd.Parameters.AddWithValue("@produto", Lista.produto);
                cmd.Parameters.AddWithValue("@preco", Lista.preco);
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
        public DataTable exibirProdutos(Lista lista)
        {
            DataTable dt = new DataTable();
           
            try
            {
                conexao.Open();

                MySqlCommand cmd = new MySqlCommand("SELECT idproduto,email,produto,preco,quantidade,total FROM lista WHERE email = @email", conexao);
                cmd.Parameters.AddWithValue("@email",lista.email);
                MySqlDataReader reader = cmd.ExecuteReader();
                dt.Load(reader);
                return dt;
            }
            catch (Exception)
            {

                return dt;
            }
            finally
            {
                conexao.Close();
            }

        }
        public bool deletarProduto(Lista list)
        {
            try
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("DELETE FROM lista WHERE idproduto = @idproduto", conexao);
                cmd.Parameters.AddWithValue("@idproduto", list.idproduto);
                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
            {

                return false;
            }
            finally
            {
                conexao.Close();
            }
        }
        public bool editarProduto(Lista list)
        {
            try
            {
                conexao.Open();
                MySqlCommand cmd = new MySqlCommand("UPDATE lista SET " +
                                                    "produto=@produto," +
                                                    "preco=@preco," +
                                                    "quantidade=@quantidade," +
                                                    "total=@total " +
                                                    "WHERE idproduto=@idproduto", conexao);
                cmd.Parameters.AddWithValue("idproduto", list.idproduto);
                cmd.Parameters.AddWithValue("@produto", list.produto);
                cmd.Parameters.AddWithValue("@quantidade", list.quantidade);
                cmd.Parameters.AddWithValue("@preco", list.preco);
                cmd.Parameters.AddWithValue("@total", list.total);

                cmd.ExecuteNonQuery();
                return true;

            }
            catch (Exception)
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
