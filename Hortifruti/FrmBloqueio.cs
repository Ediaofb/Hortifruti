using System;
using System.Windows.Forms;

namespace Hortifruti
{
    partial class FrmBloqueio : Form
    {
        public bool SenhaCorreta { get; private set; }

        //Recebe a mensagem de motivo do bloqueio
        public FrmBloqueio(string mensagem)
        {
            InitializeComponent();
            SenhaCorreta = false;
            lblMensagem.Text = mensagem;
        }

        private void btnDesbloquear_Click(object sender, EventArgs e)
        {
            string erro;

            if(VerificacaoLicenca.SenhaValida(txtSenha.Text, out erro))
            {
                SenhaCorreta = true;

                MessageBox.Show(
                    "Sistema desbloqueado com sucesso!",
                    "Sucesso",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                this.Close();                
            }
            else
            {
                string mensagemErro = string.IsNullOrEmpty(erro)
                    ? "Senha incorreta. Entre em contato com o suporte."
                    : erro;

                MessageBox.Show(
                    mensagemErro,
                    "Acesso negado",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                txtSenha.Clear();
                txtSenha.Focus();
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            SenhaCorreta = false;
            this.Close();
        }
    }
}