using System;
using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using PontoTech.Mvvm.Models;
using PontoTech.Mvvm.ViewModels;

namespace PontoTech.Mvvm.View
{
    public partial class PanelUserPage : ContentPage
    {   
        String cpf {  get; set; }
        public PanelUserPage()
        {
            InitializeComponent();
            BindingContext = new PanelUserPageViewModel();
            AtualizarHora();
        }

        public PanelUserPage(string cpf) 
        {
            InitializeComponent();
            BindingContext = new PanelUserPageViewModel();
            AtualizarHora();
            this.cpf = cpf;
        }

        private async void AtualizarHora()
        {
            while (true)
            {
                lblHoraAtual.Text = DateTime.Now.ToString("HH:mm:ss");
                await Task.Delay(1000);
            }
        }



        private void EntradaFrame_Tapped(object sender, TappedEventArgs e)
        {
            BancoDadosContext bd = new BancoDadosContext();
            bd.InserirEntrada(cpf,new Entradas("Entrada"));
            App.Current.MainPage.DisplayAlert("Sucesso", "Seu ponto esta batido", "fechar");

        }

        private  void PausaFrame_Tapped(object sender, TappedEventArgs e)
        {
            BancoDadosContext bd = new BancoDadosContext();
            bd.InserirEntrada(cpf,new Entradas("Almoço"));
        }

        private  void RetornoFrame_Tapped(object sender, TappedEventArgs e)
        {
            BancoDadosContext bd = new BancoDadosContext();
            bd.InserirEntrada(cpf,new Entradas("Retorno Do Alomoço"));
        }

        private  void SaidaFrame_Tapped(object sender, TappedEventArgs e)
        {
            BancoDadosContext bd = new BancoDadosContext();
            bd.InserirEntrada(cpf,new Entradas("Saida"));
        }
    }
}