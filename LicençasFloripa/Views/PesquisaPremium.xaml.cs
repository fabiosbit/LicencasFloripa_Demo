using LicençasFloripa.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Windows.Media;

namespace LicençasFloripa.Views
{
    /// <summary>
    /// Interação lógica para PesquisaPremium.xam
    /// </summary>
    public partial class PesquisaPremium : UserControl
    {
        public PesquisaPremium()
        {
            InitializeComponent();
        }

        public int ID;
        public int Ativo;

        public void BuscaPremium_Click(object sender, RoutedEventArgs e)
        {
            //Definindo o padrão de cultura pt-BR para que as datas fiquem no formato dia/mês/ano:
            CultureInfo.CurrentCulture = new CultureInfo("pt-BR", false);
            Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);

            try
            {
                string LikePesquisa = "%" + Box_PesquisarPremium.Text.Trim() + "%";         //Adicionar os % para o parâmetro like do sql.

                SqlConnection sqlcon = ConexãoDB.obterConexão();
                SqlCommand sqlcmd = new SqlCommand("SelPremium", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Pesquisa", LikePesquisa);

                SqlDataReader dataReader = sqlcmd.ExecuteReader();

                if (dataReader.HasRows == true)
                {
                    dataReader.Read();
                    string drCliente = dataReader.GetString(0);
                    string drCTO = dataReader.GetString(1);
                    string drNFPS = dataReader.GetString(2);
                    string drProduto = dataReader.GetString(3);
                    string drSN = dataReader.GetString(4);
                    string drObservações = dataReader.GetString(5);
                    string drData = dataReader.GetDateTime(6).ToShortDateString();
                    string drVencCTO = dataReader.GetDateTime(7).ToShortDateString();
                    string drProposta = dataReader.GetString(8);
                    int drID = dataReader.GetInt32(10);
                    int drAtivo = dataReader.GetInt32(9);

                    Cliente.Text = drCliente;
                    Produto.Text = drProduto;
                    SN.Text = drSN;
                    Data.Text = drData;
                    CTO.Text = drCTO;
                    VencCTO.Text = drVencCTO;
                    NFPS.Text = drNFPS;
                    Proposta.Text = drProposta;
                    Obs.Text = drObservações;
                    ID = drID;
                    Ativo = drAtivo;

                    if (drAtivo == 0)
                    {
                        RadSuspenso.IsChecked = true;
                    }
                    else
                    {
                        RadAtivo.IsChecked = true;
                    }


                    //Exibe os itens d apágina depois que o usuário pesquisar algo, evitando a tentativa de buscar pelos campos e não pela pesquisa.
                    StkPanelColuna1.Visibility = Visibility.Visible;
                    StkPanelColuna2.Visibility = Visibility.Visible;
                    Btn_Salvar.Visibility = Visibility.Visible;
                    ConexãoDB.fecharConexao(sqlcon);
                }

                else
                {
                    new CaixaDeMensagem("Nenhum registro encontrado");
                }
            }

            catch (Exception erro)
            {
                new CaixaDeMensagem(erro.Message);
            }
        }

        private void Salvar_Click(object sender, RoutedEventArgs e)
        {
            AtualizarCadastroPremium atualizar = new AtualizarCadastroPremium();
            atualizar.Cliente = Cliente.Text;
            atualizar.CTO = CTO.Text;
            atualizar.NFPS = NFPS.Text;
            atualizar.Produto = Produto.Text;
            atualizar.SN = SN.Text;
            atualizar.Obs = Obs.Text;
            atualizar.Data = Data.Text;
            atualizar.VencCTO = VencCTO.Text;
            atualizar.Proposta = Proposta.Text;
            atualizar.ID = ID;
            atualizar.Ativo = Ativo;

            //Validando campos que não podem ficar em branco:
            if (string.IsNullOrWhiteSpace(Cliente.Text) || string.IsNullOrWhiteSpace(CTO.Text) || string.IsNullOrWhiteSpace(NFPS.Text) || string.IsNullOrWhiteSpace(Produto.Text) ||
                string.IsNullOrWhiteSpace(SN.Text) || Data.Text == "__/__/____" || VencCTO.Text == "__/__/____" || string.IsNullOrWhiteSpace(Proposta.Text))
            {
                new CaixaDeMensagem("Preencha todos os campos");
            }
            else
            {
                try
                {
                    //Chama o procedimento que executa o comando SQL para atualizar a tabela.
                    atualizar.AtualizarPremium();

                    //Limpa todos os campos:
                    Cliente.Clear();
                    CTO.Clear();
                    NFPS.Clear();
                    Produto.Clear();
                    SN.Clear();
                    Obs.Clear();
                    Data.Text = DateTime.Now.ToShortDateString();
                    VencCTO.Clear();
                    Proposta.Clear();
                    RadSuspenso.IsChecked = false;
                    RadAtivo.IsChecked = false;
                }
                catch (Exception erro)
                {
                    new CaixaDeMensagem(erro.Message);
                }
            }
        }

        private void RadAtivo_Click(object sender, RoutedEventArgs e)
        {
            Ativo = 1;
        }

        private void RadSuspenso_Click(object sender, RoutedEventArgs e)
        {
            Ativo = 0;
        }
    }
}


