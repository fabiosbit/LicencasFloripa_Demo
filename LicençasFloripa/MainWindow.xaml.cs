using LicençasFloripa.Views;
using System.Globalization;
using System.Windows;
using System.Windows.Markup;

namespace LicençasFloripa
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       public static ViewModelUserControl viewControl = new ViewModelUserControl();

        public MainWindow()
        {
            //Definindo o padrão de cultura pt-BR para que as datas fiquem no formato dia/mês/ano:
            CultureInfo.CurrentCulture = new CultureInfo("pt-BR", false);
            Language = XmlLanguage.GetLanguage(CultureInfo.CurrentCulture.IetfLanguageTag);

            InitializeComponent();
            DataContext = viewControl;
        }

        //app de geração de licenças removido para a verão demo
        //string floripasec; 

        public void CadastrarSigna_Click(object sender, RoutedEventArgs e)
        {
            CadastroEquipamento equipamento = new CadastroEquipamento();
            equipamento.TextTitulo.Text = "Signa";
            viewControl.View = equipamento;
        }

        private void CadastrarCg_Click(object sender, RoutedEventArgs e)
        {
            CadastroEquipamento equipamento = new CadastroEquipamento();
            equipamento.TextTitulo.Text = "CgWare";
            viewControl.View = equipamento;
        }

        private void CadastrarSpot_Click(object sender, RoutedEventArgs e)
        {
            CadastroEquipamento equipamento = new CadastroEquipamento();
            equipamento.TextTitulo.Text = "SpotWare";
            viewControl.View = equipamento;
        }

        private void CadastrarShift_Click(object sender, RoutedEventArgs e)
        {
            CadastroEquipamento equipamento = new CadastroEquipamento();
            equipamento.TextTitulo.Text = "ShiftWare";
            viewControl.View = equipamento;
        }

        private void CadastrarLog_Click(object sender, RoutedEventArgs e)
        {
            CadastroEquipamento equipamento = new CadastroEquipamento();
            equipamento.TextTitulo.Text = "LogWare";
            viewControl.View = equipamento;
        }

        private void CadastrarAudio_Click(object sender, RoutedEventArgs e)
        {
            CadastroAudio audio = new CadastroAudio();
            viewControl.View = audio;
        }

        private void CadastrarIngest_Click(object sender, RoutedEventArgs e)
        {
            CadastroEquipamento equipamento = new CadastroEquipamento();
            equipamento.TextTitulo.Text = "IngestWare";
            viewControl.View = equipamento;
        }

        private void CadastrarNews_Click(object sender, RoutedEventArgs e)
        {
            CadastroNews news = new CadastroNews();
            viewControl.View = news;
        }

        private void PesquisarLicenças_Click(object sender, RoutedEventArgs e)
        {
            PesquisaLicenças pesquisaLicenças = new PesquisaLicenças();
            viewControl.View = pesquisaLicenças;
        }

        private void PesquisarGeral_Click(object sender, RoutedEventArgs e)
        {
            PesquisaGeral geral = new PesquisaGeral();
            viewControl.View = geral;
            geral.PesquisarGeral_Click(sender, e);
        }

        private void Sair_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void CadastroPremium_Click(object sender, RoutedEventArgs e)
        {
            CadastroPremium premium = new CadastroPremium();
            viewControl.View = premium;
        }

        private void PesquisarPremium_Click(object sender, RoutedEventArgs e)
        {
            PesquisaPremium pesquisaPremium = new PesquisaPremium();
            viewControl.View = pesquisaPremium;
        }

        private void PesquisarGeralPremium_Click(object sender, RoutedEventArgs e)
        {
            PesquisaGeralPremium pesquisaGeralPremium = new PesquisaGeralPremium();
            viewControl.View = pesquisaGeralPremium;
            pesquisaGeralPremium.PesquisarGeralPremium_Click(sender, e);
        }

        private void FloripaSec_Click(object sender, RoutedEventArgs e)
        {
            new CaixaDeMensagem("Removido na versão demo");

            //try
            //{
            //    Process.Start(@"Anexos\" + floripasec);
            //}
            //catch (System.Exception erro)
            //{
            //    new CaixaDeMensagem(erro.Message);
            //}
        }

        private void FlopSec233_Checked(object sender, RoutedEventArgs e)
        {
            //floripasec = "demo.exe";
        }

        private void FlopSec108_Checked(object sender, RoutedEventArgs e)
        {
            //floripasec = "demo.exe";
        }

        private void Pendencias_Click(object sender, RoutedEventArgs e)
        {
            PesquisarDevedores cadastroDevedor = new PesquisarDevedores();
            cadastroDevedor.Listar();
            viewControl.View = cadastroDevedor;
        }

        private void PesquisarSns_Click(object sender, RoutedEventArgs e)
        {
            PesquisarSNs consultas = new PesquisarSNs();
            viewControl.View = consultas;
        }

        private void MicrosigaClientes_Click(object sender, RoutedEventArgs e)
        {
            MicrosigaClientes clientes = new MicrosigaClientes();
            viewControl.View = clientes;
        }

        private void ProdutosCliente_Click(object sender, RoutedEventArgs e)
        {
            PesquisaProdutosDoCliente produtosCliente = new PesquisaProdutosDoCliente();
            viewControl.View = produtosCliente;
        }

        private void CadLicenças_Exp_Expanded(object sender, RoutedEventArgs e)
        {
            GerLicenças_Exp.IsExpanded = false;
            Contratos_Exp.IsExpanded = false;
            Financeiro_Exp.IsExpanded = false;
            Microsiga_Exp.IsExpanded = false;
        }

        private void GerLicenças_Exp_Expanded(object sender, RoutedEventArgs e)
        {
            CadLicenças_Exp.IsExpanded = false;
            Contratos_Exp.IsExpanded = false;
            Financeiro_Exp.IsExpanded = false;
            Microsiga_Exp.IsExpanded = false;
        }

        private void Contratos_Exp_Expanded(object sender, RoutedEventArgs e)
        {
            GerLicenças_Exp.IsExpanded = false;
            CadLicenças_Exp.IsExpanded = false;
            Financeiro_Exp.IsExpanded = false;
            Microsiga_Exp.IsExpanded = false;
        }

        private void Financeiro_Exp_Expanded(object sender, RoutedEventArgs e)
        {
            GerLicenças_Exp.IsExpanded = false;
            Contratos_Exp.IsExpanded = false;
            CadLicenças_Exp.IsExpanded = false;
            Microsiga_Exp.IsExpanded = false;
        }

        private void Microsiga_Exp_Expanded(object sender, RoutedEventArgs e)
        {
            GerLicenças_Exp.IsExpanded = false;
            Contratos_Exp.IsExpanded = false;
            CadLicenças_Exp.IsExpanded = false;
            Financeiro_Exp.IsExpanded = false;
        }
    }
}
