using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Hortifruti
{
    public static class VerificacaoLicenca
    {
        // ── Configurações ─────────────────────────────────────────────
        private const int DIA_BLOQUEIO = 25; // dia do mês em que o sistema será bloqueado
        private const int DIAS_AVISO = 5; // dias antes do bloqueio para exibir aviso ao usuário

        // ── CHAVE SECRETA ─────────────────────────────────────────────
        // DEVE SER IDÊNTICA à usada no GeradorSenha do projeto separado
        private const string CHAVE_SECRETA = "Hortifruti-2026-#Suporte!";

        // ── Bloqueio ──────────────────────────────────────────────────

        /// <summary>
        /// Verifica se o sistema deve ser bloqueado.
        /// Retorna true se:
        ///   - hoje (segundo o SERVIDOR) é dia >= DIA_BLOQUEIO
        ///     E o sistema não foi desbloqueado neste mês/ano; OU
        ///   - a data do PC está atrasada em relação à última
        ///     data registrada no banco (tentativa de fraude).
        /// </summary>
        public static bool SistemaBloqueado(out string motivo)
        {
            motivo = "";
            DateTime dataServidor;
            DateTime ultimoDesbloqueio;
            DateTime dataServidorRegistro;

            try
            {
                using (SqlConnection conexao = Conexao.CriarConexao())
                {
                    conexao.Open();

                    using (SqlCommand cmd =
                         new SqlCommand("SELECT GETDATE()", conexao))
                    {
                        dataServidor = (DateTime)cmd.ExecuteScalar();
                    }

                    using (SqlCommand cmd = new SqlCommand (
                        @"SELECT TOP 1
                             UltimoDesbloqueio,
                             DataServidorRegistro
                        FROM ControleLicenca
                        WHERE Ativo = 1
                        ORDER BY Id DESC", conexao))
                   using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            ultimoDesbloqueio    = dr.GetDateTime(0);
                            dataServidorRegistro = dr.GetDateTime(1);
                        }
                        else
                        {
                            ultimoDesbloqueio    = DateTime.MinValue;
                            dataServidorRegistro = DateTime.MinValue;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                motivo = "Não foi possível verificar a licença. \n"
                       + "Verifique a conexão com o banco de dados.\n"
                       + "Detalhe: " + ex.Message;
                return true; // Bloqueia o sistema em caso de erro)
             }

            //Detecta relógio atrasado
            if (dataServidor < dataServidorRegistro)
            {
                motivo = "Foi detectada uma insconsistência na data"
                       + "do sistema.\n"
                       + "O relógio do computador pode ter sido "
                       + "alterado.\n"
                       + "Entre em contato com o suporte.";
                return true;
            }

            // Ainda não chegou o dia de bloqueio
            if (dataServidor.Day < DIA_BLOQUEIO)
                return false;

            // Já desbloqueou este mês?
            bool desbloqueadoEsteMes =
                   ultimoDesbloqueio.Month == dataServidor.Month
                && ultimoDesbloqueio.Year == dataServidor.Year;

            if (desbloqueadoEsteMes)
                return false;

            motivo = "O período de uso do sistema expirou.\n"
                   + "Digite a senha de desbloqueio fornecida "
                   + "pelo suporte.";
            return true;
        }

        // ── Aviso de vencimento próximo ───────────────────────────────

        /// <summary>
        /// Retorna true se estamos nos DIAS_AVISO dias antes
        /// do DIA_BLOQUEIO E o aviso ainda não foi exibido hoje.
        /// </summary>
        public static bool DeveExibirAviso(out int diasRestantes)
        {
            diasRestantes = 0;

            DateTime dataServidor = DateTime.MinValue;
            DateTime ultimoAviso = DateTime.MinValue;

            try
            {
                using (SqlConnection conexao = Conexao.CriarConexao())
                {
                    conexao.Open();

                    // Data real do servidor
                    using (SqlCommand cmd =
                        new SqlCommand("SELECT GETDATE()", conexao))
                    {
                        dataServidor = (DateTime)cmd.ExecuteScalar();
                    }

                    // Último aviso exibido
                    using (SqlCommand cmd = new SqlCommand(
                        @"SELECT TOP 1 UltimoAviso
                          FROM   ControleLicenca
                          WHERE  Ativo = 1
                          ORDER BY Id DESC", conexao))
                    {
                        object resultado = cmd.ExecuteScalar();
                        if (resultado != null && resultado != DBNull.Value)
                            ultimoAviso = Convert.ToDateTime(resultado);
                    }
                }
            }
            catch (Exception ex)
            {             
                MessageBox.Show("Erro ao exibir aviso: \n" + ex.Message,
                    "Erro interno",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return false; // evita usar dataServidor não inicializada
            }

            // Calcula quantos dias faltam para o bloqueio
            // Monta a data exata de bloqueio deste mês
            DateTime dataBloqueioEsteMes = new DateTime(
                dataServidor.Year,
                dataServidor.Month,
                DIA_BLOQUEIO);

            diasRestantes = (dataBloqueioEsteMes - dataServidor.Date).Days;

            // Aviso só aparece no intervalo: entre DIAS_AVISO e 1 dia antes
            bool dentroDoIntervalo =
                diasRestantes > 0 && diasRestantes <= DIAS_AVISO;

            if (!dentroDoIntervalo)
                return false;

            // Já exibiu o aviso hoje?
            bool jaExibiuHoje =
                ultimoAviso.Date == dataServidor.Date;

            return !jaExibiuHoje;
        }

        /// <summary>
        /// Registra no banco que o aviso foi exibido hoje.
        /// </summary>
        public static void RegistrarExibicaoAviso()
        {
            try
            {
                using (SqlConnection conexao = Conexao.CriarConexao())
                using (SqlCommand cmd = new SqlCommand(
                    @"UPDATE ControleLicenca
                      SET    UltimoAviso = CAST(GETDATE() AS DATE)
                      WHERE  Id = (
                          SELECT MAX(Id)
                          FROM   ControleLicenca
                          WHERE  Ativo = 1
                      )", conexao))
                {
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                // Silencia — o aviso simplesmente aparecerá novamente
                // na próxima abertura caso falhe ao registrar
            }
        }

        // ── Senha e desbloqueio ───────────────────────────────────────

        public static bool SenhaValida(string senhaDigitada, out string erro)
        {
            erro = "";
            DateTime dataServidor;

            try
            {
                dataServidor = Conexao.ObterDataServidor();
            }
            catch (Exception ex)
            {
                erro = "Erro ao verificar data do servidor: " + ex.Message;
                return false;
            }

            string senhaEsperada = GeradorSenha.GerarSenha(
                dataServidor.Month, dataServidor.Year);

            return senhaDigitada.Trim().ToUpper() == senhaEsperada;
        }

        public static void RegistrarDesbloqueio()
        {
            try
            {
                using (SqlConnection conexao = Conexao.CriarConexao())
                using (SqlCommand cmd = new SqlCommand(
                    @"INSERT INTO ControleLicenca
                          (UltimoDesbloqueio, DataServidorRegistro, Ativo)
                      VALUES
                          (GETDATE(), GETDATE(), 1)", conexao))
                {
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex) // ← temporariamente captura o erro
            {
                MessageBox.Show("Erro ao registrar desbloqueio: \n" + ex.Message,
                    "Erro interno",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public static void AtualizarUltimaDataVista()
        {
            try
            {
                using (SqlConnection conexao = Conexao.CriarConexao())
                using (SqlCommand cmd = new SqlCommand(
                    @"UPDATE ControleLicenca
                      SET    DataServidorRegistro = GETDATE()
                      WHERE  Id = (
                          SELECT MAX(Id)
                          FROM   ControleLicenca
                          WHERE  Ativo = 1
                      )", conexao))
                {
                    conexao.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch { }
        }
    }
}
