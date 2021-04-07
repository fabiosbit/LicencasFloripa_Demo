using LicençasFloripa.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;

namespace LicençasFloripa.Views
{
    /// <summary>
    /// Interação lógica para PesquisarDevedores.xam
    /// </summary>
    public partial class PesquisarDevedores : UserControl
    {
        public PesquisarDevedores()
        {
            InitializeComponent();
        }

        public void Listar()
        {
            //Definindo o padrão de cultura pt-BR para que as datas fiquem no formato dia/mês/ano:
            CultureInfo.CurrentCulture = new CultureInfo("pt-BR", false);
            Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);

            try
            {
                PesquisarMicrossiga devedor = new PesquisarMicrossiga();

                DataTable dt = devedor.Listar();

                GridPendencias.ItemsSource = dt.DefaultView;
                //((DataGridTextColumn)GridPendencias.Columns[2]).Binding.StringFormat = "d";

            }
            catch (Exception erro)
            {
                new CaixaDeMensagem(erro.Message);
            }

        }

        private void Btn_Remover(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection sqlcon = ConexãoDB.obterConexão();

                List<DataRow> listaDelDevedores = new List<DataRow>();
              
                foreach (DataRowView drRow in GridPendencias.SelectedItems)
                {
                    listaDelDevedores.Add(drRow.Row);
                    string drSnR = drRow.Row.ItemArray[4].ToString();

                    SqlCommand sqlcmd = new SqlCommand("DelDevedor", sqlcon);
                    sqlcmd.CommandType = CommandType.StoredProcedure;
                    sqlcmd.Parameters.AddWithValue("@snR", drSnR);
                    sqlcmd.ExecuteNonQuery();
                }
            }
            catch (Exception erro)
            {
                new CaixaDeMensagem(erro.Message);
            }

            Listar();          //Atualiza a lista.
        }
    }
}
