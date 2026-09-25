using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Hortifruti
{
    public static class Conexao
    {
        public static SqlConnection CriarConexao()
        {
            return new SqlConnection(
                ConfigurationManager
                   .ConnectionStrings["Hortifruti.Properties.Settings.hortifruti_dbConnectionString"]
                   .ConnectionString
          );
        }
        // <summary>
        // Retorna a data e hora atual do SERVIDOR SQL (não do PC local).
        // Usado para evitar burlar o bloqueio atrasando o relógio do Windows.
        // </summary>
        public static DateTime ObterDataServidor()
        {
            using (SqlConnection conexao = CriarConexao())
            using (SqlCommand comando = new SqlCommand("SELECT GETDATE()", conexao))
            {
                conexao.Open();
                return (DateTime)comando.ExecuteScalar();
            }
        }
    }

}
