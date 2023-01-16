namespace Hortifruti.Relatorios
{
    partial class FrmRelProdutor
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
            this.produtorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hortifruti_dbDataSet6 = new Hortifruti.hortifruti_dbDataSet6();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.tb_produtor = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.produtorTableAdapter = new Hortifruti.hortifruti_dbDataSet6TableAdapters.ProdutorTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.produtorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hortifruti_dbDataSet6)).BeginInit();
            this.SuspendLayout();
            // 
            // produtorBindingSource
            // 
            this.produtorBindingSource.DataMember = "Produtor";
            this.produtorBindingSource.DataSource = this.hortifruti_dbDataSet6;
            // 
            // hortifruti_dbDataSet6
            // 
            this.hortifruti_dbDataSet6.DataSetName = "hortifruti_dbDataSet6";
            this.hortifruti_dbDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet2";
            reportDataSource1.Value = this.produtorBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Hortifruti.Relatorios.RelProdutor.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 99);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1049, 496);
            this.reportViewer1.TabIndex = 0;
            // 
            // tb_produtor
            // 
            this.tb_produtor.Location = new System.Drawing.Point(262, 23);
            this.tb_produtor.Name = "tb_produtor";
            this.tb_produtor.Size = new System.Drawing.Size(488, 20);
            this.tb_produtor.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(189, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Produtor:";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(768, 17);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 31);
            this.button1.TabIndex = 3;
            this.button1.Text = "Consultar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // produtorTableAdapter
            // 
            this.produtorTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRelProdutor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1073, 607);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_produtor);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmRelProdutor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Produtores";
            this.Load += new System.EventHandler(this.FrmrRelProdutorcs_Load);
            ((System.ComponentModel.ISupportInitialize)(this.produtorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hortifruti_dbDataSet6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.TextBox tb_produtor;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private hortifruti_dbDataSet6 hortifruti_dbDataSet6;
        private System.Windows.Forms.BindingSource produtorBindingSource;
        private hortifruti_dbDataSet6TableAdapters.ProdutorTableAdapter produtorTableAdapter;
    }
}