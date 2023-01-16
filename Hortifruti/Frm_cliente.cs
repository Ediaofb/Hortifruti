using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Hortifruti
{
    public partial class Frm_cliente : Form
    {

        public Frm_cliente()
        {
            InitializeComponent();
            test();
            /*  ConfiguraDataGridView();
              string comandoSQL = "Select * from produto";

              atualizaDataGridView(comandoSQL);*/
        }

        public void test()
        {
            string config = "Data Source=DESKTOP-K8CN5AA\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True";
            string query = String.Format("SELECT * FROM CLIENTE", "bd");

            SqlConnection conexao = new SqlConnection(config);
            conexao.Open();

            SqlCommand comand = new SqlCommand(query, conexao);
            SqlDataAdapter adapter = new SqlDataAdapter(comand);

            DataTable data = new DataTable();
            adapter.Fill(data);
            dgvClientes.DataSource = data;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Frm_cliente_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hortifruti_dbDataSet2.Cliente'. Você pode movê-la ou removê-la conforme necessário.
            this.clienteTableAdapter.Fill(hortifruti_dbDataSet6.Cliente, "");

        }

        private void btn_voltar_cli_Click(object sender, EventArgs e)
        {
            Frm_consulta cons = new Frm_consulta();
            cons.Show();
            this.Hide();
        }

        private void dgvClientes_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //define a string de conexao com provider caminho e nome do banco de dados
            string config = "Data Source=DESKTOP-K8CN5AA\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True";
            //define a instrução SQL
            string query = String.Format("SELECT * FROM CLIENTE WHERE Nome LIKE '%" + textBox1.Text + "%' ORDER BY Nome", "bd");
            //cria a conexao com o banco de dados
            SqlConnection conexao = new SqlConnection(config);
            //abre a conexao
            conexao.Open();
            //cria o objeto command para executar a instrução sql
            SqlCommand comand = new SqlCommand(query, conexao);
            //cria um dataadapter
            SqlDataAdapter adapter = new SqlDataAdapter(comand);
            //cria um objeto datatable
            DataTable data = new DataTable();
            //preenche o datatable via dataadapter
            adapter.Fill(data);
            //atribui o datatable ao datagridview para exibir o resultado
            dgvClientes.DataSource = data;

            conexao.Close();
        }
    }
}
