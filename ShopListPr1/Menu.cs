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
    public partial class frmMenu : Form
    {
        public frmMenu()
        {
            InitializeComponent();
            usuarioLogado.Text = Properties.Settings.Default.nome;
        }

        private void toolStripStatusLabel2_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {
            
            
        }

        private void cadastroDeUsuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroUsuario CadastroUsuario = new frmCadastroUsuario();
            CadastroUsuario.ShowDialog();
           
        }

        private void listaDeComprasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmCadastroProduto cadastroProduto = new frmCadastroProduto();
            cadastroProduto.ShowDialog();
            
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void logOffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dispose();
            frmLogin login = new frmLogin();
            login.ShowDialog();

        }

        private void toolStripStatusLabel3_Click(object sender, EventArgs e)
        {

        }

        private void frmMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void arquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void relatorioListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRelatorioLista relatorioLista = new frmRelatorioLista();
            relatorioLista.ShowDialog();    
        }

        private void consultaListaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmConsultaLista consultaLista = new frmConsultaLista();
            consultaLista.ShowDialog();
        }
    }
}
