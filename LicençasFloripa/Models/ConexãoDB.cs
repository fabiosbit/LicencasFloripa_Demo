using LicençasFloripa.Views;
using System.Data;
using System.Data.SqlClient;

namespace LicençasFloripa.Models
{
    public class ConexãoDB
    {

        //Conexão com o Banco de Dados SQL Server:
        private static string StringCon = @"Data Source=floripatec.no-ip.biz,60123\SQLPROTHEUS;Initial Catalog=LicençasDB_teste; User Id=teste; Password=demo#app;";


        public static SqlConnection obterConexão()
        {
            SqlConnection conexão = new SqlConnection(StringCon);

            try
            {
                // abre a conexão e a devolve ao chamador do método
                if (conexão.State != ConnectionState.Open)
                {
                    conexão.Open();
                }
            }
            catch (SqlException erro)
            {
                new CaixaDeMensagem(erro.Message);
            }

            return conexão;
        }
        public static void fecharConexao(SqlConnection conexão)
        {
            if (conexão.State != ConnectionState.Closed)
            {
                conexão.Close();
            }
        }
    }
}
