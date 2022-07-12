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
    public partial class frmRelatorioLista : Form
    {
        public frmRelatorioLista()
        {
            InitializeComponent();
        }

        private void frmRelatorioLista_Load(object sender, EventArgs e)
        {
            Lista lista = new Lista();
            lista.email = Properties.Settings.Default.email;
            ListaController listaController = new ListaController(); 
            this.reportViewer1.LocalReport.DataSources.Clear();
            this.reportViewer1.LocalReport.DataSources.Add(
            new Microsoft.Reporting.WinForms.ReportDataSource("Lista", listaController.exibirProdutos(lista))
            );
            this.reportViewer1.RefreshReport();

        }
    }
}
