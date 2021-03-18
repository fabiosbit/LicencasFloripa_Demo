using LicençasFloripa.Models;
using System;
using System.Windows;
using System.Windows.Controls;

namespace LicençasFloripa.Views
{
    /// <summary>
    /// Interação lógica para CadastroPremium.xam
    /// </summary>
    public partial class CadastroPremium : UserControl
    {
        public CadastroPremium()
        {
            InitializeComponent();
        }

        private void CadastrarPremium_Click(object sender, RoutedEventArgs e)
        {
            CadastrarPremium premium = new CadastrarPremium();
            premium.Cliente = Cliente.Text;
            premium.CTO = CTO.Text;
            premium.NFPS = NFPS.Text;
            premium.Produto = Produto.Text;
            premium.SN = SN.Text;
            premium.Obs = Obs.Text;
            premium.Data = Data.Text;
            premium.VencCTO = VencCTO.Text;
            premium.Proposta = Proposta.Text;

            if (string.IsNullOrWhiteSpace(Cliente.Text) || string.IsNullOrWhiteSpace(CTO.Text) || string.IsNullOrWhiteSpace(NFPS.Text) || string.IsNullOrWhiteSpace(Produto.Text) || 
                string.IsNullOrWhiteSpace(SN.Text) || Data.Text == "__/__/____" || VencCTO.Text == "__/__/____" || string.IsNullOrWhiteSpace(Proposta.Text))
            {
                new CaixaDeMensagem("Preencha todos os campos");
            }
            else
            {
                try
                {
                    premium.CadastrarClientePremium();
                }
                catch (Exception erro)
                {
                    new CaixaDeMensagem(erro.Message);
                }

                Cliente.Clear();
                CTO.Clear();
                NFPS.Clear();
                Produto.Clear();
                SN.Clear();
                Obs.Clear();
                Data.Text = DateTime.Now.ToShortDateString();
                VencCTO.Clear();
                Proposta.Clear();
            }
        }
    }
}
