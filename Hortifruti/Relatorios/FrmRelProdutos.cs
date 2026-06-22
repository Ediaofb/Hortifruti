using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hortifruti.Relatorios
{
    public partial class FrmRelProdutos : Form
    {
        public FrmRelProdutos()
        {
            InitializeComponent();
        }

        public void CarregarRelatorio(string nomeProduto)
        {
            try
            {
                string sql = @"
                    SELECT *
                    FROM Produto
                    WHERE Nome LIKE @nome
                    ORDER BY Nome";

                using (SqlConnection conexao = Conexao.CriarConexao())
                using (SqlCommand comando = new SqlCommand(sql, conexao))
                using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                {
                    comando.Parameters.AddWithValue("@nome", "%" + nomeProduto + "%");

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

        private void FrmRelProdutos_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hortifruti_dbDataSet5.Produto'. Você pode movê-la ou removê-la conforme necessário.
            /*this.produtoTableAdapter.Fill(this.hortifruti_dbDataSet6.Produto, "");           
            this.reportViewer1.RefreshReport();*/
            CarregarRelatorio("");
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void btn_consult_rel_vendas_Click(object sender, EventArgs e)
        {
            /* this.produtoTableAdapter.Fill(this.hortifruti_dbDataSet6.Produto, tb_produtos.Text);
             this.reportViewer1.RefreshReport(); */
            CarregarRelatorio(tb_produtos.Text);
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void produtoBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void produtoBindingSource2_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
