using System;

namespace Hortifruti
{
    partial class FrmAviso
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblMensagem = new System.Windows.Forms.Label();
            this.lblContato = new System.Windows.Forms.Label();
            this.lblDiasRestantes = new System.Windows.Forms.Label();
            this.btnEntendi = new System.Windows.Forms.Button();

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
            this.lblTitulo.ForeColor =
                System.Drawing.Color.DarkOrange;
            this.lblTitulo.Location =
                new System.Drawing.Point(80, 20);
            this.lblTitulo.Size =
                new System.Drawing.Size(400, 30);
            this.lblTitulo.Text = "AVISO — MENSALIDADE PENDENTE";

            // lblDiasRestantes
            this.lblDiasRestantes.AutoSize = false;
            this.lblDiasRestantes.Font =
                new System.Drawing.Font(
                    "Arial", 11F,
                    System.Drawing.FontStyle.Bold);
            this.lblDiasRestantes.ForeColor =
                System.Drawing.Color.DarkRed;
            this.lblDiasRestantes.Location =
                new System.Drawing.Point(20, 80);
            this.lblDiasRestantes.Size =
                new System.Drawing.Size(460, 25);
            this.lblDiasRestantes.Text = "";
            // ↑ preenchido dinamicamente pelo Program.cs

            // lblMensagem
            this.lblMensagem.AutoSize = false;
            this.lblMensagem.Font =
                new System.Drawing.Font("Arial", 10F);
            this.lblMensagem.Location =
                new System.Drawing.Point(20, 115);
            this.lblMensagem.Size =
                new System.Drawing.Size(460, 60);
            this.lblMensagem.Text = "";
            // ↑ preenchido pelo construtor

            // lblContato
            this.lblContato.AutoSize = false;
            this.lblContato.Font =
                new System.Drawing.Font(
                    "Arial", 9F,
                    System.Drawing.FontStyle.Bold);
            this.lblContato.ForeColor =
                System.Drawing.Color.DarkBlue;
            this.lblContato.Location =
                new System.Drawing.Point(20, 185);
            this.lblContato.Size =
                new System.Drawing.Size(460, 20);
            this.lblContato.Text =
                "Suporte: (35)99902-2614  |  (35)99890-4196";

            // btnEntendi
            this.btnEntendi.Font =
                new System.Drawing.Font("Arial", 10F);
            this.btnEntendi.Location =
                new System.Drawing.Point(165, 225);
            this.btnEntendi.Size =
                new System.Drawing.Size(170, 36);
            this.btnEntendi.Text = "Entendi";
            this.btnEntendi.BackColor =
                System.Drawing.Color.DarkOrange;
            this.btnEntendi.ForeColor =
                System.Drawing.Color.White;
            this.btnEntendi.Click +=
                new System.EventHandler(this.btnEntendi_Click);

            // FrmAviso
            this.ClientSize =
                new System.Drawing.Size(500, 285);
            this.FormBorderStyle =
                System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.ControlBox = true; // ← permite fechar pelo X
            this.StartPosition =
                System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text =
                "Hortifruti — Aviso de Vencimento";

            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblTitulo);
            this.Controls.Add(this.lblDiasRestantes);
            this.Controls.Add(this.lblMensagem);
            this.Controls.Add(this.lblContato);
            this.Controls.Add(this.btnEntendi);

            ((System.ComponentModel.ISupportInitialize)
                (this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
        }


        // ── Declaração dos controles ─────────────────────────────────
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblTitulo;
        public System.Windows.Forms.Label lblDiasRestantes;
        public System.Windows.Forms.Label lblMensagem;
        private System.Windows.Forms.Label lblContato;
        private System.Windows.Forms.Button btnEntendi;
    }
}