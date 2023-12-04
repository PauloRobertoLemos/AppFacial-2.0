using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;

namespace PontoTech.Pages
{
    public partial class PanelUserPage : ContentPage
    {
        public PanelUserPage()
        {
            InitializeComponent();
            AtualizarHora();
        }

        private async void AtualizarHora()
        {
            while (true)
            {
                lblHoraAtual.Text = DateTime.Now.ToString("HH:mm:ss");
                await Task.Delay(1000); // Aguarda 1 segundo antes de atualizar novamente
            }
        }

        private async void BtnSair_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Shell.Current.GoToAsync("//LoginUserPage");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao fazer logout: " + ex.Message);
            }
        }

        private async void EntradaFrame_Tapped(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new CapturaPage());
        }

        private async void PausaFrame_Tapped(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new CapturaPage());
        }

        private async void RetornoFrame_Tapped(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new CapturaPage());
        }

        private async void SaidaFrame_Tapped(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new CapturaPage());
        }
    }
}