using Microsoft.Maui.Controls;
using PontoTech.Mvvm.ViewModels;
using System;

namespace PontoTech.Mvvm.View
{
    public partial class CapturaPage : ContentPage
    {
        public CapturaPage()
        {
            InitializeComponent();
            BindingContext = new CapturaPageViewModel();

            // Evento de clique do botão BtnCapturar para chamar a captura de foto
            BtnCapturar.Clicked += async (sender, e) =>
            {
                var viewModel = (CapturaPageViewModel)BindingContext;
                await viewModel.CapturarFoto(); // Chama o método para capturar a foto
            };
        }
    }
}
