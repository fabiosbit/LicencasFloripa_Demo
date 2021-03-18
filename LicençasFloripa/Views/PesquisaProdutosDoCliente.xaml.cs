using LicençasFloripa.Models;
using System;
using System.Data;
using System.Windows;
using System.Windows.Controls;

namespace LicençasFloripa.Views
{
    /// <summary>
    /// Interação lógica para PesquisarSNs.xam
    /// </summary>
    public partial class PesquisaProdutosDoCliente : UserControl
    {
        public PesquisaProdutosDoCliente()
        {
            InitializeComponent();
        }

        string LikeNome;

        private void Btn_Pesquisar(object sender, RoutedEventArgs e)
        {
            LikeNome = "%" + Nome.Text.Trim() + "%";         //Adiciona os % para funcionar com o parâmetro like do sql.

            if (LikeNome == "%%")           //para não enviar %% para o storeProcedure quando o nome estiver em branco.
            {
                LikeNome = " ";
            }

            try
            {
                PesquisarMicrossiga produtosCliente = new PesquisarMicrossiga();
                DataTable dt = produtosCliente.ListarProdutosDoCliente(CodCliente.Text, CNPJ.Text, LikeNome);
                GridPesquisaClientes.ItemsSource = dt.DefaultView;

                if (GridPesquisaClientes.HasItems == false)
                {
                    new CaixaDeMensagem("Nenhum Registro Encontrado");
                }
            }
            catch (Exception erro)
            {
                new CaixaDeMensagem(erro.Message);
            }
        }

        private void CodCliente_GotFocus(object sender, RoutedEventArgs e)
        {
            CNPJ.Clear();
            Nome.Clear();
        }

        private void CNPJ_GotFocus(object sender, RoutedEventArgs e)
        {
            CodCliente.Clear();
            Nome.Clear();
        }

        private void Nome_GotFocus(object sender, RoutedEventArgs e)
        {
            CodCliente.Clear();
            CNPJ.Clear();
        }
    }
}
