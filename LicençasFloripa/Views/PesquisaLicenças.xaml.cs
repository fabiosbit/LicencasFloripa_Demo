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
    /// Interaction logic for Pesquisa.xaml
    /// </summary>
    public partial class PesquisaLicenças : UserControl
    {
        public PesquisaLicenças()
        {
            InitializeComponent();
        }

        string Negócio;

        public void PesquisarLicença_Click(object sender, RoutedEventArgs e)
        {
            //Definindo o padrão de cultura pt-BR para que as datas fiquem no formato dia/mês/ano:
            CultureInfo.CurrentCulture = new CultureInfo("pt-BR", false);
            Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);

            string LikeSN;
            string LikePesquisa = "%" + Box_PesquisarAlterar.Text.Trim() + "%";         //Adiciona os % para funcionar com o parâmetro like do sql.
            DataLicença.FontWeight = FontWeights.Regular;
            DataLicença.Foreground = Brushes.DimGray;

            try
            {
                SqlConnection sqlcon = ConexãoDB.obterConexão();
                SqlCommand sqlcmd = new SqlCommand("SelLicença", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@Pesquisa", LikePesquisa);

                SqlDataReader dataReader = sqlcmd.ExecuteReader();

                if (dataReader.HasRows == true)
                {
                    dataReader.Read();
                    string drCliente = dataReader.GetString(0);
                    string drContato = dataReader.GetString(1);
                    string drEmail = dataReader.GetString(2);
                    string drProduto = dataReader.GetString(3);
                    string drSN;
                    string drValorDongle = dataReader.GetString(5);
                    string drContraSenha = dataReader.GetString(6);
                    string drLicença = dataReader.GetString(7);
                    string drTipo = dataReader.GetString(8);
                    string drDataRegistro = dataReader.GetDateTime(9).ToShortDateString();
                    string drNomeComputador;
                    string drPlaca;
                    string drFloripaSec;
                    string drMacAddress;
                    string drFuncionário = dataReader.GetString(14);
                    string drObservações;
                    string drNegócio;
                    string drDataLicença;

                    //Verifica se o valor na tabela é nulo antes de atribuir à variável.
                    if (dataReader.IsDBNull(4))
                    {
                        drSN = "Não Informado";
                        LikeSN = drSN;
                    }
                    else
                    {
                        drSN = dataReader.GetString(4);
                    }

                    if (dataReader.IsDBNull(10))
                    {
                        drNomeComputador = "Não Informado";
                    }
                    else
                    {
                        drNomeComputador = dataReader.GetString(10);
                    }

                    if (dataReader.IsDBNull(11))
                    {
                        drPlaca = "Não Informado";
                    }
                    else
                    {
                        drPlaca = dataReader.GetString(11);
                    }

                    if (dataReader.IsDBNull(12))
                    {
                        drFloripaSec = "Não Informado";
                    }
                    else
                    {
                        drFloripaSec = dataReader.GetString(12);
                    }

                    if (dataReader.IsDBNull(13))
                    {
                        drMacAddress = "Não Informado";
                    }
                    else
                    {
                        drMacAddress = dataReader.GetString(13);
                    }

                    if (dataReader.IsDBNull(15))
                    {
                        drObservações = " ";
                    }
                    else
                    {
                        drObservações = dataReader.GetString(15);
                    }

                    if (dataReader.IsDBNull(16))
                    {
                        drNegócio = "Nulo";
                        Negócio = "Nulo";
                        RadVenda.IsChecked = false;
                        RadDemo.IsChecked = false;
                        RadAlguel.IsChecked = false;
                        RadFeira.IsChecked = false;
                    }
                    else
                    {
                        drNegócio = dataReader.GetString(16);
                        Negócio = drNegócio;
                    }

                    if (dataReader.IsDBNull(17))
                    {
                        drDataLicença = drDataRegistro;
                    }
                    else
                    {
                        drDataLicença = dataReader.GetDateTime(17).ToShortDateString();
                    }

                    Cliente.Text = drCliente;
                    Contato.Text = drContato;
                    Email.Text = drEmail;
                    Produto.Text = drProduto;
                    SN.Text = drSN;
                    LikeSN = "%" + SN.Text + "%";
                    Dongle.Text = drValorDongle;
                    Senha.Text = drContraSenha;
                    Licença.Text = drLicença;
                    Tipo.Text = drTipo;
                    Data.Text = drDataRegistro;
                    NomePc.Text = drNomeComputador;
                    Placa.Text = drPlaca;
                    FlopSec.Text = drFloripaSec;
                    MacAdd.Text = drMacAddress;
                    Func.Text = drFuncionário;
                    Obs.Text = drObservações;
                    DataLicença.Text = drDataLicença;

                    //Informando o tipo de negócio:
                    if (drNegócio == "Venda")
                    {
                        Block_Negócio.Text = "Venda";
                        RadVenda.IsChecked = true;
                    }
                    if (drNegócio == "Demo")
                    {
                        Block_Negócio.Text = "Equipamento Demo";
                        RadDemo.IsChecked = true;
                    }
                    if (drNegócio == "Aluguel")
                    {
                        Block_Negócio.Text = "Aluguel";
                        RadAlguel.IsChecked = true;
                    }
                    if (drNegócio == "Feira")
                    {
                        Block_Negócio.Text = "Feira";
                        RadFeira.IsChecked = true;
                    }
                    if (drNegócio == "Nulo")
                    {
                        Block_Negócio.Text = "Negócio não informado";
                    }

                    //Exibe os itens d apágina depois que o usuário pesquisar algo, evitando a tentativa de buscar pelos campos e não pela pesquisa.
                    StkPanelNegócio.Visibility = Visibility.Visible;
                    StkPanelColuna1.Visibility = Visibility.Visible;
                    StkPanelColuna2.Visibility = Visibility.Visible;
                    Btn_Salvar.Visibility = Visibility.Visible;
                    ConexãoDB.fecharConexao(sqlcon);


                    //Verificando se o SN é de um produto com suporte Premium:
                    SqlConnection sqlcon2 = ConexãoDB.obterConexão();

                    string DataPremium;
                    string Ativo;
                    string Debitos;
                    string DataGar;
                    LikeSN = "%" + SN.Text + "%";

                    SqlCommand sqlcmd2 = new SqlCommand("VerFinanceiro", sqlcon2);
                    sqlcmd2.CommandType = CommandType.StoredProcedure;
                    sqlcmd2.Parameters.AddWithValue("@SN", LikeSN);                                              //Envia o %SN% como parâmetro para o procedimento VerGarantia do banco Protheus. 
                    sqlcmd2.Parameters.Add("@ChkPremium", SqlDbType.VarChar, 10);
                    sqlcmd2.Parameters.Add("@Ativo", SqlDbType.Int);
                    sqlcmd2.Parameters.Add("@DBTOS", SqlDbType.VarChar, 10);
                    sqlcmd2.Parameters.Add("@DTGAR", SqlDbType.VarChar, 10);
                    sqlcmd2.Parameters["@ChkPremium"].Direction = ParameterDirection.Output;                          //Recebe o valor de saída do storedProcedure.
                    sqlcmd2.Parameters["@Ativo"].Direction = ParameterDirection.Output;
                    sqlcmd2.Parameters["@DBTOS"].Direction = ParameterDirection.Output;
                    sqlcmd2.Parameters["@DTGAR"].Direction = ParameterDirection.Output;                          //Recebe o valor de saída do storedProcedure.
                    sqlcmd2.ExecuteNonQuery();

                    Debitos = sqlcmd2.Parameters["@DBTOS"].Value.ToString();
                    DataPremium = sqlcmd2.Parameters["@ChkPremium"].Value.ToString();                                     //Envia para a variável DataGar a saída do procedimento para fazer as manipulações.
                    Ativo = sqlcmd2.Parameters["@Ativo"].Value.ToString();
                    DataGar = sqlcmd2.Parameters["@DTGAR"].Value.ToString();                                     //Envia para a variável DataGar a saída do procedimento para fazer as manipulações.

                    if (SN.Text == "Não Informado")
                    {
                        Block_Premium.Foreground = Brushes.Red;
                        Block_Premium.Text = "Premium: Informe o SN";
                        Block_Garantia.Foreground = Brushes.Red;
                        Block_Garantia.Text = "Garantia: Informe o SN";
                    }
                    else
                    {
                        if (Debitos == "1")
                        {
                            Block_Garantia.Foreground = Brushes.Red;
                            Block_Premium.Foreground = Brushes.Red;
                            Block_Garantia.Text = "Garantia e Suporte Suspensos";
                            Block_Premium.Text = "Verificar com a Administração";
                        }
                        else
                        {

                            if (DataPremium == "0")                                                                       //Procedimento retorna 0 se o SN não existir na tabela AA3010.
                            {
                                Block_Premium.Foreground = Brushes.Red;
                                Block_Premium.Text = "Não é Premium";
                            }
                            else
                            {
                                if (Ativo == "0")
                                {
                                    Block_Premium.Foreground = Brushes.Red;
                                    Block_Premium.Text = "Suporte Premium Suspenso";
                                }
                                else                                                                                          //Se for diferente de 0 quer dizer que o SN existe na tabela Premium.
                                {
                                    string dataConvertida = Convert.ToDateTime(DataPremium).ToString("dd/MM/yyyy");            //Converte o formato de data americada para BR.
                                    int tempoP = (DateTime.Parse(dataConvertida) - DateTime.Now.Date).Days;                    //Calcula a difença entre a data de vencimento da garantia e a data atual.

                                    if (tempoP >= 0)                                                                           //Se a quantidade de dias for positiva, está na garantia.
                                    {
                                        Block_Premium.Foreground = Brushes.Green;
                                        Block_Premium.Text = "Suporte Premium até: " + dataConvertida;
                                    }
                                    else
                                    {
                                        Block_Premium.Foreground = Brushes.Red;
                                        Block_Premium.Text = "Suporte Premium expirou em: " + dataConvertida;
                                    }
                                }
                            }

                            if (drNegócio == "Demo" || drNegócio == "Aluguel" || drNegócio == "Feira")
                            {
                                Block_Garantia.Foreground = Brushes.Green;
                                Block_Premium.Foreground = Brushes.Green;
                                Block_Garantia.Text = "Em Garantia";
                                Block_Premium.Text = "Possui Suporte Premium";
                            }
                            else
                            {
                                if (DataGar == "0")                                                                          //Procedimento retorna 0 se o SN não existir na tabela AA3010.
                                {
                                    Block_Garantia.Foreground = Brushes.Red;
                                    Block_Garantia.Text = "Garantia: SN não encontrado";
                                }
                                else                                                                                         //Se for diferente de 0 quer dizer que o SN existe na tabela AA3010 do Protheus11.
                                {
                                    string dataCorrigida = DataGar.Insert(4, "-").Insert(7, "-");                              //Formata a data que está como string no sqlserver, separando com - ano e mês.
                                    string dataConvertida = Convert.ToDateTime(dataCorrigida).ToString("dd/MM/yyyy");          //Converte o formato de data americada para BR.
                                    int tempog = (DateTime.Parse(dataConvertida) - DateTime.Now.Date).Days;                    //Calcula a difença entre a data de vencimento da garantia e a data atual.

                                    if (tempog >= 0)                                                                           //Se a quantidade de dias for positiva, está na garantia.
                                    {
                                        Block_Garantia.Foreground = Brushes.Green;
                                        Block_Premium.Foreground = Brushes.Green;
                                        Block_Garantia.Text = "Em garantia até: " + dataConvertida;
                                        Block_Premium.Text = "Suporte Premium (Garantia)";
                                    }
                                    else
                                    {
                                        Block_Garantia.Foreground = Brushes.Red;
                                        Block_Garantia.Text = "Garantia expirou em: " + dataConvertida;
                                    }
                                }
                            }
                        }

                        ConexãoDB.fecharConexao(sqlcon2);

                    }
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


        private void SalvarAlterações_Click(object sender, RoutedEventArgs e)
        {
            //Criando objeto "cadastrarSpot" a partir do método Models-CadastrarEquipamento:
            AtualizarCadastroEquipamento atualizar = new AtualizarCadastroEquipamento();
            atualizar.Cliente = Cliente.Text;
            atualizar.Contato = Contato.Text;
            atualizar.Email = Email.Text;
            atualizar.Senha = Senha.Text;
            atualizar.Dongle = Dongle.Text;
            atualizar.SN = SN.Text;
            atualizar.Data = Data.Text;
            atualizar.Tipo = Tipo.Text;
            atualizar.Func = Func.Text;
            atualizar.Obs = Obs.Text;
            atualizar.Placa = Placa.Text;
            atualizar.NomePc = NomePc.Text;
            atualizar.Licença = Licença.Text;
            atualizar.FlopSec = FlopSec.Text;
            atualizar.Produto = Produto.Text;
            atualizar.Mac = MacAdd.Text;
            atualizar.DataLicença = DataLicença.Text;

            if (string.IsNullOrEmpty(Negócio))
            {
                atualizar.Negócio = "Nulo";
            }
            else
            {
                atualizar.Negócio = Negócio;
            }

            try
            {
                //Validando campos que não podem ficar em branco:
                if (string.IsNullOrWhiteSpace(Cliente.Text))
                {
                    throw new ApplicationException("Preencha o campo 'Cliente'");
                }
                if (string.IsNullOrWhiteSpace(Senha.Text))
                {
                    throw new ApplicationException("Preencha o campo 'Contra Senha'");
                }
                if (string.IsNullOrWhiteSpace(Dongle.Text))
                {
                    throw new ApplicationException("Preencha o campo 'Senha Dongle'");
                }
                if (string.IsNullOrWhiteSpace(SN.Text))
                {
                    throw new ApplicationException("Preencha o campo 'Numero de Série'");
                }
                if (string.IsNullOrWhiteSpace(Tipo.Text))
                {
                    throw new ApplicationException("Preencha o campo 'Tipo de Licença'");
                }
                if (string.IsNullOrWhiteSpace(Licença.Text))
                {
                    throw new ApplicationException("Preencha o campo 'Licença'");
                }

                //Chama o procedimento que executa o comando SQL para escrever na tabela.
                atualizar.AtualizarEquip();

                //Limpa todos os campos:
                Cliente.Clear();
                Contato.Clear();
                Senha.Clear();
                Email.Clear();
                Dongle.Clear();
                SN.Clear();
                Data.Clear();
                DataLicença.Clear();
                Tipo.Clear();
                Func.Clear();
                Obs.Clear();
                Placa.Clear();
                Licença.Clear();
                FlopSec.Clear();
                NomePc.Clear();
                MacAdd.Clear();
                Produto.Clear();
                Block_Garantia.Text = " ";
                Block_Premium.Text = " ";
                Block_Negócio.Text = " ";
                RadVenda.IsChecked = false;
                RadDemo.IsChecked = false;
                RadAlguel.IsChecked = false;
                RadFeira.IsChecked = false;
                DataLicença.FontWeight = FontWeights.Regular;
                DataLicença.Foreground = Brushes.DimGray;

            }
            catch (Exception erro)
            {
                new CaixaDeMensagem(erro.Message);
            }
        }

        private void RadVenda_Check(object sender, RoutedEventArgs e)
        {
            Negócio = "Venda";
        }

        private void RadDemo_Check(object sender, RoutedEventArgs e)
        {
            Negócio = "Demo";
        }

        private void RadAlguel_Check(object sender, RoutedEventArgs e)
        {
            Negócio = "Aluguel";
        }

        private void RadFeira_Check(object sender, RoutedEventArgs e)
        {
            Negócio = "Feira";
        }

        private void Tipo_GotFocus(object sender, RoutedEventArgs e)
        {
            DataLicença.Text = DateTime.Now.ToShortDateString();
            DataLicença.FontWeight = FontWeights.Bold;
            DataLicença.Foreground = Brushes.RoyalBlue;
        }
    }
}
