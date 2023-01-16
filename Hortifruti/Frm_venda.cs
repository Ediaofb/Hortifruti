using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Hortifruti
{
    public partial class Frm_venda : Form
    {
        SqlCommand comando;
        SqlDataAdapter adaptador;
        SqlConnection conexao;
        string aux, aux1, strSQL;
        SqlDataReader dr, dr2;

        public Frm_venda()
        {
            InitializeComponent();
            test();
        }

        public void test()
        {
            string config = "Data Source=DESKTOP-K8CN5AA\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True";
            string query = String.Format("SELECT * FROM VENDAS", "bd");
            SqlConnection conexao = new SqlConnection(config);
            conexao.Open();

            SqlCommand comand = new SqlCommand(query, conexao);
            SqlDataAdapter adapter = new SqlDataAdapter(comand);

            DataTable data = new DataTable();
            adapter.Fill(data);
            dgvVendas.DataSource = data;
        }

        private void Frm_venda_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hortifruti_dbDataSet2.Vendas'. Você pode movê-la ou removê-la conforme necessário.
            this.vendasTableAdapter.Fill(this.hortifruti_dbDataSet6.Vendas, "","2022-01-01","2100-01-01");

        }

        private void btn_voltar_cli_Click(object sender, EventArgs e)
        {
            Frm_consulta cons = new Frm_consulta();
            cons.Show();
            this.Hide();
        }

        private void dgvProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            consulta_venda_personalizada();
        }

        public void consulta_venda_personalizada()
        {
            string config = "Data Source=DESKTOP-K8CN5AA\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True";
            string query = "SELECT * FROM VENDAS WHERE Cliente LIKE '%'+ @cliente + '%' AND Data BETWEEN @data1 AND @data2;";

            SqlConnection cn = new SqlConnection(config);
            cn.Open();

            try
            {
                comando = new SqlCommand(query, cn);
                comando.CommandType = CommandType.Text;
                comando.Parameters.AddWithValue("@cliente", textBox2.Text);
                comando.Parameters.AddWithValue("@data1", dateTimePicker1.Value);
                comando.Parameters.AddWithValue("@data2", dateTimePicker2.Value);

                if (dateTimePicker1.Text == dateTimePicker2.Text || dateTimePicker1.Value < dateTimePicker2.Value)//Se a data inicial for menor ou igual a data final
                {
                    adaptador = new SqlDataAdapter(comando);
                    adaptador.SelectCommand = comando;
                    DataTable table = new DataTable();
                    adaptador.Fill(table);
                    dgvVendas.DataSource = table;
                }
                else
                    MessageBox.Show("A data inicial deve ser menor que a data final da busca!!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 

            catch (Exception ex)    
            {
            throw ex;
            }

            finally
            {
                cn.Close();
                comando.Dispose();
                cn = null;
                comando = null;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //botão dialog pergunta: "Deseja realmente editar este produto?"
            DialogResult confirm = MessageBox.Show("Deseja realmente editar este pagamento?", "Salvar Arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //Em caso afirmativo, edita
            if (confirm.ToString().ToUpper() == "YES")
            {
                int linhaAtual = dgvVendas.CurrentCell.RowIndex;
                string dado;
                //int colunaAtual = dgvVendas.CurrentCell.ColumnIndex; -- A coluna do pagamento é a 7!

                dado = dgvVendas.Rows[linhaAtual].Cells[7].Value.ToString();//Obtendo o dado da célula do pagamento desejado

                try
                {

                    conexao = new SqlConnection("Data Source=DESKTOP-K8CN5AA\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");

                    aux = "SELECT id_vendas FROM Vendas WHERE Cliente = @cliente AND NomeProduto = @produto AND Data = @data AND Preco_total = @preco";
                    comando = new SqlCommand(aux, conexao);
                    comando.Parameters.AddWithValue("@cliente", dgvVendas.Rows[linhaAtual].Cells[1].Value.ToString());
                    comando.Parameters.AddWithValue("@produto", dgvVendas.Rows[linhaAtual].Cells[2].Value.ToString());
                    comando.Parameters.AddWithValue("@data", dgvVendas.Rows[linhaAtual].Cells[0].Value.ToString());
                    comando.Parameters.AddWithValue("@preco", dgvVendas.Rows[linhaAtual].Cells[6].Value);
                    comando.CommandType = CommandType.Text;
                    conexao.Open();
                    dr = comando.ExecuteReader();

                    if (dr.Read())
                    {
                        aux1 = dr.GetInt32(0).ToString();
                        //MessageBox.Show("Pegou o id da Venda, ele é = " + aux1);

                        dr.Close();
                        conexao.Close();

                        int aux_int;
                        aux_int = Int32.Parse(aux1);

                        strSQL = "UPDATE Vendas SET pagamento = @pagamento WHERE Id_vendas = @id";

                        //preparando a conexão
                        comando = new SqlCommand(strSQL, conexao);
                        comando.Parameters.AddWithValue("@pagamento", dgvVendas.Rows[linhaAtual].Cells[7].Value.ToString());
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
