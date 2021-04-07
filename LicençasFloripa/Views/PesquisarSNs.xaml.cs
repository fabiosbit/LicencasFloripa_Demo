using LicençasFloripa.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace LicençasFloripa.Views
{
    /// <summary>
    /// Interação lógica para PesquisarSNs.xam
    /// </summary>
    public partial class PesquisarSNs : UserControl
    {
        public PesquisarSNs()
        {
            InitializeComponent();
        }

        private void Btn_Pesquisar(object sender, RoutedEventArgs e)
        {
            //Bloco try comentado para a versão DEMO.
            try
            {
                new CaixaDeMensagem("Pesquisa desabilitada para não expor dados dos clientes. Usuário demo sem premissão de acesso ao DB.");

                //    PesquisarMicrossiga listaSns = new PesquisarMicrossiga();
                //    DataTable dt = listaSns.ListarSns(CodCliente.Text, CNPJ.Text, NotaFiscal.Text);
                //    GridPesquisaNotas.ItemsSource = dt.DefaultView;

                //    if (GridPesquisaNotas.HasItems == false)
                //    {
                //        new CaixaDeMensagem("Nenhum Registro Encontrado");
                //    }
            }
            catch (Exception erro)
            {
                new CaixaDeMensagem(erro.Message);
            }
        }

        private void AddDevedor_Click(object sender, RoutedEventArgs e)
        {

            if (GridPesquisaNotas.SelectedItems.Count > 0)
            {
                SqlConnection sqlcon = ConexãoDB.obterConexão();

                List<DataRow> listaAddDevedores = new List<DataRow>();

                foreach (DataRowView drRow in GridPesquisaNotas.SelectedItems)
                {
                    listaAddDevedores.Add(drRow.Row);

                    string drCliente = drRow.Row.ItemArray[0].ToString();
                    string drFantasia = drRow.Row.ItemArray[1].ToString();
                    string drCodigo = drRow.Row.ItemArray[2].ToString();
                    string drNota = drRow.Row.ItemArray[3].ToString();
                    string drSn = drRow.Row.ItemArray[4].ToString();
                    string drProduto = drRow.Row.ItemArray[5].ToString();
                    string data = DateTime.Now.ToShortDateString();

                    try
                    {
                        SqlCommand sqlcmd = new SqlCommand("AddDevedor", sqlcon);
                        sqlcmd.CommandType = CommandType.StoredProcedure;
                        sqlcmd.Parameters.AddWithValue("@Cliente", drCliente);
                        sqlcmd.Parameters.AddWithValue("@Fantasia", drFantasia);
                        sqlcmd.Parameters.AddWithValue("@Código", drCodigo);
                        sqlcmd.Parameters.AddWithValue("@Nota", drNota);
                        sqlcmd.Parameters.AddWithValue("@SN", drSn);
                        sqlcmd.Parameters.AddWithValue("@Produto", drProduto);
                        sqlcmd.Parameters.AddWithValue("@DataRegistro", data);
                        sqlcmd.ExecuteNonQuery();

                        new CaixaDeMensagem("Registrado com sucesso!");

                    }
                    catch (SqlException erro)
                    {
                        new CaixaDeMensagem(erro.Message);
                    }
                }
            }
            else
            {
                new CaixaDeMensagem("Nenhum cliente selecionado.");
            }
        }

        private void CodCliente_GotFocus(object sender, RoutedEventArgs e)
        {
            CNPJ.Clear();
            NotaFiscal.Clear();
        }

        private void CNPJ_GotFocus(object sender, RoutedEventArgs e)
        {
            CodCliente.Clear();
            NotaFiscal.Clear();
        }

        private void NotaFiscal_GotFocus(object sender, RoutedEventArgs e)
        {
            CodCliente.Clear();
            CNPJ.Clear();
        }
    }
}
