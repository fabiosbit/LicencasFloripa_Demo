using System.Windows;

namespace LicençasFloripa.Views
{
    /// <summary>
    /// Lógica interna para CaixaDeMensagem.xaml
    /// </summary>
    public partial class CaixaDeMensagem : Window
    {
        public CaixaDeMensagem(string Mensagem)
        {
            InitializeComponent();
            MsgBox.Text = Mensagem;
            ShowDialog();
        }

        private void Btn_Ok_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
