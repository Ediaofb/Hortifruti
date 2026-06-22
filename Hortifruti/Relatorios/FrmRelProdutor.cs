using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Hortifruti.Relatorios
{
    public partial class FrmRelProdutor : Form
    {
        public FrmRelProdutor()
        {
            InitializeComponent();
        }

        public void CarregarRelatorio(string nomeProdutor)
        {
            try
            {
                string sql = @"
                    SELECT *
                    FROM Produtor
                    WHERE Nome LIKE @nome
                    ORDER BY Nome";

                using (SqlConnection conexao = Conexao.CriarConexao())
                using (SqlCommand comando = new SqlCommand(sql, conexao))
                using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                {
                    comando.Parameters.AddWithValue("@nome", "%" + nomeProdutor + "%");

                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);

                    reportViewer1.LocalReport.DataSources.Clear();

                    ReportDataSource rds = new ReportDataSource("DataSet2", tabela);
                    reportViewer1.LocalReport.DataSources.Add(
                        new Microsoft.Reporting.WinForms.ReportDataSource("DataSet2", tabela)
                    );

                    reportViewer1.LocalReport.ReportEmbeddedResource = "Hortifruti.Relatorios.RelProdutor.rdlc";
                    reportViewer1.RefreshReport();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void FrmrRelProdutorcs_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hortifruti_dbDataSet6.Produtor'. Você pode movê-la ou removê-la conforme necessário.
            /*this.produtorTableAdapter.Fill(this.hortifruti_dbDataSet6.Produtor, "");
            this.reportViewer1.RefreshReport(); */
            CarregarRelatorio("");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hortifruti_dbDataSet.Produtor'. Você pode movê-la ou removê-la conforme necessário.
            /* this.produtorTableAdapter.Fill(this.hortifruti_dbDataSet6.Produtor, tb_produtor.Text);
             this.reportViewer1.RefreshReport(); */
            CarregarRelatorio(tb_produtor.Text);
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
