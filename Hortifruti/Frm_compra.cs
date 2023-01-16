using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hortifruti
{
    public partial class Frm_compra : Form
    {
        SqlConnection conexao;
        SqlCommand comand, comando;
        SqlDataAdapter adapter;
        String aux, aux1, strSQL;
        SqlDataReader dr, dr2;

        public Frm_compra()
        {
            InitializeComponent();
            test();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string config = "Data Source=DESKTOP-K8CN5AA\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True";
            string query = String.Format("SELECT Data, Data_Vencimento, Nome_Produtor, Produto, Unidade, Quantidade, Valor_unitario, Valor_total, Pagamento FROM Compra WHERE Nome_Produtor LIKE '%" + textBox1.Text + "%' AND Data BETWEEN @data AND @data2", "bd");

            SqlConnection conexao = new SqlConnection(config);
            conexao.Open();

            try
            {
                comand = new SqlCommand(query, conexao);
                comand.Parameters.AddWithValue("@data", dateTimePicker1.Value);
                comand.Parameters.AddWithValue("@data2", dateTimePicker2.Value);

                if (dateTimePicker1.Text == dateTimePicker2.Text || dateTimePicker1.Value < dateTimePicker2.Value)
                {
                    adapter = new SqlDataAdapter(comand);
                    adapter.SelectCommand = comand;
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    dgvCompra.DataSource = data;

                    conexao.Close();
                }
                else
                    MessageBox.Show("A data inicial deve ser menor que a data final da busca!!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);

                conexao.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                conexao.Close();
                comand.Dispose();
                conexao = null;
                comand = null;
            }
        }

        public void test()
        {
            string config = "Data Source=DESKTOP-K8CN5AA\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True";
            string query = String.Format("SELECT * FROM COMPRA", "bd");

            SqlConnection conexao = new SqlConnection(config);
            conexao.Open();

            SqlCommand comand = new SqlCommand(query, conexao);
            SqlDataAdapter adapter = new SqlDataAdapter(comand);

            DataTable data = new DataTable();
            adapter.Fill(data);
            dgvCompra.DataSource = data;

            conexao.Close();

        }

        private void Frm_compra_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hortifruti_dbDataSet4.Compra'. Você pode movê-la ou removê-la conforme necessário.
            this.compraTableAdapter.Fill(this.hortifruti_dbDataSet6.Compra, "", "", "01-01-2000", "12-08-2100");

        }

        private void btn_voltar_cli_Click(object sender, EventArgs e)
        {
            Frm_consulta cons = new Frm_consulta();
            cons.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //botão dialog pergunta: "Deseja realmente editar este produto?"
            DialogResult confirm = MessageBox.Show("Deseja realmente editar este pagamento?", "Salvar Arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //Em caso afirmativo, edita
            if(confirm.ToString().ToUpper() == "YES")
            {
                int linhaAtual = dgvCompra.CurrentCell.RowIndex;
                string dado;
                //int colunaAtual = dgvCompra.CurrentCell.ColumnIndex; -- A coluna do pagamentoDataGridViewTextBoxColumn é a 8!

                dado = dgvCompra.Rows[linhaAtual].Cells[8].Value.ToString(); //Obtendo o dado da célula do pagamento desejado

                try
                {
                    conexao = new SqlConnection("Data Source=DESKTOP-K8CN5AA\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");
                    
                    aux = "SELECT id_Compra FROM Compra WHERE Nome_Produtor = @produtor AND Produto = @produto AND data =@data AND Valor_total = @preco";
                    comando = new SqlCommand(aux, conexao);
                    comando.Parameters.AddWithValue("@produtor", dgvCompra.Rows[linhaAtual].Cells[1].Value.ToString());
                    comando.Parameters.AddWithValue("@produto", dgvCompra.Rows[linhaAtual].Cells[2].Value.ToString());
                    comando.Parameters.AddWithValue("@data", dgvCompra.Rows[linhaAtual].Cells[0].Value.ToString());
                    comando.Parameters.AddWithValue("@preco", dgvCompra.Rows[linhaAtual].Cells[5].Value);
                    comando.CommandType = CommandType.Text;
                    conexao.Open();
                    dr = comando.ExecuteReader();

                    if(dr.Read())
                    {
                        aux1 = dr.GetInt32(0).ToString();

                        dr.Close();
                        conexao.Close();

                        int aux_int;
                        aux_int = Int32.Parse(aux1);

                        strSQL = "UPDATE Compra SET pagamento = @pagamento WHERE Id_compra = @id";

                        //prepando a conexao
                        comando = new SqlCommand(strSQL, conexao);
                        comando.Parameters.AddWithValue("@pagamento", dgvCompra.Rows[linhaAtual].Cells[8].Value.ToString());
                        comando.Parameters.AddWithValue("@id", aux1);
                        comando.CommandType = CommandType.Text;
                        conexao.Open();

                        dr2 = comando.ExecuteReader();

                        MessageBox.Show("Pagamento alterado com sucesso!");

                            comando = null;
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show(erro.Message);
                }
                finally
                {
                    conexao.Close();
                    conexao = null;
                    comando = null;
                }
            }
        }
    }
}
