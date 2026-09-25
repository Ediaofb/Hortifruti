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
    public partial class FrmAviso : Form
    {
        public FrmAviso(string mensagem)
        {
            InitializeComponent();
            lblMensagem.Text = mensagem;
        }

        private void btnEntendi_Click(object sender, EventArgs e)
        {
            this.Close(); // apenas fecha — fluxo normal continua
        }

        private void FrmAviso_Load(object sender, EventArgs e)
        {

        }
    }
}
