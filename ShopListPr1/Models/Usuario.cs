using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopListPr1.Models
{
    internal class Usuario

    {
        public int id_usuario { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public string datadenascimento { get; set; }        
        public string telefone { get; set; }
        public string cpf { get; set; }



        public Usuario()
        {

        }

        public Usuario(string _nome,
                        string _email,
                        string _senha,
                        string _datadenascimento,
                        string _telefone,
                        string _cpf
                        )
         {
            nome = _nome;
            email = _email;
            senha = _senha;
            datadenascimento = _datadenascimento;
            telefone = _telefone;
            cpf = _cpf;



        }

    }
}
