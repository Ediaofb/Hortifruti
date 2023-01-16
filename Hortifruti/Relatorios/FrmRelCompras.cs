using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hortifruti.Relatorios
{
    public partial class FrmRelCompras : Form
    {
        public FrmRelCompras()
        {
            InitializeComponent();
        }

        private void FrmRerlCompras_Load(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hortifruti_dbDataSet7.Compra'. Você pode movê-la ou removê-la conforme necessário.
            this.compraTableAdapter.Fill(this.hortifruti_dbDataSet7.Compra, "", "", "01-01-2000", "01-01-2100");            
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // TODO: esta linha de código carrega dados na tabela 'hortifruti_dbDataSet4.Compra'. Você pode movê-la ou removê-la conforme necessário.
            this.compraTableAdapter.Fill(this.hortifruti_dbDataSet7.Compra, textBox1.Text, textBox2.Text, dateTimePicker1.Text, dateTimePicker2.Text);
            this.reportViewer1.RefreshReport();
        }
    }
}
