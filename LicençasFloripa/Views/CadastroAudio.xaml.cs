using LicençasFloripa.Models;
using System;
using System.Windows;
using System.Windows.Controls;


namespace LicençasFloripa.Views
{
    /// <summary>
    /// Interaction logic for CadastroAudio.xaml
    /// </summary>
    public partial class CadastroAudio : UserControl
    {
        public CadastroAudio()
        {
            InitializeComponent();
        }

        //variáveis para receber o tipo de licença e negócio quando usuário clicar nos RadioButtons.
        string Tipo;
        string Negócio;

        private void AddAudio_Click(object sender, RoutedEventArgs e)
        {
            //Criando objeto a partir do método Models-CadastrarEquipamento:
            CadastrarEquipamento cadastrarAudio = new CadastrarEquipamento();
            cadastrarAudio.Cliente = Cliente.Text;
            cadastrarAudio.Contato = Contato.Text;
            cadastrarAudio.Email = Email.Text;
            cadastrarAudio.Senha = Senha.Text;
            cadastrarAudio.Dongle = Dongle.Text;
            cadastrarAudio.SN = "###";
            cadastrarAudio.Data = Data.Text;
            cadastrarAudio.Tipo = Tipo + ' ' + ParcNum.Text;
            cadastrarAudio.Func = Func.Text;
            cadastrarAudio.Obs = Obs.Text;
            cadastrarAudio.Placa = "###";
            cadastrarAudio.NomePc = "###";
            cadastrarAudio.Licença = Licença.Text;
            cadastrarAudio.FlopSec = FlopSec.Text;
            cadastrarAudio.Produto = "AudioWare";
            cadastrarAudio.Mac = "###";
            cadastrarAudio.Negócio = Negócio;

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
                cadastrarAudio.CadastrarEquip();

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
