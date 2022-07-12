using ShopListPr1.Controllers;
using ShopListPr1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShopListPr1
{
    public partial class frmCadastroProduto : Form
    {
       
        Lista lista = new Lista();

        public frmCadastroProduto()
        {
            InitializeComponent();
            txtEmail.Text = Properties.Settings.Default.email;
        }

        public frmCadastroProduto(Lista list)
        {
            InitializeComponent();

            lista = list;
            carregarEditar();
        }

        private void carregarEditar()
        {
            btnCadastrar.Visible = false;
            btnLimpar.Visible = false;
            btnSalvar.Visible = true;

            txtEmail.Text = lista.email;
            txtProduto.Text = lista.produto;
            Convert.ToInt32(txtQuantidade.Text = lista.quantidade.ToString());
            Convert.ToDouble(txtPreco.Text = lista.preco.ToString());
            Convert.ToDouble(txtTotal.Text = lista.total.ToString());
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        
        private void frmCadastroProduto_Load(object sender, EventArgs e)
        {

        }



        private void btnEnviar_Click(object sender, EventArgs e)
        {
            double total = Convert.ToDouble(txtPreco.Text) * Convert.ToInt32(txtQuantidade.Text);

            Lista lista = new Lista(
                    Properties.Settings.Default.email,
                    txtProduto.Text,
                    Convert.ToDouble(txtPreco.Text.ToString()),
                    Convert.ToInt32(txtQuantidade.Text.ToString()),
                    Convert.ToDouble(total.ToString()));


            txtTotal.Text = total.ToString();

            ListaController listaController = new ListaController();
            bool verifica = listaController.salvarLista(lista);


            if (!VereficaQuantidade(Convert.ToInt32(txtQuantidade.Text)))
            {
                MessageBox.Show("Não é possivel cadastrar produtos negativo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (verifica == true)
                {
                    MessageBox.Show("Produto cadastrado com sucesso.", "Cadastro do produto", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    if (MessageBox.Show("Deseja continuar cadastrando o seu Produto?", "Cadastro do produto", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        LimpaCampos();
                    }
                    else
                    {
                        Close();
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao cadastrar o Produto.", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnResetar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }

        private void LimpaCampos()
        {
            txtProduto.Text = "";
            txtPreco.Text = "";
            txtQuantidade.Text = "";
            txtTotal.Text = "";

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja cancelar o cadastro do seu produto?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private bool VereficaQuantidade(int Quantidade)
        {
            if (Quantidade <= 0)
            {
                return false;
            }
            return true;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            lista.email = txtEmail.Text;
            lista.produto = txtProduto.Text;
            lista.quantidade = Convert.ToInt32(txtQuantidade.Text.ToString());
            lista.preco = Convert.ToDouble(txtPreco.Text.ToString());
            lista.total = Convert.ToDouble(txtTotal.Text.ToString());


            ListaController listaController = new ListaController();
            bool resultado = listaController.editarProduto(lista);

            if (resultado)
            {
                MessageBox.Show("Produto atualizado com sucesso", "Atualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Falha ao atualizar o Produto", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
    
}
