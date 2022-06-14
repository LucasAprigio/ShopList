using MySql.Data.MySqlClient;
using ShopListPr1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopListPr1.Controllers
{
    internal class UsuarioController
    {
        
        MySqlConnection conexao = new MySqlConnection();

            public UsuarioController()
            {
                conexao = Conexao.abrirConexao();
                conexao.Open();
            }

            public bool salvarUsuario(Usuario user)
            {
                try
                {
                    MySqlCommand cmd = new MySqlCommand("INSERT INTO usuario (nome,email,senha,datadenascimento,cpf,telefone)" +
                                                        "VALUES (@nome,@email,@senha,@datadenascimento,@cpf,@telefone)", conexao);

                    cmd.Parameters.AddWithValue("@nome", user.nome);
                    cmd.Parameters.AddWithValue("@email", user.email);
                    cmd.Parameters.AddWithValue("@senha", user.senha);                   
                    cmd.Parameters.AddWithValue("@datadenascimento", user.datadenascimento);
                    cmd.Parameters.AddWithValue("@cpf", user.cpf);
                    cmd.Parameters.AddWithValue("@telefone", user.telefone);

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
