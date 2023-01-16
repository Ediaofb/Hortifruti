using System;
using System.Windows.Forms;

namespace Hortifruti.Relatorios
{
    public partial class FrmRelProdutor : Form
    {
        public FrmRelProdutor()
        {
            InitializeComponent();
        }

        private void FrmrRelProdutorcs_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hortifruti_dbDataSet6.Produtor'. Você pode movê-la ou removê-la conforme necessário.
            this.produtorTableAdapter.Fill(this.hortifruti_dbDataSet6.Produtor, "");
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hortifruti_dbDataSet.Produtor'. Você pode movê-la ou removê-la conforme necessário.
            this.produtorTableAdapter.Fill(this.hortifruti_dbDataSet6.Produtor, tb_produtor.Text);
            this.reportViewer1.RefreshReport();
        }
    }
}
