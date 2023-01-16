using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hortifruti
{
    public partial class Frm_fornecedor : Form
    {
        public Frm_fornecedor()
        {
            InitializeComponent();
            test();
        }

        public void test()
        {
            string config = "Data Source=DESKTOP-K8CN5AA\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True";
            string query = String.Format("SELECT * FROM PRODUTOR", "bd");

            SqlConnection conexao = new SqlConnection(config);
            conexao.Open();

            SqlCommand comand = new SqlCommand(query, conexao);
            SqlDataAdapter adapter = new SqlDataAdapter(comand);

            DataTable data = new DataTable();
            adapter.Fill(data);
            dgvProduto.DataSource = data;
        }

        private void Frm_fornecedor_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hortifruti_dbDataSet2.Produtor'. Você pode movê-la ou removê-la conforme necessário.
            this.produtorTableAdapter.Fill(hortifruti_dbDataSet6.Produtor, "");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dgvProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_voltar_cli_Click(object sender, EventArgs e)
        {
            Frm_consulta cons = new Frm_consulta();
            cons.Show();
            this.Close();
        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            //define a string de conexao com provedor caminho e nome do banco de dados
            string config = "Data Source=DESKTOP-K8CN5AA\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True";
            //define a instrução SQL
            string query = String.Format("SELECT * FROM PRODUTOR WHERE Nome LIKE '%"+textBox1.Text+"%' ORDER BY Nome", "bd");
            
            //cria a conexão com o banco de dados
            SqlConnection conexao = new SqlConnection(config);            
            
            //cria o objeto command para executar a instruçao sql
            SqlCommand comand = new SqlCommand(query, conexao);

            //abre a conexao
            conexao.Open();

            //define o tipo do comando
            comand.CommandType = CommandType.Text;
                        
            //cria um dataadapter
            SqlDataAdapter adapter = new SqlDataAdapter(comand);
            //cria um objeto datatable
            DataTable data = new DataTable();
            //preenche o datatable via dataadapter
            adapter.Fill(data);
            //atribui o datatable ao datagridview para exibir o resultado
            dgvProduto.DataSource = data;            
        }
    }
}
