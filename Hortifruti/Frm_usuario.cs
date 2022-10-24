using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Hortifruti
{
    public partial class Frm_usuario : Form
    {

        SqlConnection conexao;
        SqlCommand comando;
        SqlDataReader dr;
        string strSQL, verifica;

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
            else if (textBox1.Text == "ediao") //Se o novo nome do usuário for igual a ediao
            {
                MessageBox.Show("Este usuário não pode ser excluído!", "Mensagem!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        conexao = new SqlConnection("Data Source=EDSON-PC\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");
                        strSQL = "DELETE FROM Usuario WHERE Nome = '" +textBox1.Text + "'";
                        // Preparando a conexão
                        comando = new SqlCommand(strSQL, conexao);

                        conexao.Open();

                        dr = comando.ExecuteReader();

                        textBox1.Text = "";
                        textBox2.Text = "";

                        MessageBox.Show("Usuário excluído com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "ediao")
                MessageBox.Show("Este usuário não pode ser alterado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            else if (textBox3.Text == "" || textBox4.Text == "") //Se o novo nome do usuário ou a senha a serem editados não estiverem vazios
            {
                MessageBox.Show("Preencha o novo nome e a nova senha para editar o usuário!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                //botão dialog pergunta: "Deseja realmente editar este produto?"
                DialogResult confirm = MessageBox.Show("Deseja realmente editar este usuário?", "Salvar Arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                //Em caso afirmativo, edita
                if (confirm.ToString().ToUpper() == "YES")
                {
                    try
                    {
                        //passa a string de conexão
                        conexao = new SqlConnection("Data Source=DESKTOP-K8CN5AA\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");

                        strSQL = "UPDATE Usuario SET nome = @nome, senha = @senha WHERE nome = @nome_at";

                        //preparando a conexão
                        comando = new SqlCommand(strSQL, conexao);

                        comando.Parameters.AddWithValue("@nome", textBox3.Text);
                        comando.Parameters.AddWithValue("@senha", textBox4.Text);
                        comando.Parameters.AddWithValue("@nome_at", textBox1.Text);
                        comando.CommandType = CommandType.Text;
                        conexao.Open();

                        dr = comando.ExecuteReader();

                        //MessageBox.Show("Deu certo!");

                        comando = null;

                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        textBox4.Text = "";

                        MessageBox.Show("Usuário editado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        comando = null;
                        conexao.Close();
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
                    conexao = new SqlConnection("Data Source=EDSON-PC\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");
                    verifica = "SELECT Nome from Usuario Where Nome = '" + textBox1.Text + "'"; //Seleciona o nome do usuário escolhido para verificar se ele já existe 

                    SqlCommand command = new SqlCommand(verifica, conexao);

                    conexao.Open();

                    var result = comando.ExecuteScalar();

                    conexao.Close();

                    if(result != null) // Se o usuário desejado ainda não foi cadastrado
                    {
                        MessageBox.Show("Este usuário já está cadastrado! Caso seja necessário, edite-o!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                    else
                    {
                        strSQL = "INSERT INTO Usuario (nome, senha) VALUES('" + textBox1.Text + "' , '" + textBox2.Text + "')";
                        //Preparando a conexão
                        comando = new SqlCommand(strSQL, conexao);

                        conexao.Open();

                        dr = comando.ExecuteReader();

                        textBox1.Text = "";
                        textBox2.Text = "";

                        MessageBox.Show("Usuário cadastrado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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