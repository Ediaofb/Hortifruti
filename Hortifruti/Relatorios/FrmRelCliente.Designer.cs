namespace Hortifruti.Relatorios
{
    partial class FrmRelCliente
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
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.btn_consultar_clientes = new System.Windows.Forms.Button();
            this.tb_clientes = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clienteBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.hortifruti_dbDataSet6 = new Hortifruti.hortifruti_dbDataSet6();
            this.clienteTableAdapter = new Hortifruti.hortifruti_dbDataSet6TableAdapters.ClienteTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hortifruti_dbDataSet6)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.clienteBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Hortifruti.Relatorios.RelCliente.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 96);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(874, 505);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // btn_consultar_clientes
            // 
            this.btn_consultar_clientes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_consultar_clientes.Location = new System.Drawing.Point(598, 25);
            this.btn_consultar_clientes.Name = "btn_consultar_clientes";
            this.btn_consultar_clientes.Size = new System.Drawing.Size(81, 32);
            this.btn_consultar_clientes.TabIndex = 1;
            this.btn_consultar_clientes.Text = "Consultar";
            this.btn_consultar_clientes.UseVisualStyleBackColor = true;
            this.btn_consultar_clientes.Click += new System.EventHandler(this.btn_consultar_clientes_Click);
            // 
            // tb_clientes
            // 
            this.tb_clientes.Location = new System.Drawing.Point(176, 31);
            this.tb_clientes.Name = "tb_clientes";
            this.tb_clientes.Size = new System.Drawing.Size(405, 20);
            this.tb_clientes.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(105, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 16);
            this.label1.TabIndex = 3;
            this.label1.Text = "Cliente:";
            // 
            // clienteBindingSource
            // 
            this.clienteBindingSource.DataMember = "Cliente";
            this.clienteBindingSource.DataSource = this.hortifruti_dbDataSet6;
            // 
            // hortifruti_dbDataSet6
            // 
            this.hortifruti_dbDataSet6.DataSetName = "hortifruti_dbDataSet6";
            this.hortifruti_dbDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // clienteTableAdapter
            // 
            this.clienteTableAdapter.ClearBeforeFill = true;
            // 
            // FrmRelCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(898, 613);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tb_clientes);
            this.Controls.Add(this.btn_consultar_clientes);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmRelCliente";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reatório de Clientes";
            this.Load += new System.EventHandler(this.FrmRelCliente_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clienteBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hortifruti_dbDataSet6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Button btn_consultar_clientes;
        private System.Windows.Forms.TextBox tb_clientes;
        private System.Windows.Forms.Label label1;
        private hortifruti_dbDataSet6 hortifruti_dbDataSet6;
        private System.Windows.Forms.BindingSource clienteBindingSource;
        private hortifruti_dbDataSet6TableAdapters.ClienteTableAdapter clienteTableAdapter;
    }
}