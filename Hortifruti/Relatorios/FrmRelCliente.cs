using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Hortifruti.Relatorios
{
    public partial class FrmRelCliente : Form
    {
        public FrmRelCliente()
        {
            InitializeComponent();
        }

        private void FrmRelCliente_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hortifruti_dbDataSet.Cliente'. Você pode movê-la ou removê-la conforme necessário.
            /*this.clienteTableAdapter.Fill(this.hortifruti_dbDataSet6.Cliente, "");
            this.reportViewer1.RefreshReport(); */
            CarregarRelatorio("");
        }

        private void btn_consultar_clientes_Click(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hortifruti_dbDataSet.Cliente'. Você pode movê-la ou removê-la conforme necessário.
            /*this.clienteTableAdapter.Fill(this.hortifruti_dbDataSet6.Cliente, tb_clientes.Text);
            this.reportViewer1.RefreshReport(); */
            CarregarRelatorio(tb_clientes.Text);
        }

        public void CarregarRelatorio(string nomeCliente)
        {
            try
            {
                string sql = @"
                    SELECT*
                    FROM Cliente
                    WHERE Nome LIKE @nome
                    ORDER BY Nome";

                using (SqlConnection conexao = Conexao.CriarConexao())
                using (SqlCommand comando = new SqlCommand(sql, conexao))
                using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                {
                    comando.Parameters.AddWithValue("@nome", "%" + nomeCliente + "%");

                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);

                    reportViewer1.LocalReport.DataSources.Clear();

                    ReportDataSource rds = new ReportDataSource("DataSet1", tabela);
                    reportViewer1.LocalReport.DataSources.Add(
                        new Microsoft.Reporting.WinForms.ReportDataSource("DataSet1", tabela)
                    );

                    reportViewer1.LocalReport.ReportEmbeddedResource = "Hortifruti.Relatorios.RelCliente.rdlc";
                    reportViewer1.RefreshReport();
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
