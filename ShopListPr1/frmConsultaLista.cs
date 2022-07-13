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
    public partial class frmConsultaLista : Form
    {        
        ListaController listaController = new ListaController();
        public frmConsultaLista()
        {
            InitializeComponent();
            
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            (dgvLista.DataSource as DataTable).DefaultView.RowFilter = String.IsNullOrEmpty(txtFiltro.Text) ? "" : $"produto LIKE '%{txtFiltro.Text}%' ";

            bool status = dgvLista.Rows.Count < 1 ? false : true;
            btnEditar.Enabled = status;
            btnExcluir.Enabled = status;
        }

      

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deseja excluir o Produto selecionado?", "Excluir", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                Lista lista = new Lista();
                lista.email = Properties.Settings.Default.email;
                lista.idproduto = Convert.ToInt32(dgvLista.SelectedRows[0].Cells[0].Value);
                bool resultado = listaController.deletarProduto(lista);

                if (resultado)
                {
                    MessageBox.Show("Produto Excluido com Sucesso", "Excluido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dgvLista.DataSource = listaController.exibirProdutos(lista);
                    dgvLista.Refresh();
                }
                else
                {
                    MessageBox.Show("Falha ao excluir", "Falha", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       
        private Lista produtoSelecionado()
        {
            Lista list = new Lista();
            list.idproduto = Convert.ToInt32(dgvLista.SelectedRows[0].Cells[0].Value);
            list.email = dgvLista.SelectedRows[0].Cells[1].Value.ToString();
            list.produto = dgvLista.SelectedRows[0].Cells[2].Value.ToString();
            list.preco = Convert.ToDouble(dgvLista.SelectedRows[0].Cells[3].Value.ToString());
            list.quantidade = Convert.ToInt32(dgvLista.SelectedRows[0].Cells[4].Value.ToString());
            list.total = Convert.ToDouble(dgvLista.SelectedRows[0].Cells[5].Value.ToString());
            
            return list;

        }

        

        private void frmConsultaLista_Load(object sender, EventArgs e)
        {
            Lista lista = new Lista();
            lista.email = Properties.Settings.Default.email;
            dgvLista.DataSource = listaController.exibirProdutos(lista);

            
            dgvLista.Columns[0].Width = 50;
            dgvLista.Columns[1].Width = 150;
            dgvLista.Columns[2].Width = 80;
            dgvLista.Columns[3].Width = 80;
            dgvLista.Columns[4].Width = 80;
            dgvLista.Columns[5].Width = 75;
            

            dgvLista.Columns[0].HeaderText = "ID";
            dgvLista.Columns[1].HeaderText = "Email";
            dgvLista.Columns[2].HeaderText = "Produto";
            dgvLista.Columns[3].HeaderText = "Preço";
            dgvLista.Columns[4].HeaderText = "Quantidade";
            dgvLista.Columns[5].HeaderText = "Total";
            

        }

            private void btnEditar_Click(object sender, EventArgs e)
             {
                 frmCadastroProduto produto = new frmCadastroProduto(produtoSelecionado());
                 produto.ShowDialog();
             }

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            Lista lista = new Lista();
            lista.email = Properties.Settings.Default.email;
            frmCadastroProduto cadastroProduto = new frmCadastroProduto(produtoSelecionado());
            cadastroProduto.ShowDialog();

            dgvLista.BeginInvoke((MethodInvoker)delegate ()
            {
                txtFiltro.Clear();
                dgvLista.DataSource = listaController.exibirProdutos(lista);
                dgvLista.Refresh();
            });
        }
    }
}

