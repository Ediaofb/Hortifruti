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
    }
}
