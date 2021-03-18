using LicençasFloripa.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace LicençasFloripa.Views
{
    /// <summary>
    /// Interaction logic for CadastroNews.xaml
    /// </summary>
    public partial class CadastroNews : UserControl
    {
        public CadastroNews()
        {
            InitializeComponent();
        }

        //variáveis para receber o tipo de licença e negócio quando usuário clicar nos RadioButtons.
        string Tipo;
        string Negócio;

        private void AddNews_Click(object sender, RoutedEventArgs e)
        {
            //Criando objeto a partir do método Models-CadastrarEquipamento:
            CadastrarEquipamento cadastrarNews = new CadastrarEquipamento();
            cadastrarNews.Cliente = Cliente.Text;
            cadastrarNews.Contato = Contato.Text;
            cadastrarNews.Email = Email.Text;
            cadastrarNews.Senha = Senha.Text;
            cadastrarNews.Dongle = Dongle.Text;
            cadastrarNews.SN = "###";
            cadastrarNews.Data = Data.Text;
            cadastrarNews.Tipo = Tipo + ' ' + ParcNum.Text;
            cadastrarNews.Func = Func.Text;
            cadastrarNews.Obs = Obs.Text;
            cadastrarNews.Placa = "###";
            cadastrarNews.NomePc = NomePc.Text;
            cadastrarNews.Licença = Licença.Text;
            cadastrarNews.FlopSec = FlopSec.Text;
            cadastrarNews.Produto = "NewsClient";
            cadastrarNews.Mac = MacAdd.Text;
            cadastrarNews.Negócio = Negócio;

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
                if (string.IsNullOrWhiteSpace(Tipo))
                {
                    throw new ApplicationException("Preencha o campo 'Tipo de Licença'");
                }
                if (string.IsNullOrWhiteSpace(Licença.Text))
                {
                    throw new ApplicationException("Preencha o campo 'Licença'");
                }

                //Chama o procedimento que executa o comando SQL para escrever na tabela.
                cadastrarNews.CadastrarEquip();

                //Limpa todos os campos:
                Cliente.Clear();
                Contato.Clear();
                Senha.Clear();
                Email.Clear();
                Dongle.Clear();
                Data.Clear();
                ParcNum.Clear();
                Func.Clear();
                Obs.Clear();
                Licença.Clear();
                FlopSec.Clear();
                NomePc.Clear();
                MacAdd.Clear();

            }

            catch (Exception erro)
            {
                new CaixaDeMensagem(erro.Message);
            }
        }
        private void RadDef_Click(object sender, RoutedEventArgs e)
        {
            Tipo = RadDef.Content.ToString();
            ParcNum.Visibility = Visibility.Hidden;
            ParcNum.Clear();
        }

        private void RadParc_Click(object sender, RoutedEventArgs e)
        {
            Tipo = RadParc.Content.ToString();
            ParcNum.Visibility = Visibility.Visible;
        }

        private void RadVenda_Click(object sender, RoutedEventArgs e)
        {
            Negócio = "Venda";
        }

        private void RadDemo_Click(object sender, RoutedEventArgs e)
        {
            Negócio = "Demo";
        }

        private void RadAlguel_Click(object sender, RoutedEventArgs e)
        {
            Negócio = "Aluguel";
        }

        private void RadFeira_Click(object sender, RoutedEventArgs e)
        {
            Negócio = "Feira";
        }
    }
}
