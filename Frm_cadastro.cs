using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
//using MySql.Data.MySqlClient;

namespace Hortifruti
{
    public partial class Frm_cadastro : Form
    {
        SqlConnection conexao;
        SqlCommand comando, comando2;
        SqlDataReader dr, dr2;
        string strSQL, aux, aux1, verifica;


        public Frm_cadastro()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox6.Enabled = true;
            textBox6.Enabled = true;
            btn_editar.Visible = true;
        }


        void btn_cadastrar_produto_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text == "") //Se o nome do produto não estiver selecionado
            {
                MessageBox.Show("Informe o Nome do produto para efetuar o cadastro!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else //Se o nome do produto estiver preenchido corretamente
            {
                try
                {
                    if (comboBox5.SelectedIndex != 20)//Se o produto selecionado é diferente de "Outro..."
                    {
                        conexao = new SqlConnection("Data Source=EDSON-PC\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");
                        verifica = "SELECT Nome from Produto Where Nome = '" + comboBox5.Text + "'"; //Seleciona o nome do produto selceionado para verificar se ele já existe

                        SqlCommand command = new SqlCommand(verifica, conexao);

                        conexao.Open();

                        var result = command.ExecuteScalar();

                        // Call Read before accessing data.
                        if (result != null) //Se já existe produto com o nome do que se deseja inserir
                        {
                            MessageBox.Show("Este produto já está cadastrado! Caso seja necessário, edite-o!");
                        }
                        else //Se o produto desejado ainda não foi cadastrado
                        {
                            //passa a string de conexão 
                            conexao = new SqlConnection("Data Source=EDSON-PC\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");
                            strSQL = "INSERT INTO produto (nome, preço)" + "VALUES('" + comboBox5.Text + "' , '" + textBox3.Text + "')";
                            // Preparando a conexão
                            comando = new SqlCommand(strSQL, conexao);

                            conexao.Open();

                            dr = comando.ExecuteReader();

                            comboBox5.Text = "";
                            textBox1.Text = "";
                            textBox3.Text = "";

                            MessageBox.Show("Produto cadastrado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
                    }
                    else//Se o produto selecionado é igual a "Outro..." (Não está na lista do ComboBox, é "personalizado")
                    {
                        conexao = new SqlConnection("Data Source=EDSON-PC\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");
                        verifica = "SELECT Nome from Produto Where Nome = '" + textBox1.Text + "'";

                        SqlCommand command = new SqlCommand(verifica, conexao);

                        conexao.Open();

                        var result = command.ExecuteScalar();

                        // Call Read before accessing data.
                        if (result != null) //Se já existe produto com o nome do que se deseja inserir
                        {
                            MessageBox.Show("Este produto já está cadastrado! Caso seja necessário, edite-o!");
                        }

                        else
                        {
                            //passa a string de conexão 
                            conexao = new SqlConnection("Data Source=EDSON-PC\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");
                            strSQL = "INSERT INTO produto (nome, preço)" + "VALUES('" + textBox1.Text + "' , '" + textBox3.Text + "')";
                            // Preparando a conexão
                            comando = new SqlCommand(strSQL, conexao);

                            conexao.Open();

                            dr = comando.ExecuteReader();

                            comboBox5.Text = "";
                            textBox1.Text = "";
                            textBox3.Text = "";

                            MessageBox.Show("Produto cadastrado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        }
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

        void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        void textBox3_MouseClick(object sender, MouseEventArgs e)
        {
            textBox3.Text = "";
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            Frm_inicial frm2 = new Frm_inicial();
            frm2.Show();
            this.Hide();
        }

        private void btn_excluir_produto_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text == "") //Se o nome do produto não estiver preenchido
            {
                MessageBox.Show("Informe o Nome do produto para efetuar a exclusão!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else //Se o nome do produto estiver preenchido corretamente
            {
                //botão dialog pergunta: "Deseja realmente excluir este produto?"
                DialogResult confirm = MessageBox.Show("Tem certeza que deseja excluir este produto?", "Salvar Arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                //Em caso afirmativo, exclui
                if (confirm.ToString().ToUpper() == "YES")
                {
                    try
                    {
                        //passa a string de conexão
                        conexao = new SqlConnection("Data Source=EDSON-PC\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");

                        aux = "SELECT idProduto from produto WHERE nome = @nome";
                        comando = new SqlCommand(aux, conexao);
                        comando.Parameters.AddWithValue("@nome", comboBox5.Text);
                        comando.CommandType = CommandType.Text;
                        conexao.Open();

                        dr = comando.ExecuteReader();

                        if (dr.Read())
                        {
                            aux1 = dr.GetInt32(0).ToString();
                            dr.Close();
                            conexao.Close();
                            comando = null;

                            int aux_int;
                            aux_int = Int32.Parse(aux1);

                            strSQL = "DELETE from produto WHERE idproduto = @id";
                            // Preparando a conexão
                            comando = new SqlCommand(strSQL, conexao);
                            comando.Parameters.AddWithValue("@id", aux1);
                            comando.CommandType = CommandType.Text;
                            conexao.Open();

                            dr = comando.ExecuteReader();

                            MessageBox.Show("Produto excluído com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            dr.Close();
                        }
                        else
                        {
                            MessageBox.Show("Produto não encontrado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btn_edita_produto_Click(object sender, EventArgs e)
        {
            if (comboBox5.Text == "") //Se não foi digitado informação alguma
            {
                MessageBox.Show("Informe o Nome do produto para editar o cadastro!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Preencha todos os campos do produto abixo para realizar a alteração!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                textBox2.Enabled = true;
                textBox6.Enabled = true;
                comboBox8.Enabled = true;
                btn_editar.Enabled = true;
                btnVoltar.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void cadastrar_cliente_Click(object sender, EventArgs e) //Botão cadastrar cliente
        {
            if (textBox_nome_cliente.Text == "") //Se o nome do cliente não estiver preenchido
            {
                MessageBox.Show("Informe o Nome do cliente para efetuar o cadastro!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else //Se o nome do cliente estiver preenchido corretamente
            {
                try
                {
                    conexao = new SqlConnection("Data Source=EDSON-PC\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");
                    verifica = "SELECT Nome from Cliente Where Nome = '" + textBox_nome_cliente.Text + "'"; //Seleciona o nome do produto selceionado para verificar se ele já existe

                    SqlCommand command = new SqlCommand(verifica, conexao);

                    conexao.Open();

                    var result = command.ExecuteScalar();

                    // Call Read before accessing data.
                    if (result != null) //Se já existe produto com o nome do que se deseja inserir
                    {
                        MessageBox.Show("Este cliente já está cadastrado! Caso seja necessário, edite-o!");
                    }
                    else //Se o produto desejado ainda não foi cadastrado
                    {
                        //passa a string de conexão
                        conexao = new SqlConnection("Data Source=EDSON-PC\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");
                        strSQL = "INSERT INTO cliente (nome, endereco, telefone, e_mail)" + "VALUES('" + textBox_nome_cliente.Text + "' ,'" + textBox_endereco_cliente.Text + "' , '" + textBox_tel_cliente.Text + "' , '" + textBox_email_cliente.Text + "')";
                        // Preparando a conexão
                        comando = new SqlCommand(strSQL, conexao);
                        /*comando.Parameters.AddWithValue("@NOME", txtUsuario.Text);
                        comando.Parameters.AddWithValue("@SENHA",txtSenha.Text);*/

                        conexao.Open();

                        dr = comando.ExecuteReader();

                        textBox_nome_cliente.Text = "";
                        textBox_endereco_cliente.Text = "";
                        textBox_tel_cliente.Text = "";
                        textBox_email_cliente.Text = "";

                        MessageBox.Show("Cliente cadastrado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void btn_edita_cliente_Click_1(object sender, EventArgs e)
        {
            if (textBox_nome_cliente.Text == "") //Se não foi digitado informação alguma para nome do cliente
            {
                MessageBox.Show("Informe o Nome do cliente para editar o cadastro!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Preencha todos os campos para realizar a alteração!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox_novo_nome_cliente.Enabled = true;
                textBox_novo_ender_cliente.Enabled = true;
                textBox_novo_tel_cliente.Enabled = true;
                textBox_novo_email_cliente.Enabled = true;
                btn_edita_cliente_r.Enabled = true;
            }

            //MessageBox.Show("Prencha todos os campos, mesmo que não for alterá-los.");
        }

        private void btn_excluir_cliente_Click(object sender, EventArgs e)
        {
            if (textBox_nome_cliente.Text != "") //Se o nome do cliente não estiver preenchido
            {
                //botão dialog pergunta: "Deseja realmente excluir este produto?"
                DialogResult confirm = MessageBox.Show("Tem certeza que deseja excluir este cliente?", "Salvar Arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                //Em caso afirmativo, exclui
                if (confirm.ToString().ToUpper() == "YES")
                {
                    try
                    {
                        //passa a string de conexão
                        conexao = new SqlConnection("Data Source=EDSON-PC\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");

                        aux = "SELECT id_cliente from Cliente WHERE nome = @nome";
                        comando = new SqlCommand(aux, conexao);
                        comando.Parameters.AddWithValue("@nome", textBox_nome_cliente.Text);
                        comando.CommandType = CommandType.Text;
                        conexao.Open();
                        dr = comando.ExecuteReader();

                        if (dr.Read())
                        {
                            aux1 = dr.GetInt32(0).ToString();
                            dr.Close();
                            conexao.Close();
                            comando = null;

                            int aux_int;
                            aux_int = Int32.Parse(aux1);

                            strSQL = "DELETE from cliente WHERE Id_cliente = @id";
                            // Preparando a conexão
                            comando = new SqlCommand(strSQL, conexao);
                            comando.Parameters.AddWithValue("@id", aux_int);
                            comando.CommandType = CommandType.Text;

                            conexao.Open();
                            comando.ExecuteReader();
                            comando = null;

                            MessageBox.Show("Cliente excluído com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            textBox_nome_cliente.Text = "";
                            textBox_endereco_cliente.Text = "";
                            textBox_tel_cliente.Text = "";
                            textBox_email_cliente.Text = "";

                            conexao.Close();
                        }
                        else
                        {
                            MessageBox.Show("Cliente não encontrado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

            else //Se o nome do cliente estiver preenchido corretamente
            {
                MessageBox.Show("Informe o Nome do cliente para efetuar a exclusão!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void TextBox_email_cliente_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_voltar_cliente_Click(object sender, EventArgs e)
        {
            Frm_inicial frm2 = new Frm_inicial();
            frm2.Show();
            Hide();
        }

        private void btn_edita_cliente_r_Click(object sender, EventArgs e)
        {
            if (textBox_nome_cliente.Text != "") //Se foi preenchido o nome do cliente
            {
                //botão dialog pergunta: "Deseja realmente editar este cliente?"
                DialogResult confirm = MessageBox.Show("Deseja realmente editar este cliente?", "Salvar Arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                //Em caso afirmativo, edita
                if (confirm.ToString().ToUpper() == "YES")
                {
                    if (textBox_novo_nome_cliente.Text != "") //Se o novo nome do cliente a ser editado não estiver vazio  
                    {
                        try
                        {
                            conexao = new SqlConnection("Data Source=EDSON-PC\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");

                            aux = "SELECT Id_cliente from CLIENTE WHERE Nome = @nome";
                            comando = new SqlCommand(aux, conexao);
                            comando.Parameters.AddWithValue("@nome", textBox_nome_cliente.Text);
                            comando.CommandType = CommandType.Text;
                            conexao.Open();

                            dr = comando.ExecuteReader();

                            if (dr.Read())
                            {
                                aux1 = dr.GetInt32(0).ToString();
                                dr.Close();
                                conexao.Close();

                                int aux_int;
                                aux_int = Int32.Parse(aux1);

                                strSQL = "UPDATE cliente SET nome = @nome, endereco = @endereco, telefone = @telefone, e_mail = @e_mail WHERE nome = '" + textBox_nome_cliente.Text + "' ";

                                //preparando a conexao
                                comando = new SqlCommand(strSQL, conexao);
                                comando.Parameters.AddWithValue("@nome", textBox_novo_nome_cliente.Text);
                                comando.Parameters.AddWithValue("@endereco", textBox_novo_ender_cliente.Text);
                                comando.Parameters.AddWithValue("@telefone", textBox_novo_tel_cliente.Text);
                                comando.Parameters.AddWithValue("@e_mail", textBox_novo_email_cliente.Text);

                                conexao.Open();
                                comando.ExecuteReader();
                                comando = null;

                                textBox_nome_cliente.Text = "";
                                textBox_endereco_cliente.Text = "";
                                textBox_tel_cliente.Text = "";
                                textBox_email_cliente.Text = "";
                                textBox_novo_nome_cliente.Text = "";
                                textBox_novo_ender_cliente.Text = "";
                                textBox_novo_tel_cliente.Text = "";
                                textBox_novo_email_cliente.Text = "";

                                MessageBox.Show("Cliente editado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                conexao.Close();
                            }
                            else
                            {
                                MessageBox.Show("Cliente não encontrado!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    else //Se o novo nome do produto a ser editado estiver vazio
                    {
                        MessageBox.Show("Preencha o novo nome do cliente para editá-lo!");
                    }
                }
            }
            else
            {
                MessageBox.Show("Preencha o nome do cliente para editá-lo", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btn_cadastrar_forn_Click(object sender, EventArgs e)
        {
            if (textBox_nome_fornecedor.Text == "") //Se o nome do fornecedor não estiver preenchido
            {
                MessageBox.Show("Informe o Nome do produtor para efetuar o cadastro!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else //Se o nome do fornecedor estiver preenchido corretamente
            {
                try
                {
                    conexao = new SqlConnection("Data Source=EDSON-PC\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");
                    verifica = "SELECT Nome from Produtor Where Nome = '" + textBox_nome_fornecedor.Text + "'"; //Seleciona o nome do produto selceionado para verificar se ele já existe

                    SqlCommand command = new SqlCommand(verifica, conexao);

                    conexao.Open();

                    var result = command.ExecuteScalar();

                    // Call Read before accessing data.
                    if (result != null) //Se já existe produto com o nome do que se deseja inserir
                    {
                        MessageBox.Show("Este fornecedor já está cadastrado! Caso seja necessário, edite-o!");
                    }
                    else //Se o produto desejado ainda não foi cadastrado
                    {
                        //passa a string de conexão
                        conexao = new SqlConnection("Data Source=EDSON-PC\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");
                        strSQL = "INSERT INTO produtor (nome, endereco, telefone, e_mail)" + "VALUES('" + textBox_nome_fornecedor.Text + "' ,'" + textBox_ender_fornecedor.Text + "' , '" + textBox_telefone_fornecedor.Text + "' , '" + textBox_email_fornecedor.Text + "')";
                        // Preparando a conexão
                        comando = new SqlCommand(strSQL, conexao);
                        /*comando.Parameters.AddWithValue("@NOME", txtUsuario.Text);
                        comando.Parameters.AddWithValue("@SENHA",txtSenha.Text);*/

                        conexao.Open();

                        dr = comando.ExecuteReader();

                        textBox_nome_fornecedor.Text = "";
                        textBox_ender_fornecedor.Text = "";
                        textBox_telefone_fornecedor.Text = "";
                        textBox_email_fornecedor.Text = "";

                        MessageBox.Show("Produtor cadastrado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void btn_voltar_f_Click(object sender, EventArgs e)
        {
            Frm_inicial frm2 = new Frm_inicial();
            frm2.Show();
            Hide();
        }

        private void btn_editar_forn_Click(object sender, EventArgs e)
        {
            if (textBox_nome_fornecedor.Text == "") //Se não foi digitado informação algumao nome do cliente
            {
                MessageBox.Show("Informe o Nome do produtor para editar o cadastro!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                MessageBox.Show("Preencha todos os campos para realizar a alteração!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox_novo_nome_fornecedor.Enabled = true;
                textBox_novo_ender_fornecedor.Enabled = true;
                textBox_novo_tel_fornecedor.Enabled = true;
                textBox_novo_email_fornecedor.Enabled = true;
                btn_editar_r_forn.Enabled = true;
            }

            //MessageBox.Show("Prencha todos os campos, mesmo que não for alterá-los.");
        }

        private void btn_editar_r_forn_Click(object sender, EventArgs e)
        {
            if (textBox_nome_fornecedor.Text != "")
            {
                //botão dialog pergunta: "Deseja realmente editar este produtor?"
                DialogResult confirm = MessageBox.Show("Deseja realmente editar este produtor?", "Salvar Arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                //Em caso afirmativo, edita
                if (confirm.ToString().ToUpper() == "YES")
                {
                    if (textBox_novo_nome_fornecedor.Text != "") //Se o novo nome do fornecedor a ser editado não estiver vazio
                    {

                        try
                        {
                            //passa a string de conexão
                            conexao = new SqlConnection("Data Source=EDSON-PC\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");

                            aux = "SELECT Id_produtor from produtor WHERE nome = @nome"; //obtendo o id do produto
                            comando = new SqlCommand(aux, conexao);
                            comando.Parameters.AddWithValue("@nome", textBox_nome_fornecedor.Text);
                            comando.CommandType = CommandType.Text;
                            conexao.Open();

                            dr = comando.ExecuteReader();

                            if (dr.Read())
                            {
                                aux1 = dr.GetInt32(0).ToString();
                                dr.Close();
                                conexao.Close();

                                int aux_int;
                                aux_int = Int32.Parse(aux1);

                                strSQL = "UPDATE produtor SET nome = @nome, endereco = @endereco, telefone = @telefone, e_mail = @e_mail WHERE Id_produtor = @id";
                                // Preparando a conexão
                                comando = new SqlCommand(strSQL, conexao);
                                comando.Parameters.AddWithValue("@nome", textBox_novo_nome_fornecedor.Text);
                                comando.Parameters.AddWithValue("@endereco", textBox_novo_ender_fornecedor.Text);
                                comando.Parameters.AddWithValue("@telefone", textBox_novo_tel_fornecedor.Text);
                                comando.Parameters.AddWithValue("@e_mail", textBox_novo_email_fornecedor.Text);
                                comando.Parameters.AddWithValue("@id", aux1);
                                comando.CommandType = CommandType.Text;

                                conexao.Open();
                                dr = comando.ExecuteReader();
                                comando = null;

                                textBox_nome_fornecedor.Text = "";
                                textBox_ender_fornecedor.Text = "";
                                textBox_telefone_fornecedor.Text = "";
                                textBox_email_fornecedor.Text = "";
                                textBox_novo_nome_fornecedor.Text = "";
                                textBox_novo_ender_fornecedor.Text = "";
                                textBox_novo_tel_fornecedor.Text = "";
                                textBox_novo_email_fornecedor.Text = "";

                                MessageBox.Show("Produtor Editado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                conexao.Close();
                            }
                            else
                            {
                                MessageBox.Show("Produtor não encontrado", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    else //Se o novo nome do produto a ser editado estiver vazio
                    {
                        MessageBox.Show("Preencha o novo nome do fornecedor para editá-lo!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("Preencha o nome do fornecedor para editá-lo", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void btn_cadastrar_venda_Click(object sender, EventArgs e)
        {
            //comboBox1.SelectedIndex = 0; //Definindo pagamento como 'não' efetuado inicialmente

            if ((textBox_preco_un.Text == "Utilize '.' e não ',' para decimal") || (textBox_preco_tot.Text == "Utilize '.' e não ',' para decimal")) //verificando se textboxes estão com texto inicial
            {
                textBox_preco_un.Text = ""; //limpando os textboxes
                textBox_preco_tot.Text = "";
            }


            if (comboBox6.Text == "" || textBox_preco_tot.Text == "") //Se o produto ou preço total não estiver preenchido
            {
                MessageBox.Show("Informe o Produto e o preço total da venda para efetuar o cadastro!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else //Se o produto e o preço total estiverem preenchidos corretamente
            {
                try
                {

                    //passa a string de conexão
                    conexao = new SqlConnection("Data Source=EDSON-PC\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");
                    strSQL = "INSERT INTO VENDAS (Nome_Produto, Data, Quantidade, Unidade, Preco_unitario, Preco_total, Cliente, Pagamento, Data_Vencimento, Condicao) VALUES(@nomeproduto, @data, @quantidade, @unidade, @precounitario, @precototal, @cliente, @pagamento, @data_venc, @condicao)";


                    // Preparando a conexão
                    comando = new SqlCommand(strSQL, conexao);
                    if (comboBox6.SelectedIndex != 20)//Se o produto selecionado for diferente de 'outro'
                        comando.Parameters.AddWithValue("@nomeproduto", comboBox6.Text);
                    else//Se o produto selecionado for igual a 'outro'
                            comando.Parameters.AddWithValue("@nomeproduto", textBox4.Text);                                
                    comando.Parameters.AddWithValue("@data", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                    comando.Parameters.AddWithValue("@quantidade", textBox_quantidade.Text);
                    comando.Parameters.AddWithValue("@unidade", comboBox9.Text);
                    comando.Parameters.AddWithValue("@precounitario", textBox_preco_un.Text);
                    comando.Parameters.AddWithValue("@precototal", textBox_preco_tot.Text);
                    comando.Parameters.AddWithValue("@cliente", textBox_cliente.Text);
                    if(comboBox1.SelectedIndex == 0)//Se o pagamento não foi realizado
                        comando.Parameters.AddWithValue("@pagamento", 'N');
                    else //Se o pagamento foi realizado
                        comando.Parameters.AddWithValue("@pagamento", 'S');
                    comando.Parameters.AddWithValue("@data_venc", dateTimePicker5.Value);
                    comando.Parameters.AddWithValue("@condicao", comboBox15.Text);

                        conexao.Open();

                    dr = comando.ExecuteReader();

                    comboBox6.Text = "";
                    textBox4.Text = "";
                    textBox_quantidade.Text = "";
                    textBox_preco_un.Text = "";
                    textBox_preco_tot.Text = "";
                    textBox_cliente.Text = "";
                    comboBox1.Text = "";
                    textBox4.Text = "";

                    MessageBox.Show("Venda cadastrada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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

        private void btn_voltar_venda_Click(object sender, EventArgs e)
        {
            Frm_inicial frm2 = new Frm_inicial();
            frm2.Show();
            Hide();
        }

        private void btn_editar_venda_r_Click(object sender, EventArgs e) //botão editar venda
        {
            if (comboBox7.Text == "" || dateTimePicker2.Text == "" || textBox_quantidade_novo.Text == "" || comboBox10.Text == "" || textBox_preco_tot_novo.Text == "")
            // Se o novo nome do produto a ser editado ou a nova data ou a nova quantidade ou o preço total estiver vazio
            {
                MessageBox.Show("Por favor, preencha o novo nome do produto, a data, a quantidade, a unidade e o preço total do produto para editar a venda!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else //Se o novo nome do produto a ser editado ou a nova data ou a nova quantidade ou o preço total não estiver vazio
            {
                //botão dialog pergunta: "Deseja realmente editar este produtor?" e armazena a resposta (SIM ou NÂO em MAIÚSCULO)
                DialogResult confirm = MessageBox.Show("Deseja realmente editar esta venda?", "Salvar Arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                //Em caso afirmativo, edita
                if (confirm.ToString().ToUpper() == "YES")// Se clicou no botão 'Sim'
                {
                    if (comboBox7.Text != "") //Se o produto novo não estiver vazio  
                    {                        
                        try
                        {
                            //passa a string de conexão
                            conexao = new SqlConnection("Data Source=EDSON-PC\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");

                            aux = "SELECT Id_vendas from Vendas WHERE Nome_Produto = @nome AND Cliente = @cliente AND Data = @data"; //obtendo o id do produto
                            comando = new SqlCommand(aux, conexao);
                            if (comboBox6.SelectedIndex != 20)//Se o produto selecionado é diferente de 'outro'
                                comando.Parameters.AddWithValue("@nome", comboBox6.Text);//Produto adquirido do comboBox6
                            else//Se o produto selecionado é igual a 'outro'
                                comando.Parameters.AddWithValue("@nome", textBox4.Text);//Produto adquirido do textBox4
                            comando.Parameters.AddWithValue("@cliente", textBox_cliente.Text);
                            comando.Parameters.AddWithValue("@data", dateTimePicker1.Value.ToString("yyyy-MM-dd"));
                            comando.CommandType = CommandType.Text;
                            conexao.Open();
                            dr = comando.ExecuteReader();

                            if (dr.Read())
                            {
                                aux1 = dr.GetInt32(0).ToString();
                                //MessageBox.Show("Pegou o id do produto, ele é = " + aux1);
                                dr.Close();
                                conexao.Close();
                                comando = null;

                                int aux_int;
                                aux_int = Int32.Parse(aux1);

                                strSQL = "UPDATE Vendas SET Nome_Produto = @nomeproduto, Data = @data, Data_Vencimento = @data_venc, Quantidade = @quantidade, Unidade = @unidade, Preco_unitario = @preco_unitario, Preco_total = @preco_total, Cliente = @cliente, Pagamento = @pagamento, Condicao = @condicao WHERE Id_vendas = @id";
                                // Preparando a conexão
                                comando2 = new SqlCommand(strSQL, conexao);
                                if (comboBox7.SelectedIndex != 20)//Se o produto selecionado for diferente de 'outro'
                                    comando2.Parameters.AddWithValue("@nomeproduto", comboBox7.Text);
                                else//Se o produto selecionado for igual a 'outro'
                                    comando.Parameters.AddWithValue("@nomeproduto", textBox5.Text);
                                comando2.Parameters.AddWithValue("@data", dateTimePicker2.Value.ToString("yyyy-MM-dd"));
                                comando2.Parameters.AddWithValue("@data_venc", dateTimePicker6.Value.ToString("yyyy-MM-dd"));
                                comando2.Parameters.AddWithValue("@quantidade", textBox_quantidade_novo.Text);
                                comando2.Parameters.AddWithValue("@unidade", comboBox10.Text);
                                comando2.Parameters.AddWithValue("@preco_unitario", textBox_preco_un_novo.Text);
                                comando2.Parameters.AddWithValue("@preco_total", textBox_preco_tot_novo.Text);
                                comando2.Parameters.AddWithValue("@cliente", textBox_cliente_novo.Text);
                                if (comboBox4.SelectedIndex == 0)//Se o pagamento não foi realizado
                                    comando2.Parameters.AddWithValue("@pagamento", 'N');
                                else//Se o pagamento foi realizado
                                    comando2.Parameters.AddWithValue("@pagamento", 'S');
                                comando2.Parameters.AddWithValue("@condicao", comboBox16.Text);
                                comando2.Parameters.AddWithValue("@id", aux1);
                                comando2.CommandType = CommandType.Text;
                                conexao.Open();

                                dr = comando2.ExecuteReader();

                                comboBox6.Text = "";
                                textBox_quantidade.Text = "";
                                comboBox9.Text = "";
                                textBox_preco_un.Text = "";
                                textBox_preco_tot.Text = "";
                                textBox_cliente.Text = "";
                                comboBox7.Text = "";
                                dateTimePicker2.Text = "";
                                textBox_quantidade_novo.Text = "";
                                comboBox10.Text = "";
                                textBox_preco_un_novo.Text = "";
                                textBox_preco_tot_novo.Text = "";
                                textBox_cliente_novo.Text = "";
                                comboBox4.Text = "";

                                MessageBox.Show("Venda Editada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                dr.Close();
                                comando2 = null;
                                conexao.Close();
                            }
                            else
                            {
                                comboBox6.Text = "";
                                textBox_quantidade.Text = "";
                                comboBox9.Text = "";
                                textBox_preco_un.Text = "";
                                textBox_preco_tot.Text = "";
                                textBox_cliente.Text = "";
                                comboBox7.Text = "";
                                dateTimePicker2.Text = "";
                                textBox_quantidade_novo.Text = "";
                                comboBox10.Text = "";
                                textBox_preco_un_novo.Text = "";
                                textBox_preco_tot_novo.Text = "";
                                textBox_cliente_novo.Text = "";
                                comboBox4.Text = "";

                                MessageBox.Show("Venda não encontrada", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    else //Se o novo nome do produto a ser editado estiver vazio
                    {
                        MessageBox.Show("Preencha o novo nome do produto para editar a venda!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void btn_editar_venda_Click(object sender, EventArgs e)
        {
            if (comboBox6.Text == "" || textBox_quantidade.Text == "" || textBox_preco_tot.Text == "" || dateTimePicker1.Text == "" || comboBox9.Text =="")
            //Verifica se o produto, a quantidade, o preço total e a data estão vazios
            {
                MessageBox.Show("Por favor, preencha corretamente o produto, a data, a quantidade, a unidade e o preço total da venda!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                comboBox7.Enabled = true;
                dateTimePicker2.Enabled = true;
                dateTimePicker6.Enabled = true;
                textBox_quantidade_novo.Enabled = true;
                textBox_preco_un_novo.Enabled = true;
                textBox_preco_tot_novo.Enabled = true;
                textBox_cliente_novo.Enabled = true;
                btn_editar_venda_r.Enabled = true;
                comboBox6.Enabled = true;
                comboBox16.Enabled = true;
                comboBox4.Enabled = true;
                comboBox10.Enabled = true;
            }
        }

        private void Frm_cadastro_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox_preco_un_MouseClick(object sender, MouseEventArgs e)
        {
            textBox_preco_un.Text = "";
        }

        private void textBox_preco_tot_MouseClick(object sender, MouseEventArgs e)
        {
            textBox_preco_tot.Text = "";
        }

        private void btn_excluir_venda_Click(object sender, EventArgs e) //Excluir venda
        {
            if (comboBox6.Text == "" || dateTimePicker1.Text == "" || textBox_cliente.Text == "") //Se o produto ou a data ou o nome do cliente não estiver preenchido
            {
                MessageBox.Show("Informe o Produto, a data e o nome do cliente para efetuar a exclusão!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else //Se o nome do cliente estiver preenchido corretamente
            {
                //botão dialog pergunta: "Deseja realmente excluir esta venda?"
                DialogResult confirm = MessageBox.Show("Tem certeza que deseja excluir esta venda?", "Salvar Arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                //Em caso afirmativo, exclui
                if (confirm.ToString().ToUpper() == "YES")
                {
                    try
                    {
                        //passa a string de conexão
                        conexao = new SqlConnection("Data Source=DESKTOP-K8CN5AA\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");

                        aux = "SELECT Id_Vendas FROM Vendas WHERE Cliente = @cliente AND Nome_Produto = @nomeproduto AND Data = @data AND Preco_total = @precototal";
                        comando = new SqlCommand(aux, conexao);
                        comando.Parameters.AddWithValue("@cliente", textBox_cliente.Text);
                        if (comboBox6.SelectedIndex != 20)//Se o produto selecionado for diferente de 'outro'
                            comando.Parameters.AddWithValue("@nomeproduto", comboBox6.Text);
                        else//Se o produto selecionado for igual a 'outro'
                            comando.Parameters.AddWithValue("@nomeproduto", textBox4.Text);
                        comando.Parameters.AddWithValue("@data", dateTimePicker1.Text);
                        comando.Parameters.AddWithValue("@precototal", textBox_preco_tot.Text);
                        conexao.Open();

                        dr = comando.ExecuteReader();

                        if (dr.Read())
                        {
                            aux1 = dr.GetInt32(0).ToString();
                            dr.Close();
                            conexao.Close();
                            comando = null;

                            int aux_int;
                            aux_int = Int32.Parse(aux1);

                            strSQL = "DELETE from Vendas WHERE Id_vendas = @id";
                            comando2 = new SqlCommand(strSQL, conexao);
                            comando2.Parameters.AddWithValue("@id", aux_int);                            
                            conexao.Open();

                            dr = comando2.ExecuteReader();

                            MessageBox.Show("Venda excluída com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            dr.Close();
                        }
                        else
                        {
                            MessageBox.Show("Venda não encontrada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e) // Cadastrando a compra
        {
            if (comboBox11.Text == "" || textBox8.Text == "" || textBox12.Text == "")
            {
                MessageBox.Show("Preencha no mínimo o produto, o preço total e o produtor para efetuar o cadastro!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {                
                try
                {
                        //passa a string de conexão 
                        conexao = new SqlConnection("Data Source=EDSON-PC\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");
                        strSQL = "INSERT INTO compra (data, produto, nome_produtor, quantidade, Valor_unitario, Valor_total, Pagamento, data_vencimento, Unidade)" + "VALUES(@data, @produto, @produtor, @quantidade, @valor_unit, @valor_tot, @pagamento, @data_venc, @unidade)";
                        // Preparando a conexão
                        comando = new SqlCommand(strSQL, conexao);
                        comando.Parameters.AddWithValue("@data", dateTimePicker3.Value.ToString("yyyy-MM-dd"));
                        if(comboBox11.SelectedIndex != 20)//Se o produto selecionado for diferente de 'outro'
                            comando.Parameters.AddWithValue("@produto", comboBox11.Text);
                        else//Se o produto selecionado for igual a 'outro'
                            comando.Parameters.AddWithValue("@produto", textBox7.Text);
                        comando.Parameters.AddWithValue("@produtor", textBox8.Text);
                        comando.Parameters.AddWithValue("@quantidade", textBox10.Text);
                        comando.Parameters.AddWithValue("@valor_unit", textBox11.Text);
                        comando.Parameters.AddWithValue("@valor_tot", textBox12.Text);
                        if(comboBox2.SelectedIndex == 0)//Se o pagamento não foi realizado
                            comando.Parameters.AddWithValue("@pagamento", 'N');
                        else //Se o pagamento foi realizado
                            comando.Parameters.AddWithValue("@pagamento", 'S');
                        comando.Parameters.AddWithValue("@data_venc", dateTimePicker7.Value);
                        comando.Parameters.AddWithValue("@unidade", comboBox13.Text);

                        conexao.Open();

                        dr = comando.ExecuteReader();

                        textBox7.Text = "";
                        textBox8.Text = "";
                        textBox10.Text = "";
                        comboBox11.Text = "";
                        comboBox13.Text = "";
                        textBox11.Text = "";
                        textBox12.Text = "";
                        textBox7.Text = "";

                    MessageBox.Show("Compra cadastrada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            
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

        private void button5_Click(object sender, EventArgs e)
        {
            Frm_inicial frm2 = new Frm_inicial();
            frm2.Show();
            Hide();
        }

        private void button3_Click(object sender, EventArgs e) //Excluir compra
        {
            if (comboBox11.Text == "" || dateTimePicker3.Text == "" || textBox8.Text == "") //Se o produto ou a data ou o nome do produtor não estiver preenchido
            {
                MessageBox.Show("Informe o Produto, a data e o nome do produtor para efetuar a exclusão!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else //Se o produto, data e nome do produtor estiver preenchido corretamente
            {
                //botão dialog pergunta: "Deseja realmente excluir esta compra?"
                DialogResult confirm = MessageBox.Show("Tem certeza que deseja excluir esta compra?", "Salvar Arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                //Em caso afirmativo, exclui
                if (confirm.ToString().ToUpper() == "YES")
                {
                    try
                    {
                        //passa a string de conexão
                        conexao = new SqlConnection("Data Source=EDSON-PC\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");

                        aux = "SELECT Id_Compra FROM Compra Where Nome_Produtor = @nomeprodutor AND Produto = @produto AND Data = @data";
                        comando = new SqlCommand(aux, conexao);
                        comando.Parameters.AddWithValue("@nomeprodutor", textBox8.Text);
                        if (comboBox11.SelectedIndex != 20)//Se o produto selecionado for diferente de 'outro'
                            comando.Parameters.AddWithValue("@produto", comboBox11.Text);
                        else//Se o produto selecionado for igual a 'outro'
                            comando.Parameters.AddWithValue("@produto", textBox7.Text);
                        comando.Parameters.AddWithValue("@data", dateTimePicker3.Text);
                        conexao.Open();

                        dr = comando.ExecuteReader();

                        if (dr.Read())
                        {
                            aux1 = dr.GetInt32(0).ToString();
                            dr.Close();
                            conexao.Close();
                            comando = null;

                            int aux_int;
                            aux_int = Int32.Parse(aux1);


                            strSQL = "DELETE from Compra WHERE Id_compra = @id";
                            comando2 = new SqlCommand(strSQL, conexao);
                            comando2.Parameters.AddWithValue("@id", aux_int);
                            conexao.Open();

                            dr = comando2.ExecuteReader();

                            textBox7.Text = "";
                            textBox8.Text = "";
                            textBox10.Text = "";
                            comboBox11.Text = "";
                            comboBox13.Text = "";
                            textBox11.Text = "";
                            textBox12.Text = "";

                            MessageBox.Show("Compra excluída com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                            dr.Close();
                        }
                        else
                        {
                            MessageBox.Show("Compra não encontrada!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void btn_excluir_forn_Click(object sender, EventArgs e)//Botão excluir fornecedor
        {
            if (textBox_nome_fornecedor.Text == "") //Se o nome do cliente não estiver preenchido
            {
                MessageBox.Show("Informe o Nome do fornecedor para efetuar a exclusão!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else //Se o nome do cliente estiver preenchido corretamente
            {
                //botão dialog pergunta: "Deseja realmente excluir este produto?"
                DialogResult confirm = MessageBox.Show("Tem certeza que deseja excluir este fornecedor?", "Salvar Arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                //Em caso afirmativo, exclui
                if (confirm.ToString().ToUpper() == "YES")
                {
                    try
                    {
                        //passa a string de conexão
                        conexao = new SqlConnection("Data Source=EDSON-PC\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");

                        aux = "DELETE FROM Produtor WHERE Nome = @nome";
                        comando = new SqlCommand(aux, conexao);
                        comando.Parameters.AddWithValue("@nome", textBox_nome_fornecedor.Text);
                        conexao.Open();

                        dr = comando.ExecuteReader();

                        MessageBox.Show("Fornecedor deletado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                        dr.Close();

                        textBox_nome_fornecedor.Text = "";
                        textBox_ender_fornecedor.Text = "";
                        textBox_telefone_fornecedor.Text = "";
                        textBox_email_fornecedor.Text = "";                        

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

        private void button2_Click_1(object sender, EventArgs e)//Botão editar compra
        {
            if (dateTimePicker3.Text == "" || comboBox11.Text == "" || textBox10.Text == "" || textBox12.Text == "")
            //Verifica se a data, o produto, a quantidade, o preço total estão vazios
            {
                MessageBox.Show("Por favor, preencha corretamente a data, o produto, a quantidade e o preço total da compra!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                dateTimePicker4.Enabled = true;
                dateTimePicker8.Enabled = true;
                comboBox12.Enabled = true;
                comboBox14.Enabled = true;
                textBox9.Enabled = true;
                textBox15.Enabled = true;
                textBox16.Enabled = true;
                textBox17.Enabled = true;
                textBox18.Enabled = true;
                comboBox3.Enabled = true;
                button4.Enabled = true;
            }
        }

        private void label39_Click(object sender, EventArgs e)
        {

        }               

        private void textBox_preco_un_novo_MouseClick(object sender, MouseEventArgs e)
        {
            textBox_preco_un_novo.Text = "";
        }

        private void textBox_preco_tot_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_MouseClick(object sender, MouseEventArgs e)
        {
            textBox11.Text = "";
        }

        private void textBox12_MouseClick(object sender, MouseEventArgs e)
        {
            textBox12.Text = "";
        }

        private void textBox17_MouseClick(object sender, MouseEventArgs e)
        {
            textBox17.Text = "";
        }

        private void textBox18_MouseClick(object sender, MouseEventArgs e)
        {
            textBox18.Text = "";
        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox5.SelectedIndex == 20)
            {
                label6.Visible = true;
                textBox1.Visible = true;
            }
            else
            {
                label6.Visible = false;
                textBox1.Visible = false;
            }
            
        }

        private void comboBox8_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox8.SelectedIndex == 20)
            {
                label9.Visible = true;
                textBox2.Visible = true;
            }
            else
            {
                label9.Visible = false;
                textBox2.Visible = false;
            }
        }

        private void label51_Click(object sender, EventArgs e)
        {

        }

        private void label52_Click(object sender, EventArgs e)
        {

        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox6.SelectedIndex == 20)                                     
            {
                textBox4.Visible = true;
                label53.Visible = true;                
            }
            else
            {
                textBox4.Visible = false;
                label53.Visible = false;                
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(comboBox7.SelectedIndex == 20)
            {
                label54.Visible = true;
                textBox5.Visible = true;
            }
            else
            {
                label54.Visible = false;
                textBox5.Visible = false;
            }
        }

        private void label56_Click(object sender, EventArgs e)
        {

        }

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox11.SelectedIndex == 20)
            {
                label55.Visible = true;
                textBox7.Visible = true;
            }
            else
            {
                label55.Visible = false;
                textBox7.Visible = false;
            }
        }

        private void label36_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void label59_Click(object sender, EventArgs e)
        {

        }

        private void label50_Click(object sender, EventArgs e)
        {

        }

        private void label48_Click(object sender, EventArgs e)
        {

        }

        private void label44_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker5_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker5.Value = dateTimePicker1.Value.AddDays(30);
        }

        private void dateTimePicker6_ValueChanged(object sender, EventArgs e)
        {
            dateTimePicker6.Value = dateTimePicker2.Value.AddDays(30);
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            
        }

        private void textBox_preco_tot_novo_MouseClick(object sender, MouseEventArgs e)
        {
            textBox_preco_tot_novo.Text = "";
        }
        

        private void button4_Click(object sender, EventArgs e) //Editar compra
        {
            if (dateTimePicker4.Text == "" || comboBox12.Text == "" || textBox16.Text == "" || textBox18.Text == "") //Se a nova data, o nome do produto, a quantidade e o valor total a serem editados não estiverem vazios
            {
                MessageBox.Show("Preencha a data, o novo nome do produto, a quantidade e o preço para editar a compra!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
            else //Se o novo nome do produto a ser editado estiver vazio
            {
                //botão dialog pergunta: "Deseja realmente editar este produtor?" e armazena a resposta (SIM ou NÃO - em MAIÚSCULO)
                DialogResult confirm = MessageBox.Show("Deseja realmente editar esta compra?", "Salvar Arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                //Em caso afirmativo, edita
                if (confirm.ToString().ToUpper() == "YES")
                {
                    if (comboBox12.Text != "" || textBox16.Text != "" || dateTimePicker4.Text != "" || textBox18.Text != "")
                    //Se o nome do produto ou a quantidade ou a data ou o preço total não estiverem vazios
                    {
                        try
                        {
                            //passa a string de conexão
                            conexao = new SqlConnection("Data Source=EDSON-PC\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");

                            aux = "SELECT Id_compra from Compra WHERE Produto = @produto AND Nome_Produtor = @nome_produtor AND data = @data"; //obtendo o id da venda
                            comando = new SqlCommand(aux, conexao);
                            if (comboBox11.SelectedIndex != 20)//Se o produto selecionado é diferente de 'outro'                                                          
                                comando.Parameters.AddWithValue("@produto", comboBox11.Text);
                            else//Se o produto selecionado é igual a 'outro'
                            {
                                textBox9.Enabled = true;
                                comando.Parameters.AddWithValue("@produto", textBox9.Text);
                            }
                                comando.Parameters.AddWithValue("@nome_produtor", textBox8.Text);
                                comando.Parameters.AddWithValue("@data", dateTimePicker3.Value.ToString("yyyy-MM-dd"));
                                comando.CommandType = CommandType.Text;
                                conexao.Open();
                                dr = comando.ExecuteReader();

                                if (dr.Read())
                                {
                                    aux1 = dr.GetInt32(0).ToString();
                                    //MessageBox.Show("Pegou o id do produto, ele é = " + aux1);                            
                                    dr.Close();
                                    conexao.Close();
                                    comando = null;

                                    int aux_int;
                                    aux_int = Int32.Parse(aux1);

                                    /*int valor = Convert.ToInt32(comboBox3.SelectedValue);
                                    MessageBox.Show("O valor recebido do pagamento editado é: "+ valor, "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);*/

                                    strSQL = "UPDATE Compra SET Produto = @produto, Data = @data, Data_Vencimento = @data_venc, Quantidade = @quantidade, Unidade = @unidade, Valor_unitario = @valor_unitario, Valor_total = @valor_total, Nome_produtor = @nome_produtor, Pagamento = @pago WHERE Id_compra = @id";
                                    // Preparando a conexão
                                    comando2 = new SqlCommand(strSQL, conexao);
                                    if (comboBox12.SelectedIndex != 20)//Se o novo produto selecionado for diferente de 'outro'
                                        comando2.Parameters.AddWithValue("@Produto", comboBox12.Text);
                                    else//Se o novo produto selecionado for igual a 'outro'
                                        comando2.Parameters.AddWithValue("@Produto", textBox9.Text);
                                    comando2.Parameters.AddWithValue("@data", dateTimePicker4.Value.ToString("yyyy-MM-dd"));
                                    comando2.Parameters.AddWithValue("@data_venc", dateTimePicker8.Value.ToString("yyyy-MM-dd"));
                                    comando2.Parameters.AddWithValue("@quantidade", textBox16.Text);
                                    comando2.Parameters.AddWithValue("@unidade", comboBox14.Text);
                                    comando2.Parameters.AddWithValue("@valor_unitario", textBox17.Text);
                                    comando2.Parameters.AddWithValue("@valor_total", textBox18.Text);
                                    comando2.Parameters.AddWithValue("@nome_produtor", textBox15.Text);                              
                                
                                    if (comboBox3.SelectedIndex == 0)
                                        comando2.Parameters.AddWithValue("@pago", 'N');
                                    else
                                        comando2.Parameters.AddWithValue("@pago", 'S');
                                    comando2.Parameters.AddWithValue("@id", aux_int);
                                    comando2.CommandType = CommandType.Text;
                                    conexao.Open();

                                    dr2 = comando2.ExecuteReader();

                                    textBox7.Text = "";
                                    textBox8.Text = "";
                                    textBox10.Text = "";
                                    textBox11.Text = "";
                                    textBox12.Text = "";
                                    comboBox2.Text = "";
                                    comboBox11.Text = "";
                                    comboBox12.Text = "";
                                    textBox9.Text = "";
                                    textBox16.Text = "";
                                    comboBox14.Text = "";
                                    textBox17.Text = "";
                                    textBox18.Text = "";
                                    textBox15.Text = "";
                                    comboBox3.Text = "";

                                    MessageBox.Show("Compra Editada com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                    dr2.Close();
                                    comando2 = null;
                                    conexao.Close();
                                }
                                else
                                {
                                    textBox7.Text = "";
                                    textBox8.Text = "";
                                    textBox10.Text = "";
                                    textBox11.Text = "";
                                    textBox12.Text = "";
                                    comboBox2.Text = "";
                                    comboBox11.Text = "";
                                    comboBox12.Text = "";
                                    textBox9.Text = "";
                                    textBox16.Text = "";
                                    comboBox14.Text = "";
                                    textBox17.Text = "";
                                    textBox18.Text = "";
                                    textBox15.Text = "";
                                    comboBox3.Text = "";

                                    MessageBox.Show("Compra não encontrada", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    else
                    {
                        MessageBox.Show("Preencha o novo nome do produto para editar a compra!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
        }

        private void btn_editar_Click(object sender, EventArgs e)//Botão editar produto
        {          

            if (comboBox5.Text != "")// Se foi preenchido o nome do produto
            {
                //botão dialog pergunta: "Deseja realmente editar este produto?"
                DialogResult confirm = MessageBox.Show("Deseja realmente editar este produto?", "Salvar Arquivo", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button2);

                //Em caso afirmativo, edita
                if (confirm.ToString().ToUpper() == "YES")
                {
                    if (comboBox8.Text != "") //Se o novo nome do produto a ser editado não estiver vazio  
                    {
                        if (comboBox5.SelectedIndex != 20) //Se o produto selecionado é diferente de "Outro...", se é um da lista do comboBox
                        {
                            try
                            {
                                //passa a string de conexão

                                conexao = new SqlConnection("Data Source=EDSON-PC\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");

                                aux = "SELECT idProduto from Produto WHERE Nome = @nome"; //obtendo o id do produto
                                comando = new SqlCommand(aux, conexao);
                                comando.Parameters.AddWithValue("@nome", comboBox5.Text);
                                comando.CommandType = CommandType.Text;
                                conexao.Open();
                                dr = comando.ExecuteReader();

                                if (dr.Read())
                                {
                                    aux1 = dr.GetInt32(0).ToString();
                                    //MessageBox.Show("Pegou o id do produto, ele é = " + aux1);
                                    dr.Close();
                                    conexao.Close();
                                    //conexao = null;

                                    int aux_int;
                                    aux_int = Int32.Parse(aux1);

                                    strSQL = "UPDATE produto SET nome = @nome, preço = @preço WHERE idProduto = @id";

                                    //preparando a conexão
                                    comando = new SqlCommand(strSQL, conexao);
                                    if (comboBox8.SelectedIndex != 20)//Se o novo nome do produto não for "Outro..."
                                    {
                                        comando.Parameters.AddWithValue("@nome", comboBox8.Text);
                                    }
                                    else
                                    {
                                        comando.Parameters.AddWithValue("@nome", textBox2.Text);
                                    }
                                    comando.Parameters.AddWithValue("@preço", textBox6.Text);
                                    comando.Parameters.AddWithValue("@id", aux_int);
                                    comando.CommandType = CommandType.Text;
                                    conexao.Open();

                                    dr2 = comando.ExecuteReader();

                                    //MessageBox.Show("Deu certo!");

                                    comando = null;

                                    comboBox5.Text = "";
                                    textBox3.Text = "";
                                    comboBox6.Text = "";
                                    textBox6.Text = "";

                                    MessageBox.Show("Produto editado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                    comando = null;
                                    conexao.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Produto Não encontrado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                        else //Se o nome atual do produto for personalizado
                        {
                            try
                            {
                                //passa a string de conexão

                                conexao = new SqlConnection("Data Source=EDSON-PC\\SQLEXPRESS;Initial Catalog=hortifruti_db;Integrated Security=True");

                                aux = "SELECT idProduto from Produto WHERE Nome = @nome"; //obtendo o id do produto
                                comando = new SqlCommand(aux, conexao);
                                comando.Parameters.AddWithValue("@nome", textBox1.Text);//Nome do produto personalizado
                                comando.CommandType = CommandType.Text;
                                conexao.Open();
                                dr = comando.ExecuteReader();

                                if (dr.Read())
                                {
                                    aux1 = dr.GetInt32(0).ToString();
                                    //MessageBox.Show("Pegou o id do produto, ele é = " + aux1);
                                    dr.Close();
                                    conexao.Close();
                                    //conexao = null;

                                    int aux_int;
                                    aux_int = Int32.Parse(aux1);

                                    strSQL = "UPDATE produto SET nome = @nome, preço = @preço WHERE idProduto = @id";

                                    //preparando a conexão
                                    comando = new SqlCommand(strSQL, conexao);
                                    if (comboBox8.SelectedIndex != 20)//Se o novo nome do produto não for "Outro..." 
                                        comando.Parameters.AddWithValue("@nome", comboBox8.Text);//nome do produto consta no comboBox8

                                    else
                                        comando.Parameters.AddWithValue("@nome", textBox2.Text);
                                    comando.Parameters.AddWithValue("@preço", textBox6.Text);
                                    comando.Parameters.AddWithValue("@id", aux_int);
                                    comando.CommandType = CommandType.Text;
                                    conexao.Open();

                                    dr2 = comando.ExecuteReader();

                                    //MessageBox.Show("Deu certo!");

                                    comando = null;

                                    comboBox5.Text = "";
                                    textBox3.Text = "";
                                    comboBox6.Text = "";
                                    textBox6.Text = "";

                                    MessageBox.Show("Produto editado com sucesso!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                                    comando = null;
                                    conexao.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Produto Não encontrado!", "Mensagem", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
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
                    else //Se o novo nome do produto a ser editado estiver vazio
                    {
                        MessageBox.Show("Preencha o novo nome do produto para editá-lo!", "Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            else
            {
                MessageBox.Show("Preencha o nome do produto para editá-lo","Atenção!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            
        }

        private void textBox6_MouseClick(object sender, MouseEventArgs e)
        {
            textBox6.Text = "";
        }        
    }
} 