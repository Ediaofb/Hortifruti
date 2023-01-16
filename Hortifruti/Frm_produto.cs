using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;

namespace Hortifruti
{
    public partial class Frm_produto : Form
    {
        //MetodosUteis metodos = new MetodosUteis();

        public Frm_produto()
        {
            InitializeComponent();
            test();          
        }

        public void test()
        {
            string config = "Data Source=DESKTOP-K8CN5AA\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True";
            string query = String.Format("SELECT * FROM Produto ORDER BY Nome ", "bd");

            SqlConnection conexao = new SqlConnection(config);
            conexao.Open();

            SqlCommand comand = new SqlCommand(query, conexao);
            SqlDataAdapter adapter = new SqlDataAdapter(comand);

            DataTable data = new DataTable();
            adapter.Fill(data);
            dgvProduto.DataSource = data;

            conexao.Close();
        }        

        // -- CONFIGURA DATAGRIDVIEW--\\

        public void ConfiguraDataGridView()
        {
            //Renomeia as colunas do DataGridView

            dgvProduto.Columns[0].HeaderText = "idProduto";
            dgvProduto.Columns[1].HeaderText = "nome";
            dgvProduto.Columns[2].HeaderText = "tipo";
            dgvProduto.Columns[3].HeaderText = "preço";

            //Redimensiona o tamanho das colunas
            dgvProduto.Columns[0].Width = 60;
            dgvProduto.Columns[1].Width = 100;
            dgvProduto.Columns[2].Width = 100;
            dgvProduto.Columns[3].Width = 100;
        }

        private void btn_voltar_cli_Click(object sender, EventArgs e)
        {
            Frm_consulta cons = new Frm_consulta();
            cons.Show();
            this.Close();
        }

        private void Frm_produto_Load(object sender, EventArgs e)
        {
          
        }

        private void dgvProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //define a string de conexao com provider caminho e nome do banco de dados
            string config = "Data Source=DESKTOP-K8CN5AA\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True";
            //define a instrução SQL
            string query = String.Format("SELECT * FROM PRODUTO WHERE Nome LIKE '%" + textBox1.Text + "%' ORDER BY Nome", "bd");
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
            dgvProduto.DataSource = data;

            conexao.Close();
        }
    }
}
