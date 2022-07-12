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
    public partial class frmCadastroUsuario : Form
    {
        public frmCadastroUsuario()
        {
            InitializeComponent();
        }

        private void txtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Usuario user = new Usuario(
                txtNome.Text,
                txtEmail.Text,
                txtSenha.Text,
                txtNascimento.Text,
                txtTelefone.Text,
                txtCpf.Text
                );


            UsuarioController usuarioController = new UsuarioController();
            bool verifica = usuarioController.salvarUsuario(user);

            if (verifica == true)
            {
                MessageBox.Show("Usuário cadastrado com sucesso.", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (MessageBox.Show("Deseja continuar cadastrando?", "Cadastro", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
                MessageBox.Show("Falha ao cadastrar o usuário.", "Cadastro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpar_Click(object sender, EventArgs e)
        {
            LimpaCampos();
        }
        private void LimpaCampos()
        {
          
            txtNome.Text = "";
            txtSenha.Text = "";
            txtCpf.Text = "";
            txtNascimento.Text = "";
            txtTelefone.Text = "";
            txtEmail.Text = "";
            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja cancelar o cadastro?", "Cancelar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Dispose();
            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
