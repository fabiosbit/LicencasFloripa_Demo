using LicençasFloripa.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace LicençasFloripa.Models
{
    class CadastrarEquipamento
    {
        //Declaração das variáveis que existem na tabela "Equipamentos":
        public string Cliente;
        public string Contato;
        public string Email;
        public string Senha;
        public string Dongle;
        public string SN;
        public string Data;
        public string Tipo;
        public string Func;
        public string Obs;
        public string Placa;
        public string NomePc;
        public string FlopSec;
        public string Licença;
        public string Produto;
        public string Mac;
        public string Negócio;

        public void CadastrarEquip()
        {
            try
            {
                //instanciando o método conexãoDB:
                SqlConnection sqlcon = ConexãoDB.obterConexão();

                //método para rodar procedimento interno (Addxxx) no sql server para adiconar equipamento na tabela:
                SqlCommand sqlcmd = new SqlCommand("AddEquipamento", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Cliente", Cliente);
                sqlcmd.Parameters.AddWithValue("@Contato", Contato);
                sqlcmd.Parameters.AddWithValue("@Email", Email);
                sqlcmd.Parameters.AddWithValue("@ContraSenha", Senha);
                sqlcmd.Parameters.AddWithValue("@ValorDongle", Dongle);
                sqlcmd.Parameters.AddWithValue("@SN", SN);
                sqlcmd.Parameters.AddWithValue("@DataRegistro", Data);
                sqlcmd.Parameters.AddWithValue("@Tipo", Tipo);
                sqlcmd.Parameters.AddWithValue("@Funcionário", Func);
                sqlcmd.Parameters.AddWithValue("@Observações", Obs);
                sqlcmd.Parameters.AddWithValue("@Placa", Placa);
                sqlcmd.Parameters.AddWithValue("@NomeComputador", NomePc);
                sqlcmd.Parameters.AddWithValue("@Licença", Licença);
                sqlcmd.Parameters.AddWithValue("@FloripaSec", FlopSec);
                sqlcmd.Parameters.AddWithValue("@Produto", Produto);
                sqlcmd.Parameters.AddWithValue("@MacAddress", Mac);
                sqlcmd.Parameters.AddWithValue("@Negócio", Negócio);
                sqlcmd.Parameters.AddWithValue("@DataLicença", Data);
                sqlcmd.ExecuteNonQuery();

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
