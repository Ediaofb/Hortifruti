using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hortifruti
{
    partial class FrmBloqueio
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.lblContato = new System.Windows.Forms.Label();
            this.lblSenha = new System.Windows.Forms.Label();
            this.txtSenha = new System.Windows.Forms.TextBox();
            this.btnDesbloquear = new System.Windows.Forms.Button();
            this.btnSair = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)
                (this.pictureBox1)).BeginInit();
            this.SuspendLayout();

            // pictureBox1
            this.pictureBox1.Image =
                System.Drawing.SystemIcons.Warning.ToBitmap();
            this.pictureBox1.Location =
                new System.Drawing.Point(20, 20);
            this.pictureBox1.Size =
                new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode =
                System.Windows.Forms.PictureBoxSizeMode.StretchImage;

            // lblTitulo
            this.lblTitulo.AutoSize = false;
            this.lblTitulo.Font =
                new System.Drawing.Font(
                    "Arial", 13F,
                    System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTitulo.Location =
                new System.Drawing.Point(80, 20);
            this.lblTitulo.Size =
                new System.Drawing.Size(400, 30);
            this.lblTitulo.Text = "SISTEMA BLOQUEADO";

            // lblMensagem
            this.lblMensagem.AutoSize = false;
            this.lblMensagem.Font =
                new System.Drawing.Font("Arial", 10F);
            this.lblMensagem.Location =
                new System.Drawing.Point(20, 85);
            this.lblMensagem.Size =
                new System.Drawing.Size(460, 50);
            this.lblMensagem.Text =
                "O período de uso do sistema está próximo do vencimento.\r\n"
              + "É necessário verificar com o suporte a possibilidade "
              + "de desbloqueio.";
            // ↑ esse texto será sobrescrito pelo construtor do FrmBloqueio.cs

            // lblContato
            this.lblContato.AutoSize = false;
            this.lblContato.Font =
                new System.Drawing.Font(
                    "Arial", 9F,
                    System.Drawing.FontStyle.Bold);
            this.lblContato.ForeColor = System.Drawing.Color.DarkBlue;
            this.lblContato.Location =
                new System.Drawing.Point(20, 140);
            this.lblContato.Size =
                new System.Drawing.Size(460, 20);
            this.lblContato.Text =
                "Suporte: (35) 99902-2614 / (35) 99890-4196";

            // lblSenha
            this.lblSenha.AutoSize = true;
            this.lblSenha.Font =
                new System.Drawing.Font("Arial", 10F);
            this.lblSenha.Location =
                new System.Drawing.Point(20, 180);
            this.lblSenha.Text = "Senha de desbloqueio:";

            // txtSenha
            this.txtSenha.Font =
                new System.Drawing.Font("Arial", 11F);
            this.txtSenha.Location =
                new System.Drawing.Point(20, 205);
            this.txtSenha.Size =
                new System.Drawing.Size(460, 28);
            this.txtSenha.PasswordChar = '*';

            // btnDesbloquear
            this.btnDesbloquear.Font =
                new System.Drawing.Font("Arial", 10F);
            this.btnDesbloquear.Location =
                new System.Drawing.Point(20, 255);
            this.btnDesbloquear.Size =
                new System.Drawing.Size(215, 36);
            this.btnDesbloquear.Text = "Desbloquear";
            this.btnDesbloquear.BackColor =
                System.Drawing.Color.DarkGreen;
            this.btnDesbloquear.ForeColor =
                System.Drawing.Color.White;
            this.btnDesbloquear.Click +=
                new System.EventHandler(this.btnDesbloquear_Click);
            // ↑ aponta para o método em FrmBloqueio.cs

            // btnSair
            this.btnSair.Font =
                new System.Drawing.Font("Arial", 10F);
            this.btnSair.Location =
                new System.Drawing.Point(265, 255);
            this.btnSair.Size =
                new System.Drawing.Size(215, 36);
            this.btnSair.Text = "Fechar sistema";
            this.btnSair.BackColor = System.Drawing.Color.DarkRed;
            this.btnSair.ForeColor = System.Drawing.Color.White;
            this.btnSair.Click +=
                new System.EventHandler(this.btnSair_Click);
            // ↑ aponta para o método em FrmBloqueio.cs

            // FrmBloqueio (o próprio form)
            this.ClientSize = new System.Drawing.Size(500, 315);
            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = false; // remove o X — impede fechar
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hortifruti — Sistema Bloqueado";

            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblMensagem);
            this.Controls.Add(this.lblContato);
            this.Controls.Add(this.lblSenha);
            this.Controls.Add(this.txtSenha);
            this.Controls.Add(this.btnDesbloquear);
            this.Controls.Add(this.btnSair);

            ((System.ComponentModel.ISupportInitialize)
                (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        // ── Declaração dos controles ─────────────────────────────────
        // O Visual Studio exige que os controles usados no Designer.cs
        // sejam declarados aqui — é isso que resolve o erro
        // "não existe no contexto atual"
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.Label lblContato;
        private System.Windows.Forms.Label lblSenha;
        private System.Windows.Forms.TextBox txtSenha;
        private System.Windows.Forms.Button btnDesbloquear;
        private System.Windows.Forms.Button btnSair;
    }
}