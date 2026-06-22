using Microsoft.Reporting.WinForms;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Hortifruti.Relatorios
{
    public partial class FrmRelVendas : Form
    {
        public FrmRelVendas()
        {
            InitializeComponent();
        }

        private void FrmRelVendas_Load(object sender, EventArgs e)
        {

            // TODO: esta linha de código carrega dados na tabela 'hortifruti_dbDataSet4.Vendas'. Você pode movê-la ou removê-la conforme necessário.
            /* this.vendasTableAdapter.Fill(this.hortifruti_dbDataSet6.Vendas,"","01-01-2000","01-01-2100");
            this.reportViewer1.RefreshReport(); */

            //Ao abrir, carrega todas as compras sem filtro
            CarregarRelatorio(
                  Cliente: "",
                  dataInicio: new DateTime(2026, 1, 1),
                  dataFim: new DateTime(2100, 1, 1)
            );
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void hortifrutidbDataSet4BindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void btn_consult_rel_vendas_Click(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hortifruti_dbDataSet4.Vendas'. Você pode movê-la ou removê-la conforme necessário.
            /*this.vendasTableAdapter.Fill(this.hortifruti_dbDataSet6.Vendas, tb_clientes.Text, dateTimePicker1.Value.ToString(), dateTimePicker2.Value.ToString());
            this.reportViewer1.RefreshReport(); */

            // Aplica os filtros informados pelo usuário
            CarregarRelatorio(
                Cliente: tb_clientes.Text,
                dataInicio: dateTimePicker1.Value.Date,
                dataFim: dateTimePicker2.Value.Date
             );
        }

            private void CarregarRelatorio(
                string Cliente,
                DateTime dataInicio,
                DateTime dataFim)
            {
                try
                {
                    string sql= @"
                      SELECT *
                      FROM Vendas
                      WHERE Cliente LIKE @Cliente
                      AND Data >= @dataInicio
                      AND Data <= @dataFim
                   ORDER BY Data";
                    using (SqlConnection conexao = Conexao.CriarConexao())
                    using (SqlCommand comando = new SqlCommand(sql, conexao))
                    using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                    {
                        // Parâmetros de texto (LIKE)
                        comando.Parameters.AddWithValue(
                            "@cliente", "%" + Cliente + "%");

                        // Parâmetros de data — usando .Date garante
                        // que a hora não interfere no filtro
                        comando.Parameters.AddWithValue(
                            "dataInicio", dataInicio);
                        comando.Parameters.AddWithValue(
                            "dataFim", dataFim);

                        DataTable tabela = new DataTable();
                        adapter.Fill(tabela);

                        // ── Configure o relatório ────────────────────────
                        reportViewer1.LocalReport.ReportEmbeddedResource =
                            "Hortifruti.Relatorios.RelCompras.rdlc";

                        reportViewer1.LocalReport.DataSources.Clear();
                        reportViewer1.LocalReport.DataSources.Add(
                            new ReportDataSource("DataSet1", tabela)
                         );

                        reportViewer1.RefreshReport();
                    }
                 }
                catch (Exception erro)
                {
                    MessageBox.Show(
                        "Erro ao carregar relatório: \n" + erro.Message,
                        "Erro",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }

        private void cb_clientes_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
