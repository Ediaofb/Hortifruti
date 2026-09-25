using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hortifruti
{
    public partial class Frm_compra : Form
    {
        public Frm_compra()
        {
            InitializeComponent();

            // Suprime o erro de formato do DataGridView
            dgvCompra.DataError += (s, e) => { e.Cancel = true; };

            CarregarCompras();
        }

        private void Frm_compra_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hortifruti_dbDataSet4.Compra'. Você pode movê-la ou removê-la conforme necessário.
            //this.compraTableAdapter.Fill(this.hortifruti_dbDataSet6.Compra, "", "", "01-01-2000", "12-08-2100");

        }

        // ── Método auxiliar para criar colunas ───────────────────────
        private void AdicionarColuna(
            string nomeDataField,
            string cabecalho,
            bool editavel)
        {
            DataGridViewTextBoxColumn col =
                new DataGridViewTextBoxColumn();
            col.DataPropertyName = nomeDataField;
            col.HeaderText = cabecalho;
            col.ReadOnly = !editavel;
            dgvCompra.Columns.Add(col);
        }

        // ── Carrega todas as compras ─────────────────────────────────
        public void CarregarCompras() // Mudei o nome para algo mais semântico
        {          

            try
            {
                string sql = @"
                    SELECT
                        Data,
                        Nome_Produtor,
                        Produto,
                        Unidade,
                        Quantidade,
                        Valor_unitario,
                        Valor_total,
                        Data_Vencimento,
                        CASE
                            WHEN Pagamento = 1 THEN 'S'
                            WHEN Pagamento = 0 THEN 'N'
                            ELSE 'N'
                        END AS Pagamento
                    FROM Compra
                    ORDER BY Data";

                // Usamos a mesma classe Conexao que centraliza a string do App.config
                using (SqlConnection conexao = Conexao.CriarConexao())
                using (SqlCommand comando = new SqlCommand(sql, conexao))
                using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                {
                    DataTable data = new DataTable();
                    adapter.Fill(data);

                    // Desvincula antes de reconfigurar
                    dgvCompra.DataSource = null;
                    dgvCompra.Columns.Clear();
                    dgvCompra.AutoGenerateColumns = false;

                    // Recria as colunas como TextBox
                    // Somente 'Pagamento' é editável
                    AdicionarColuna("Data", "Data", false);
                    AdicionarColuna("Nome_Produtor", "Produtor", false);
                    AdicionarColuna("Produto", "Produto", false);
                    AdicionarColuna("Unidade", "Unidade", false);
                    AdicionarColuna("Quantidade", "Quantidade", false);
                    AdicionarColuna("Valor_unitario", "Vl. Unit.", false);
                    AdicionarColuna("Valor_total", "Vl. Total", false);
                    AdicionarColuna("Data_Vencimento", "Vencimento", false);
                    AdicionarColuna("Pagamento", "Pagamento", true);
                    // ↑ true = editável

                    dgvCompra.DataSource = data;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "Erro ao carregar compras:\n" + erro.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // _______ Filtra compras por produtor e por período _____________________________
        public void FiltrarCompras()
        {
            //Valida o intervalo de datas antes de ir ao banco
            if (dateTimePicker1.Value.Date > dateTimePicker2.Value.Date)
            {
                MessageBox.Show(
                    "A data inicial deve ser menor ou igual à data final!",
                    "Atenção",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string sql = @"
                    SELECT
                        Data,
                        Nome_Produtor,
                        Produto,
                        Unidade,
                        Quantidade,
                        Valor_unitario,
                        Valor_total,
                        Data_Vencimento,
                        CASE
                            WHEN Pagamento = 1 THEN 'S'
                            WHEN Pagamento = 0 THEN 'N'
                            ELSE 'N'
                        END AS Pagamento
                    FROM   Compra
                    WHERE  Nome_Produtor LIKE @produtor
                      AND  Data BETWEEN @dataInicio AND @dataFim
                    ORDER BY Data";

                using (SqlConnection conexao = Conexao.CriarConexao())
                using (SqlCommand comando = new SqlCommand(sql, conexao))
                using (SqlDataAdapter adapter = new SqlDataAdapter(comando))
                {
                    comando.Parameters.AddWithValue(
                        "@produtor", "%" + textBox1.Text.Trim() + "%");
                    comando.Parameters.AddWithValue(
                        "@dataInicio", dateTimePicker1.Value.Date);
                    comando.Parameters.AddWithValue(
                        "@dataFim", dateTimePicker2.Value.Date
                                           .AddDays(1).AddSeconds(-1));
                    // ↑ inclui o dia final completo (até 23:59:59)

                    DataTable tabela = new DataTable();
                    adapter.Fill(tabela);

                    // Mantém as colunas já configuradas
                    // apenas atualiza os dados
                    dgvCompra.DataSource = tabela;
                }
            }
            catch (Exception erro)
            {
                MessageBox.Show(
                    "Erro ao filtrar compras:\n" + erro.Message,
                    "Erro",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        // ── Atualiza pagamento do registro selecionado no grid ───────
        public void AtualizarPagamento()
        {
            // Força o DataGridView a confirmar edição em andamento
            dgvCompra.EndEdit();

            if (dgvCompra.CurrentCell == null)
            {
                MessageBox.Show(
                    "Selecione um registro na tabela.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int linha = dgvCompra.CurrentCell.RowIndex;

            // Verifica células nulas antes de ler
            if (dgvCompra.Rows[linha].Cells[0].Value == null ||
                dgvCompra.Rows[linha].Cells[1].Value == null ||
                dgvCompra.Rows[linha].Cells[2].Value == null ||
                dgvCompra.Rows[linha].Cells[6].Value == null ||
                dgvCompra.Rows[linha].Cells[8].Value == null)
            {
                MessageBox.Show(
                    "Não é possível salvar: há campos vazios "
                  + "na linha selecionada.",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string data = dgvCompra.Rows[linha].Cells[0].Value.ToString();
            string produtor = dgvCompra.Rows[linha].Cells[1].Value.ToString();
            string produto = dgvCompra.Rows[linha].Cells[2].Value.ToString();
            object preco = dgvCompra.Rows[linha].Cells[6].Value;

            // ── Converte S/N para 1/0 ────────────────────────────────
            string valorDigitado =
                dgvCompra.Rows[linha].Cells[8].Value
                    .ToString().Trim().ToUpper();

            if (valorDigitado != "S" && valorDigitado != "N")
            {
                MessageBox.Show(
                    "Valor inválido para Pagamento.\n"
                  + "Digite apenas 'S' (sim) ou 'N' (não).",
                    "Aviso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            int pagamentoBanco = (valorDigitado == "S") ? 1 : 0;

            try
            {
                // 1. Busca o ID do registro
                string sqlBusca = @"
                    SELECT id_Compra
                    FROM   Compra
                    WHERE  Nome_Produtor = @produtor
                      AND  Produto       = @produto
                      AND  Data          = @data
                      AND  Valor_total   = @preco";

                int idCompra = -1;

                using (SqlConnection conexao = Conexao.CriarConexao())
                using (SqlCommand comando = new SqlCommand(sqlBusca, conexao))
                {
                    comando.Parameters.AddWithValue("@produtor", produtor);
                    comando.Parameters.AddWithValue("@produto", produto);
                    comando.Parameters.AddWithValue("@data", data);
                    comando.Parameters.AddWithValue("@preco", preco);

                    conexao.Open();

                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if (dr.Read())
                            idCompra = dr.GetInt32(0);
                    }
                } // ← conexão fechada automaticamente pelo using

                // 2. ID não encontrado
                if (idCompra == -1)
                {
                    MessageBox.Show(
                        "Registro não encontrado no banco de dados.",
                        "Aviso",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                // 3. Atualiza o pagamento gravando 1 ou 0 no banco
                string sqlUpdate = @"
                    UPDATE Compra
                    SET    Pagamento  = @pagamento
                    WHERE  Id_Compra  = @id";

                using (SqlConnection conexao = Conexao.CriarConexao())
                using (SqlCommand comando = new SqlCommand(sqlUpdate, conexao))
                {
                    comando.Parameters.AddWithValue("@pagamento", pagamentoBanco);
                    comando.Parameters.AddWithValue("@id", idCompra);

                    conexao.Open();
                    comando.ExecuteNonQuery();
                    // ↑ correto para UPDATE — não retorna linhas
                }

                MessageBox.Show(
                    "Pagamento alterado com sucesso!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                CarregarCompras(); // atualiza o grid após salvar
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
            FiltrarCompras();
        }       

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult confirm = MessageBox.Show(
                "Deseja realmente editar este pagamento?",
                "Confirmar edição",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Exclamation,
                MessageBoxDefaultButton.Button2);

            if (confirm == DialogResult.Yes)
                AtualizarPagamento();


            /*{
                DialogResult confirm = MessageBox.Show("Deseja realmente editar este pagamento?", "Salvar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm != DialogResult.Yes) return;

                int linhaAtual = dgvCompra.CurrentCell.RowIndex;
                string idCompra = "";

                try
                {
                    // 1. Busca do ID
                    string queryBusca = "SELECT id_Compra FROM Compra WHERE Nome_Produtor = @produtor AND Produto = @produto AND data = @data AND Valor_total = @preco";

                    using (SqlConnection conexao = Conexao.CriarConexao())
                    using (SqlCommand cmdBusca = new SqlCommand(queryBusca, conexao))
                    {
                        cmdBusca.Parameters.AddWithValue("@produtor", dgvCompra.Rows[linhaAtual].Cells[1].Value);
                        cmdBusca.Parameters.AddWithValue("@produto", dgvCompra.Rows[linhaAtual].Cells[2].Value);
                        cmdBusca.Parameters.AddWithValue("@data", dgvCompra.Rows[linhaAtual].Cells[0].Value);
                        cmdBusca.Parameters.AddWithValue("@preco", dgvCompra.Rows[linhaAtual].Cells[5].Value);

                        conexao.Open();
                        object resultado = cmdBusca.ExecuteScalar(); // Use ExecuteScalar quando espera apenas um valor
                        if (resultado != null) idCompra = resultado.ToString();
                    }

                    // 2. Execução do Update
                    if (!string.IsNullOrEmpty(idCompra))
                    {
                        string queryUpdate = "UPDATE Compra SET pagamento = @pagamento WHERE Id_compra = @id";
                        using (SqlConnection conexao = Conexao.CriarConexao())
                        using (SqlCommand cmdUpdate = new SqlCommand(queryUpdate, conexao))
                        {
                            cmdUpdate.Parameters.AddWithValue("@pagamento", dgvCompra.Rows[linhaAtual].Cells[8].Value);
                            cmdUpdate.Parameters.AddWithValue("@id", idCompra);

                            conexao.Open();
                            cmdUpdate.ExecuteNonQuery();
                            MessageBox.Show("Pagamento alterado com sucesso!");
                        }
                    }
                }
                catch (Exception erro)
                {
                    MessageBox.Show("Erro ao editar: " + erro.Message);
                }
            }*/

        }

        private void btn_voltar_cli_Click(object sender, EventArgs e)
        {
            Frm_consulta cons = new Frm_consulta();
            cons.Show();
            this.Hide();
        }
    }
}
