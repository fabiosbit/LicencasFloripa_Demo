using LicençasFloripa.Models;
using System;
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
    public partial class PesquisaGeral : UserControl
    {
        public static string ContraSenha;           //Variável para armazenar a contra senha e enviar para o menu de pesquisa quando der duplo clique em alguma linha do datagrid.

        public PesquisaGeral()
        {
            InitializeComponent();
        }

        public void PesquisarGeral_Click(object sender, RoutedEventArgs e)
        {
            //Definindo o padrão de cultura pt-BR para que as datas fiquem no formato dia/mês/ano:
            CultureInfo.CurrentCulture = new CultureInfo("pt-BR", false);
            Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);

            try
            {
                string LikePesquisa = "%" + BoxPesquisaGeral.Text.Trim() + "%";             //Adiciona %% entre o texto da pesquisa para o comando like do sql.

                SqlConnection sqlcon = ConexãoDB.obterConexão();

                SqlCommand sqlcmd = new SqlCommand("SelGeralLicenças", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Pesquisa", LikePesquisa);

                SqlDataAdapter dataAdp = new SqlDataAdapter(sqlcmd);
                DataTable dt = new DataTable();
                dataAdp.Fill(dt);
                GridBuscaGeral.ItemsSource = dt.DefaultView;
                dataAdp.Update(dt);

                ConexãoDB.fecharConexao(sqlcon);
            }
            catch (Exception erro)
            {
                new CaixaDeMensagem(erro.Message);
            }
        }

        private void Row_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //Capturando contra senha da linha selecionada:
            DataGridRow dgr = GridBuscaGeral.ItemContainerGenerator.ContainerFromItem(GridBuscaGeral.SelectedItem) as DataGridRow;
            DataRowView drv = (DataRowView)dgr.Item;
            ContraSenha = drv[6].ToString();

            PesquisaLicenças pesquisa = new PesquisaLicenças();     //Cria o objeto PesquisaLicenças;
            pesquisa.Box_PesquisarAlterar.Text = ContraSenha;       //Envia a contra senha para o Box Pesquisar;
            pesquisa.PesquisarLicença_Click(sender, e);             //Executa o "click" no botão Pesquisar;
            MainWindow.viewControl.View = pesquisa;                 //Exibe o objeto PesquisaLicenças no ContentControl da MainWindow;

        }
    }
}

