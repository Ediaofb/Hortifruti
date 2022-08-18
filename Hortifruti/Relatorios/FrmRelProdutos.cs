using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hortifruti.Relatorios
{
    public partial class FrmRelProdutos : Form
    {
        public FrmRelProdutos()
        {
            InitializeComponent();
        }

        private void FrmRelProdutos_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hortifruti_dbDataSet5.Produto'. Você pode movê-la ou removê-la conforme necessário.
            this.produtoTableAdapter2.Fill(this.hortifruti_dbDataSet5.Produto, "");           
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btn_consult_rel_vendas_Click(object sender, EventArgs e)
        {
            this.produtoTableAdapter2.Fill(this.hortifruti_dbDataSet5.Produto, tb_produtos.Text);
            this.reportViewer1.RefreshReport();
        }
    }
}
