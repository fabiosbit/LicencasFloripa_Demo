using LicençasFloripa.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LicençasFloripa.Models
{
    public class AtualizarCadastroPremium
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
        public int ID;                //Variável ID para identificar qual linha a ser atualizada.
        public int Ativo;             //Variável para poder suspender o suporte em caso de inadimplência.

        public void AtualizarPremium()
        {
            try
            {
                //instanciando o método conexãoDB:
                SqlConnection sqlcon = ConexãoDB.obterConexão();

                //método para rodar procedimento interno (UpdatePremium) no sql server para atualizar a tabela Premium:
                SqlCommand sqlcmd = new SqlCommand("UpdatePremium", sqlcon);
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
                sqlcmd.Parameters.AddWithValue("@IDp", ID);
                sqlcmd.Parameters.AddWithValue("@Ativo", Ativo);
                sqlcmd.ExecuteNonQuery();

                //exporta um arquivo xls no servidor SQL com o conteúdo da tabela Premium:
                SqlCommand exportXls = new SqlCommand("ExportaPremium", sqlcon);
                exportXls.CommandType = CommandType.StoredProcedure;
                exportXls.ExecuteNonQuery();

                new CaixaDeMensagem("Dados Atualizados Com Sucesso!");

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
