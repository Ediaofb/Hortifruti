using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace Hortifruti.Relatorios
{
    public partial class FrmRelCompras : Form
    {
        public FrmRelCompras()
        {
            InitializeComponent();
        }

        private void FrmRerlCompras_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hortifruti_dbDataSet7.Compra'. Você pode movê-la ou removê-la conforme necessário.
            /* this.compraTableAdapter.Fill(this.hortifruti_dbDataSet7.Compra, "", "", "01-01-2000", "01-01-2100");            
            this.reportViewer1.RefreshReport(); */

            //Ao abrir, carrega todas as compras sem filtro
            CarregarRelatorio(
                nomeProdutor: "",
                Produto: "",
                dataInicio: new DateTime(2026, 1, 1),
                dataFim: new DateTime(2100, 1, 1)
            );
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hortifruti_dbDataSet4.Compra'. Você pode movê-la ou removê-la conforme necessário.
            /* this.compraTableAdapter.Fill(this.hortifruti_dbDataSet7.Compra, textBox1.Text, textBox2.Text, dateTimePicker1.Text, dateTimePicker2.Text);
            this.reportViewer1.RefreshReport(); */

            // Aplica os filtros informados pelo usuário
            CarregarRelatorio(
                nomeProdutor: textBox1.Text,
                Produto: textBox2.Text,
                dataInicio: dateTimePicker1.Value.Date,
                dataFim: dateTimePicker2.Value.Date
            );
        }

        private void CarregarRelatorio(
            string nomeProdutor,
            string Produto,
            DateTime dataInicio,
            DateTime dataFim)
        {
           try
           {
                string sql = @"
                 SELECT *
                 FROM Compra

                 WHERE Nome_Produtor LIKE @nomeProdutor
                 AND Produto LIKE @Produto
                 AND Data >= @dataInicio
                 AND Data <= @dataFIm
               ORDER BY Data";
                using (SqlConnection conexao = Conexao.CriarConexao())
                using (SqlCommand comando = new SqlCommand(sql, conexao))
                using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                {
                    // Parâmetros de texto (LIKE)
                    comando.Parameters.AddWithValue(
                        "@nomeProdutor", "%" + nomeProdutor + "%");
                    comando.Parameters.AddWithValue(
                        "@Produto", "%" + Produto + "%");

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

        private void reportViewer1_Load_1(object sender, EventArgs e)
        {

        }
    }
}