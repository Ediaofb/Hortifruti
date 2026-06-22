using System.Configuration;
using System.Data;
using System.Data.SqlClient;

public static class Banco
{
    public static string ConnectionString
    {
        get
        {
            return ConfigurationManager
                .ConnectionStrings["HortifrutiConnection"]
                .ConnectionString;
        }
    }

    public static DataTable Consultar(string sql, params SqlParameter[] parametros)
    {
        using (SqlConnection con = new SqlConnection(ConnectionString))
        using (SqlCommand cmd = new SqlCommand(sql, con))
        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
        {
            if (parametros != null)
                cmd.Parameters.AddRange(parametros);

            DataTable tabela = new DataTable();
            da.Fill(tabela);
            return tabela;
        }
    }

    public static int Executar(string sql, params SqlParameter[] parametros)
    {
        using (SqlConnection con = new SqlConnection(ConnectionString))
        using (SqlCommand cmd = new SqlCommand(sql, con))
        {
            if (parametros != null)
                cmd.Parameters.AddRange(parametros);

            con.Open();
            return cmd.ExecuteNonQuery();
        }       
    }
}