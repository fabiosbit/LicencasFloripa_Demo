using System;
using System.Windows;
using System.Windows.Controls;
using LicençasFloripa.Models;

namespace LicençasFloripa.Views
{
    /// <summary>
    /// Interaction logic for CadastroSpot.xaml
    /// </summary>
    public partial class CadastroEquipamento : UserControl
    {
        public CadastroEquipamento()
        {
            InitializeComponent();
        }

        //variáveis para receber o tipo de licença e negócio quando usuário clicar nos RadioButtons.
        string Tipo;
        string Negócio;

        private void AddEquip_Click(object sender, RoutedEventArgs e)
        {
            //Criando objeto "CadastroEquip" a partir do método Models-CadastrarEquipamento:
            CadastrarEquipamento cadastrarEquip = new CadastrarEquipamento();
            cadastrarEquip.Cliente = Cliente.Text;
            cadastrarEquip.Contato = Contato.Text;
            cadastrarEquip.Email = Email.Text;
            cadastrarEquip.Senha = Senha.Text;
            cadastrarEquip.Dongle = Dongle.Text;
            cadastrarEquip.SN = SN.Text;
            cadastrarEquip.Data = Data.Text;
            cadastrarEquip.Func = Func.Text;
            cadastrarEquip.Tipo = Tipo + ' ' + ParcNum.Text;
            cadastrarEquip.Obs = Obs.Text;
            cadastrarEquip.Placa = Placa.Text;
            cadastrarEquip.NomePc = NomePc.Text;
            cadastrarEquip.Licença = Licença.Text;
            cadastrarEquip.FlopSec = FlopSec.Text;
            cadastrarEquip.Produto = TextTitulo.Text;
            cadastrarEquip.Mac = "###";
            cadastrarEquip.Negócio = Negócio;

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
                if (string.IsNullOrWhiteSpace(Tipo))
                {
                    throw new ApplicationException("Preencha o campo 'Tipo de Licença'");
                }
                if (string.IsNullOrWhiteSpace(Licença.Text))
                {
                    throw new ApplicationException("Preencha o campo 'Licença'");
                }

                //Chama o procedimento que executa o comando SQL para escrever na tabela.
                cadastrarEquip.CadastrarEquip();

                //Limpa todos os campos:
                Cliente.Clear();
                Contato.Clear();
                Senha.Clear();
                Email.Clear();
                Dongle.Clear();
                SN.Clear();
                ParcNum.Clear();
                Func.Clear();
                Obs.Clear();
                Placa.Clear();
                Licença.Clear();
                FlopSec.Clear();
                NomePc.Clear();

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
