using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hortifruti
{
    public partial class Frm_consulta : Form
    {
        public Frm_consulta()
        {
            InitializeComponent();
        }

        private void btn_produto_Click(object sender, EventArgs e)
        {
            Frm_produto prod = new Frm_produto();
            prod.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm_cliente cl = new Frm_cliente();
            cl.Show();
            this.Hide();
        }

        private void Fornecedor_Click(object sender, EventArgs e)
        {
            Frm_fornecedor forn = new Frm_fornecedor();
            forn.Show();
            this.Hide();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Frm_venda ven = new Frm_venda();
            ven.Show();
            this.Hide();
        }

        private void btn_voltar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Frm_inicial frm2 = new Frm_inicial();
            frm2.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_cadastro cad = new Frm_cadastro();
            cad.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Frm_compra com = new Frm_compra();
            com.Show();
            this.Hide();
        }
    }
}
