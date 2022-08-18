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
            string config = "Data Source=EDSON-PC;Initial Catalog=hortifruti_db;Integrated Security=True";
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
            this.clienteTableAdapter.Fill(this.hortifruti_dbDataSet2.Cliente);

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
    }
}
