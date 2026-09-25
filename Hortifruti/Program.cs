using System;
using System.Windows.Forms;

namespace Hortifruti
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // ── 1. Verifica bloqueio ─────────────────────────────────
            string motivoBloqueio;
            bool bloqueado = VerificacaoLicenca.SistemaBloqueado(out motivoBloqueio);

            if (bloqueado)
            {
                using (FrmBloqueio frmBloqueio = new FrmBloqueio(motivoBloqueio))
                {
                    frmBloqueio.ShowDialog();

                    if (!frmBloqueio.SenhaCorreta)
                    {
                        MessageBox.Show(
                            "Sistema encerrado.\n" +
                            "Entre emcontato com o suporte para desbloquear.",
                            "Acesso negado",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    VerificacaoLicenca.RegistrarDesbloqueio();
                }                
            }
            else
            { 
               // --- 2. Não bloqueado: verifica aviso de vencimento ----
               int diasRestantes;
                if(VerificacaoLicenca.DeveExibirAviso(out diasRestantes))
                {
                    //Monta mensagem dinâmica com dias restantes
                    string pluralDias = diasRestantes == 1 ? "dia" : "dias";
                    
                    string mensagem = 
                        "Sua mensalidade vence em "
                        + diasRestantes + " " + pluralDias + ".\n" 
                        + "Após vencimento, o sistema será bloqueado "
                        + "automaticamente.\n"
                        + "Entre em contato com o suporte para efetuar o pagamento \n"
                        + "e receber a senha de desbloqueio.";

                    using (FrmAviso frm = new FrmAviso(mensagem))
                    {
                        //Preenche o destaque de dias restantes
                        frm.lblDiasRestantes.Text = 
                            diasRestantes == 1
                            ? "ATENÇÃO: O sistema será bloqueado AMANHÃ!"
                            : "Faltam " + diasRestantes
                            + " dias para o bloqueio automático.";

                        frm.ShowDialog();
                        // ↑ modal, mas pode ser fechado normalmente
                    }
                    // Registra que o aviso foi exibido hoje
                    VerificacaoLicenca.RegistrarExibicaoAviso();
                }
                // --- 3. Atualiza a última data vista (antifraude) ----
                VerificacaoLicenca.AtualizarUltimaDataVista();
            }

            // --- 4. Abre o sistema normalmente  ------
            Application.Run(new Frm_login());
        }
    }
}
