using LicençasFloripa.Views;
using System.Data;
using System.Data.SqlClient;

namespace LicençasFloripa.Models
{
    class CadastrarPremium
    {
        //Declaração das variáveis que existem na tabela "Premium":
        public string Cliente;
        public string CTO;
        public string NFPS;
        public string Produto;
        public string SN;
        public string Data;
        public string Obs;
        public string VencCTO;
        public string Proposta;

        public void CadastrarClientePremium()
        {
            try
            {
                //instanciando o método conexãoDB:
                SqlConnection sqlcon = ConexãoDB.obterConexão();

                //método para rodar procedimento interno (AddPremium) no sql server para adiconar contrato na tabela:
                SqlCommand sqlcmd = new SqlCommand("AddPremium", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Cliente", Cliente);
                sqlcmd.Parameters.AddWithValue("@Proposta", Proposta);
                sqlcmd.Parameters.AddWithValue("@CTO", CTO);
                sqlcmd.Parameters.AddWithValue("@VencCTO", VencCTO);
                sqlcmd.Parameters.AddWithValue("@SN", SN);
                sqlcmd.Parameters.AddWithValue("@DataRegistro", Data);
                sqlcmd.Parameters.AddWithValue("@Observações", Obs);
                sqlcmd.Parameters.AddWithValue("@Produto", Produto);
                sqlcmd.Parameters.AddWithValue("@NFPS", NFPS);
                sqlcmd.Parameters.AddWithValue("@Ativo", 1);
                sqlcmd.ExecuteNonQuery();

                
                //Rotina abaixo comentada para a versão DEMO:

                //exporta um arquivo xls no servidor SQL com o conteúdo da tabela Premium:
                //SqlCommand exportXls = new SqlCommand("ExportaPremium", sqlcon);
                //exportXls.CommandType = CommandType.StoredProcedure;
                //exportXls.ExecuteNonQuery();

                new CaixaDeMensagem("Cadastro realizado com sucesso!");

                //Chama o método para fexar a conexão com o Banco de Dados:
                ConexãoDB.fecharConexao(sqlcon);

            }
            catch (SqlException)
            {
                throw;
            }

        }
    }
}