using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using PontoTech.Mvvm.ViewModels;

namespace PontoTech.Mvvm.View
{
    public partial class PanelUserPage : ContentPage
    {
        public PanelUserPage()
        {
            InitializeComponent();
            BindingContext = new PanelUserPageViewModel();
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