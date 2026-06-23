using System;
using System.Windows.Forms;

namespace Hortifruti
{
    public partial class Frm_relatorios : Form
    {
        public Frm_relatorios()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_inicial Frm2 = new Frm_inicial();
            Frm2.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Relatorios.FrmRelProdutos frm = new Relatorios.FrmRelProdutos();
            frm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Relatorios.FrmRelProdutor prod = new Relatorios.FrmRelProdutor();
            prod.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Relatorios.FrmRelCliente cli = new Relatorios.FrmRelCliente();
            cli.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            /*Form_filtrar_rel_venda frv = new Form_filtrar_rel_venda();
            frv.Show();*/
            
            Relatorios.FrmRelVendas ven = new Relatorios.FrmRelVendas();
            ven.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Relatorios.FrmRelCompras comp = new Relatorios.FrmRelCompras();
            comp.Show();
        }
    }
}
