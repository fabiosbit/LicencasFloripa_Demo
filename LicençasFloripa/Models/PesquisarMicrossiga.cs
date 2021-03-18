using LicençasFloripa.Views;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace LicençasFloripa.Models
{
    public class PesquisarMicrossiga
    {
        public DataTable Listar()
        {
            try
            {

                SqlConnection sqlcon = ConexãoDB.obterConexão();

                SqlCommand sqlcmd = new SqlCommand("SelDevedores", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter dataAdp = new SqlDataAdapter(sqlcmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                dataAdp.Fill(dt);

                return dt;
            }
            catch (SqlException)
            {
                return null;
                throw;
            }

        }

        public DataTable ListarSns(string codigoCliente, string cnpj, string nf)
        {
            try
            {
                SqlConnection sqlcon = ConexãoDB.obterConexão();

                SqlCommand sqlcmd = new SqlCommand("VerSNsCli", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@CDCLI", codigoCliente);
                sqlcmd.Parameters.AddWithValue("@CNPJ", cnpj);
                sqlcmd.Parameters.AddWithValue("@NF", nf);

                SqlDataAdapter dataAdp = new SqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                dataAdp.Fill(dt);

                return dt;
            }
            catch (SqlException)
            {

                throw;
            }
        }

        public DataTable ListarClientes(string codigoCliente, string cnpj, string nome)
        {
            try
            {
                SqlConnection sqlcon = ConexãoDB.obterConexão();

                SqlCommand sqlcmd = new SqlCommand("SelClientes", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@CDCLI", codigoCliente);
                sqlcmd.Parameters.AddWithValue("@CNPJ", cnpj);
                sqlcmd.Parameters.AddWithValue("@Nome", nome);

                SqlDataAdapter dataAdp = new SqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                dataAdp.Fill(dt);

                return dt;
            }
            catch (SqlException)
            {

                throw;
            }


        }

        public DataTable ListarProdutosDoCliente(string codigoCliente, string cnpj, string nome)
        {
            try
            {
                SqlConnection sqlcon = ConexãoDB.obterConexão();

                SqlCommand sqlcmd = new SqlCommand("SelProdutosCliente", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@CDCLI", codigoCliente);
                sqlcmd.Parameters.AddWithValue("@CNPJ", cnpj);
                sqlcmd.Parameters.AddWithValue("@Nome", nome);

                SqlDataAdapter dataAdp = new SqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                dataAdp.Fill(dt);

                return dt;
            }
            catch (SqlException)
            {

                throw;
            }

        }
    }
}
