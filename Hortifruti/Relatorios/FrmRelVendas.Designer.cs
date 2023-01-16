namespace Hortifruti.Relatorios
{
    partial class FrmRelVendas
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_consult_rel_vendas = new System.Windows.Forms.Button();
            this.tb_clientes = new System.Windows.Forms.TextBox();
            this.hortifruti_dbDataSet6 = new Hortifruti.hortifruti_dbDataSet6();
            this.vendasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.vendasTableAdapter = new Hortifruti.hortifruti_dbDataSet6TableAdapters.VendasTableAdapter();
            this.hortifruti_dbDataSet61 = new Hortifruti.hortifruti_dbDataSet6();
            this.vendasBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.hortifruti_dbDataSet6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hortifruti_dbDataSet61)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendasBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.vendasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Hortifruti.Relatorios.RelVendas.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(12, 116);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1065, 485);
            this.reportViewer1.TabIndex = 0;
            this.reportViewer1.Load += new System.EventHandler(this.reportViewer1_Load);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Período de:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Até:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(115, 22);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(221, 20);
            this.dateTimePicker1.TabIndex = 3;
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(115, 56);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(219, 20);
            this.dateTimePicker2.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(366, 39);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 5;
            this.label3.Text = "CLiente:";
            // 
            // btn_consult_rel_vendas
            // 
            this.btn_consult_rel_vendas.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_consult_rel_vendas.Location = new System.Drawing.Point(909, 33);
            this.btn_consult_rel_vendas.Name = "btn_consult_rel_vendas";
            this.btn_consult_rel_vendas.Size = new System.Drawing.Size(99, 28);
            this.btn_consult_rel_vendas.TabIndex = 7;
            this.btn_consult_rel_vendas.Text = "CONSULTAR";
            this.btn_consult_rel_vendas.UseVisualStyleBackColor = true;
            this.btn_consult_rel_vendas.Click += new System.EventHandler(this.btn_consult_rel_vendas_Click);
            // 
            // tb_clientes
            // 
            this.tb_clientes.Location = new System.Drawing.Point(430, 38);
            this.tb_clientes.Name = "tb_clientes";
            this.tb_clientes.Size = new System.Drawing.Size(451, 20);
            this.tb_clientes.TabIndex = 8;
            // 
            // hortifruti_dbDataSet6
            // 
            this.hortifruti_dbDataSet6.DataSetName = "hortifruti_dbDataSet6";
            this.hortifruti_dbDataSet6.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vendasBindingSource
            // 
            this.vendasBindingSource.DataMember = "Vendas";
            this.vendasBindingSource.DataSource = this.hortifruti_dbDataSet6;
            // 
            // vendasTableAdapter
            // 
            this.vendasTableAdapter.ClearBeforeFill = true;
            // 
            // hortifruti_dbDataSet61
            // 
            this.hortifruti_dbDataSet61.DataSetName = "hortifruti_dbDataSet6";
            this.hortifruti_dbDataSet61.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // vendasBindingSource1
            // 
            this.vendasBindingSource1.DataMember = "Vendas";
            this.vendasBindingSource1.DataSource = this.hortifruti_dbDataSet61;
            // 
            // FrmRelVendas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 613);
            this.Controls.Add(this.tb_clientes);
            this.Controls.Add(this.btn_consult_rel_vendas);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FrmRelVendas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatório de Vendas";
            this.Load += new System.EventHandler(this.FrmRelVendas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.hortifruti_dbDataSet6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hortifruti_dbDataSet61)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vendasBindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_consult_rel_vendas;
        private System.Windows.Forms.TextBox tb_clientes;
        private hortifruti_dbDataSet6 hortifruti_dbDataSet6;
        private System.Windows.Forms.BindingSource vendasBindingSource;
        private hortifruti_dbDataSet6TableAdapters.VendasTableAdapter vendasTableAdapter;
        private System.Windows.Forms.BindingSource vendasBindingSource1;
        private hortifruti_dbDataSet6 hortifruti_dbDataSet61;
    }
}