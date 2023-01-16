using System;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Hortifruti
{
    public partial class Frm_usuario : Form
    {

        SqlConnection conexao;
        SqlCommand comando;
        SqlDataReader dr;
        string strSQL, aux, aux1;

        public Frm_usuario()
        {
            InitializeComponent();
        }

        private void Frm_usuario_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Frm_inicial ini = new Frm_inicial();
            ini.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label3.Visible = false; //apaga o label de novo nome, caso esteja visível
            textBox3.Visible = false; //apaga o textbox de novo nome, caso esteja visível
            label4.Visible = false; //apaga o label de nova senha, caso esteja visível
            textBox4.Visible = false; //apaga o textbox de nova senha, caso esteja visível
            button6.Visible = false; //apaga o botão de alterar, caso esteja visível
            button7.Visible = false; //apaga o botão de excluir, caso esteja visível

            label1.Visible = true;
            textBox1.Visible = true;
            label2.Visible = true;
            textBox2.Visible = true;
            button5.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button5.Visible = false; //apaga o botão de adicionar, caso esteja visível
            button7.Visible = false;
            label1.Visible = true;
            textBox1.Visible = true;
            label2.Visible = true;
            textBox2.Visible = true;
            label3.Visible = true;
            textBox3.Visible = true;
            label4.Visible = true;
            textBox4.Visible = true;
            button6.Visible = true;            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label3.Visible = false; //apaga o label de novo nome, caso esteja visível
            textBox3.Visible = false; //apaga o textbox de novo nome, caso esteja visível
            label4.Visible = false; //apaga o label de nova senha, caso esteja visível
            textBox4.Visible = false; //apaga o textbox de nova senha, caso esteja visível
            button6.Visible = false; //apaga o botão de alterar, caso esteja visível
            button5.Visible = false; //apaga o botão de adicionar, caso esteja visível    
            label1.Visible = true;
            textBox1.Visible = true;
            label2.Visible = true;
            textBox2.Visible = true;
            button7.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") //Se o nome não estiver preenchido
            {
                MessageBox.Show("Informe o nome para efetuar o cadastro!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else //Se o nome e a senha estiver preenchido corretamente
            {
                //botão dialog pergunta: "Deseja realmente excluir este produto?"
                DialogResult confirm = MessageBox.Show("Tem certeza que deseja excluir este usuario?", "Salvar Arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                //Em caso afirmativo, exclui
                if (confirm.ToString().ToUpper() == "YES")
                {
                    try
                    {

                        //passa a string de conexão 
                        conexao = new SqlConnection("Data Source=DESKTOP-K8CN5AA\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");
                        strSQL = "INSERT INTO usuario (nome, senha)" + "VALUES('" + textBox1.Text + "' ,'" + textBox2.Text + "')";
                        // Preparando a conexão
                        comando = new SqlCommand(strSQL, conexao);


                        conexao.Open();

                        dr = comando.ExecuteReader();

                        textBox1.Text = "";
                        textBox2.Text = "";

                        MessageBox.Show("Usuário cadastrado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void button4_Click_1(object sender, EventArgs e)
        {
            Frm_inicial ini = new Frm_inicial();
            ini.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "") //Se o nome do ou senha não estiver preenchido
            {
                MessageBox.Show("Informe o nome e a senha para efetuar o cadastro!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else //Se o nome e a senha estiver preenchido corretamente
            {
                try
                {

                    //passa a string de conexão 
                    conexao = new SqlConnection("Data Source=DESKTOP-K8CN5AA\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");
                    strSQL = "INSERT INTO usuario (nome, senha)" + "VALUES('" + textBox1.Text + "' ,'" + textBox2.Text + "')";
                    // Preparando a conexão
                    comando = new SqlCommand(strSQL, conexao);


                    conexao.Open();

                    dr = comando.ExecuteReader();

                    textBox1.Text = "";
                    textBox2.Text = "";
                    
                    MessageBox.Show("Usuário cadastrado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
