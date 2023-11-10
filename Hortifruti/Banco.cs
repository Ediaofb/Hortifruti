using System;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace Hortifruti
{
    public class Banco
    {
        public static SqlConnection conexao;
        private String _stringConexao;
        private SqlConnection _conexao;

        public Banco(String dadosConexao)
        {
            this._conexao = new SqlConnection();
            this.StringConexao = dadosConexao;
            this._conexao.ConnectionString = dadosConexao;
        }

        public String StringConexao
        {
            get { return this._stringConexao; }
            set { this._stringConexao = value; }

        }

        public SqlConnection ObjetoConexao
        {
            get { return this._conexao; }
            set { this._conexao = value; }
        }

        public void Conectar()
        {
            this._conexao.Open();
        }

        public void Desconectar()
        {
            this._conexao.Close();
        }

        public static SqlConnection ConexaoBanco()
        {
            conexao = new SqlConnection("Data Source=EDSON-PC;Initial Catalog=hortifruti_db;Integrated Security=True");
            conexao.Open();
            MessageBox.Show("Conectou!");
            return conexao;
        }

        public static DataTable consulta(string sql)
        {
            SqlDataAdapter da = null;
            DataTable dt = new DataTable();
            try
            {
                var vcon = ConexaoBanco();
                var cmd = vcon.CreateCommand();
                cmd.CommandText = sql;
                da = new SqlDataAdapter(cmd.CommandText, vcon);
                da.Fill(dt);
                vcon.Close();
                return dt;
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
                throw ex;
            }
            finally
            {
                conexao.Close();
                conexao = null;
            }
        }       
    }    
}