using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hortifruti
{
    public partial class Frm_venda : Form
    {
        public Frm_venda()
        {
            InitializeComponent();
            CarregarVenda();
        }

        private void Frm_venda_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hortifruti_dbDataSet2.Vendas'. Você pode movê-la ou removê-la conforme necessário.
            //this.vendasTableAdapter.Fill(this.hortifruti_dbDataSet6.Vendas, "","2022-01-01","2100-01-01");

        }

        public void CarregarVenda()
        {
            try
            {
                string query = "SELECT * FROM Vendas ORDER BY Data";

                using (SqlConnection conexao = Conexao.CriarConexao())
                using (SqlCommand comando = new SqlCommand(query, conexao))
                using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                {
                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    dgvVendas.DataSource = data;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "Erro ao carregar vendas:\n" + erro.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        
        private void dgvProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        // ── Atualiza pagamento do registro selecionado no grid ───────
        public void AtualizarPagamento()
        {
            // Verifica se há linha selecionada
            if (dgvVendas.CurrentCell == null)
            {
                MessageBox.Show(
                    "Selecione um registro na tabela.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int linha = dgvVendas.CurrentCell.RowIndex;
            string cliente = dgvVendas.Rows[linha].Cells[1].Value.ToString();
            string nomeProduto = dgvVendas.Rows[linha].Cells[2].Value.ToString();
            string data = dgvVendas.Rows[linha].Cells[0].Value.ToString();
            object precoTotal = dgvVendas.Rows[linha].Cells[6].Value;
            string pagamento = dgvVendas.Rows[linha].Cells[7].Value.ToString();

            try
            {
                // 1. Busca o ID do registro
                string sqlBusca = @"
                    SELECT id_vendas
                    FROM   Vendas
                    WHERE  Cliente      = @cliente
                      AND  NomeProduto  = @produto
                      AND  Data         = @data
                      AND  Preco_total  = @preco";

                int idVenda = -1;

                using (SqlConnection conexao = Conexao.CriarConexao())
                using (SqlCommand comando = new SqlCommand(sqlBusca, conexao))
                {
                    comando.Parameters.AddWithValue("@cliente", cliente);
                    comando.Parameters.AddWithValue("@produto", nomeProduto);
                    comando.Parameters.AddWithValue("@data", data);
                    comando.Parameters.AddWithValue("@preco", precoTotal);

                    conexao.Open();

                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.Read())
                            idVenda = dr.GetInt32(0);
                    }
                } // ← conexão fechada e devolvida aqui pelo using

                // 2. ID não encontrado
                if (idVenda == -1)
                {
                    MessageBox.Show(
                        "Registro não encontrado no banco de dados.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // 3. Atualiza o pagamento
                string sqlUpdate = @"
                    UPDATE Vendas
                    SET    pagamento = @pagamento
                    WHERE  Id_vendas = @id";

                using (SqlConnection conexao = Conexao.CriarConexao())
                using (SqlCommand comando = new SqlCommand(sqlUpdate, conexao))
                {
                    comando.Parameters.AddWithValue("@pagamento", pagamento);
                    comando.Parameters.AddWithValue("@id", idVenda);

                    conexao.Open();
                    comando.ExecuteNonQuery();
                    // ↑ ExecuteNonQuery é o correto para UPDATE/INSERT/DELETE
                }

                MessageBox.Show(
                    "Pagamento alterado com sucesso!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CarregarVenda(); // atualiza o grid após salvar
            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "Erro ao atualizar pagamento:\n" + erro.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            consulta_venda_personalizada();
        }

        public void consulta_venda_personalizada()
        {
            /* string config = "Data Source=DESKTOP-K8CN5AA\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True";
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
             } */
            try
            {
                string query = @"SELECT * 
                                 FROM VENDAS 
                                 WHERE Cliente LIKE @cliente 
                                 ORDER BY Cliente";

                using (SqlConnection conexao = Conexao.CriarConexao())
                using (SqlCommand comando = new SqlCommand(query, conexao))
                using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                {
                    comando.Parameters.AddWithValue(
                        "@cliente", "%" + textBox2.Text + "%");

                    DataTable data = new DataTable();
                    adapter.Fill(data);
                    dgvVendas.DataSource = data;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "Erro ao filtrar vendas:\n" + erro.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Deseja realmente editar este pagamento?",
                "Confirmar edição",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

            if (confirm == DialogResult.Yes)   // ← comparação direta, sem ToString()
                AtualizarPagamento();

            //botão dialog pergunta: "Deseja realmente editar este produto?"
            /* DialogResult confirm = MessageBox.Show("Deseja realmente editar este pagamento?", "Salvar Arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

            //Em caso afirmativo, edita
            if (confirm.ToString().ToUpper() == "YES")
            {
                int linhaAtual = dgvVendas.CurrentCell.RowIndex;
                string dado;
                //int colunaAtual = dgvVendas.CurrentCell.ColumnIndex; -- A coluna do pagamento é a 7!

                dado = dgvVendas.Rows[linhaAtual].Cells[7].Value.ToString();//Obtendo o dado da célula do pagamento desejado

                try
                {

                    conexao = new SqlConnection("Data Source=.\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");

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
            } */
        }

        private void btn_voltar_cli_Click(object sender, EventArgs e)
        {
            Frm_consulta cons = new Frm_consulta();
            cons.Show();
            this.Hide();
        }

    }
}
