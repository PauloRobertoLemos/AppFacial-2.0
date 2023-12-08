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

        }
    }
}
