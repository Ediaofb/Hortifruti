using System;
using System.Windows.Forms;

namespace Hortifruti
{
    public partial class Frm_inicial : Form
    {
        public Frm_inicial()
        {

            InitializeComponent();

            /*Banco bd = new Banco();

            bd.RestaurarDBPadraoCasoNaoExista();*/
            
        }        
        

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Frm_consulta ini = new Frm_consulta();
            ini.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Frm_usuario usuario = new Frm_usuario();
            usuario.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Frm_relatorios rel = new Frm_relatorios();
            rel.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Frm_cadastro cad = new Frm_cadastro();
            cad.Show();
            this.Hide();
        }        
    }
}
