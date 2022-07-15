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
    public partial class frmLogin : Form
    {


        public frmLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLogar_Click(object sender, EventArgs e)
        {
            LoginController Login = new LoginController();
            Usuario user = new Usuario();
            user.email = txtLogin.Text;
            user.senha = txtSenha.Text;

            DataTable result = Login.fazerLogin(user);

            if (result.Rows.Count > 0)
            {
                MessageBox.Show("Logado com sucesso!", "Logado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Properties.Settings.Default.nome = result.Rows[0]["nome"].ToString();
                Properties.Settings.Default.email = result.Rows[0]["email"].ToString();
                frmMenu menu = new frmMenu();
                menu.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }





        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtSenha_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txtSenha_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmLogin_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }
    }
}
