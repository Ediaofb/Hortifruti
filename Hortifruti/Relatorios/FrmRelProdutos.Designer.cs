namespace Hortifruti.Relatorios
{
    partial class FrmRelProdutos
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.btn_consult_rel_vendas = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tb_produtos = new System.Windows.Forms.TextBox();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.hortifruti_dbDataSet6 = new Hortifruti.hortifruti_dbDataSet6();
            this.produtoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.produtoTableAdapter = new Hortifruti.hortifruti_dbDataSet6TableAdapters.ProdutoTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.hortifruti_dbDataSet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_consult_rel_vendas
            // 
            this.btn_consult_rel_vendas.Font = new System.Drawing.Font("Georgia", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_consult_rel_vendas.Location = new System.Drawing.Point(753, 33);
            this.btn_consult_rel_vendas.Name = "btn_consult_rel_vendas";
            this.btn_consult_rel_vendas.Size = new System.Drawing.Size(99, 28);
            this.btn_consult_rel_vendas.TabIndex = 14;
            this.btn_consult_rel_vendas.Text = "CONSULTAR";
            this.btn_consult_rel_vendas.UseVisualStyleBackColor = true;
            this.btn_consult_rel_vendas.Click += new System.EventHandler(this.btn_consult_rel_vendas_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(210, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 12;
            this.label3.Text = "Produto:";
            // 
            // tb_produtos
            // 
            this.tb_produtos.Location = new System.Drawing.Point(274, 38);
            this.tb_produtos.Name = "tb_produtos";
            this.tb_produtos.Size = new System.Drawing.Size(417, 20);
            this.tb_produtos.TabIndex = 15;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.produtoBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Hortifruti.Relatorios.RelProdutos.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 104);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1036, 497);
            this.reportViewer1.TabIndex = 16;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load_1);
            // 
            // hortifruti_dbDataSet6
            // 
            this.hortifruti_dbDataSet6.DataSetName = "hortifruti_dbDataSet6";
            this.hortifruti_dbDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // produtoBindingSource
            // 
            this.produtoBindingSource.DataMember = "Produto";
            this.produtoBindingSource.DataSource = this.hortifruti_dbDataSet6;
            // 
            // produtoTableAdapter
            // 
            this.produtoTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRelProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 613);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.tb_produtos);
            this.Controls.Add(this.btn_consult_rel_vendas);
            this.Controls.Add(this.label3);
            this.Name = "FrmRelProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Produtos";
            this.Load += new System.EventHandler(this.FrmRelProdutos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hortifruti_dbDataSet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.produtoBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btn_consult_rel_vendas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tb_produtos;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private hortifruti_dbDataSet6 hortifruti_dbDataSet6;
        private System.Windows.Forms.BindingSource produtoBindingSource;
        private hortifruti_dbDataSet6TableAdapters.ProdutoTableAdapter produtoTableAdapter;
    }
}