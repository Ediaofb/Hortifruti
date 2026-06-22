using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;

namespace Hortifruti
{
    public partial class Frm_login : Form
    {
       /* SqlConnection conexao;
        SqlCommand comando;
        SqlDataReader dr;
        string strSQL;*/

       // public object MysqlConnection { get; private set; }

        public Frm_login()
        {
            InitializeComponent();
        }

        //string connectionString = "Data Source=DESKTOP-K8CN5AA\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True";

        public void login()
        {

            try
            {
                string connectionString = ConfigurationManager
                    .ConnectionStrings["Hortifruti.Properties.Settings.hortifruti_dbConnectionString"]
                    .ConnectionString;

                string strSQL = "SELECT *FROM usuario WHERE nome = @nome AND senha = @senha";

                using (SqlConnection conexao = new SqlConnection(connectionString))
                using (SqlCommand comando = new SqlCommand(strSQL, conexao))
                {
                    comando.Parameters.AddWithValue("@nome", txtUsuario.Text);
                    comando.Parameters.AddWithValue("@senha", txtSenha.Text);

                    conexao.Open();

                    using (SqlDataReader dr = comando.ExecuteReader())
                    {
                        if(dr.HasRows)
                        {
                            Frm_inicial frm2 = new Frm_inicial();
                            frm2.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Oops! Algo deu errado. Por favor, tente novamente!");
                        }
                    }                    
                }


               /* //passa a string de conexão server=localhost;database=hortifruti_db;Uid=root;Pwd=359423;
                conexao = new SqlConnection(ConfigurationManager.ConnectionStrings["Hortifruti.Properties.Settings.hortifruti_dbConnectionString"].ConnectionString);
               
                strSQL = "SELECT * from usuario where nome= '"+ txtUsuario.Text +"' AND senha= '" + txtSenha.Text +"'";
                 // Preparando a conexão
                 comando = new SqlCommand(strSQL, conexao);
                 
                 conexao.Open();

                 dr = comando.ExecuteReader();

                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Frm_inicial frm2 = new Frm_inicial();
                        frm2.Show();
                        this.Hide();
                    }

                }
                else
                {
                    MessageBox.Show("Oops! Algo deu errado. Por favor, tente novamente!");
                }
                conexao.Close(); */

            }
            catch (Exception erro)
            {
                MessageBox.Show(erro.Message);
            }
           /* finally
            {
                conexao.Close();
                conexao = null;
                comando = null; 
            }*/

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            login();

            /*if (string.IsNullOrWhiteSpace(textBox1.Text) && string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Por favor, informe o usuário e senha corretamente!");
            }

            else if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Por favor, informe o usuário corretamente!");
            }

            else if(string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Por favor, informe a senha corretamente!");                
            }

            else
            {
                Frm_inicial novo = new Frm_inicial();
                novo.Show();
                this.Hide();
            }*/

            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
