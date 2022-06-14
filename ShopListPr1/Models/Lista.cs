using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopListPr1.Models
{
    internal class Lista
    {
        public int idproduto { get; set; }
        public string email { get; set; }
        public string produto { get; set; }
        public string preco { get; set; }
        public int quantidade { get; set; }
        public string total { get; set; }
        public Lista()
        {

        }

        public Lista    (string _email,
                        string _produto,
                        string _preco,
                        int _quantidade,
                        string _total)
                                          
        {
            email = _email;
            produto = _produto;
            preco = _preco;
            quantidade = _quantidade;
            total = _total;
        }

    }
}
