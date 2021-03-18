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
    /// Interaction logic for PesquisaGeral.xaml
    /// </summary>
    public partial class PesquisaGeralPremium : UserControl
    {
        public PesquisaGeralPremium()
        {
            InitializeComponent();
        }

        public static string sn;           //Variável para armazenar a contra senha e enviar para o menu de pesquisa quando der duplo clique em alguma linha do datagrid.

        public void PesquisarGeralPremium_Click(object sender, RoutedEventArgs e)
        {
            //Definindo o padrão de cultura pt-BR para que as datas fiquem no formato dia/mês/ano:
            CultureInfo.CurrentCulture = new CultureInfo("pt-BR", false);
            Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);

            try
            {
                SqlConnection sqlcon = ConexãoDB.obterConexão();

                string LikePesquisa = "%" + BoxPesquisaGeralPremium.Text.Trim() + "%";

                SqlCommand sqlcmd = new SqlCommand("SelGeralPremium", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Pesquisa", LikePesquisa);

                SqlDataAdapter dataAdp = new SqlDataAdapter(sqlcmd);
                System.Data.DataTable dt = new System.Data.DataTable();
                dataAdp.Fill(dt);
                GridBuscaGeralPremium.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);

                ConexãoDB.fecharConexao(sqlcon);

            }
            catch (Exception erro)
            {
                new CaixaDeMensagem(erro.Message);
            }
        }

        private void GridBuscaGeralPremium_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //Capturando contra senha da linha selecionada:
            DataGridRow dgr = GridBuscaGeralPremium.ItemContainerGenerator.ContainerFromItem(GridBuscaGeralPremium.SelectedItem) as DataGridRow;
            DataRowView drv = (DataRowView)dgr.Item;
            sn = drv[6].ToString();

            if (sn.Length > 15)
            {
                sn = sn.Substring(0, 15);
            }

            PesquisaPremium pesquisa = new PesquisaPremium();            //Cria o objeto PesquisaPremium;
            pesquisa.Box_PesquisarPremium.Text = sn;                     //Envia o SN para o Box Pesquisar;
            pesquisa.BuscaPremium_Click(sender, e);                      //Executa o "click" no botão Pesquisar;
            MainWindow.viewControl.View = pesquisa;                      //Exibe o objeto PesquisaPremium no ContentControl da MainWindow;
        }

        private void Btn_Excluir(object sender, RoutedEventArgs e)
        {
            try
            {
                SqlConnection sqlcon = ConexãoDB.obterConexão();

                DataGridRow dgr = GridBuscaGeralPremium.ItemContainerGenerator.ContainerFromItem(GridBuscaGeralPremium.SelectedItem) as DataGridRow;
                DataRowView drv = (DataRowView)dgr.Item;
                string drID = drv[9].ToString();

                SqlCommand sqlcmd = new SqlCommand("DelPremium", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@drID", drID);
                sqlcmd.ExecuteNonQuery();

            }
            catch (Exception erro)
            {
                new CaixaDeMensagem(erro.Message);
            }

            PesquisarGeralPremium_Click(sender, e);         //Atualiza a lista.
        }
    }
}
