using Microsoft.Maui.Controls;
using PontoTech.Mvvm.ViewModels;

namespace PontoTech.Mvvm.View;
public partial class RecoverPass : ContentPage
{
    public RecoverPass()
    {
        InitializeComponent();
        BindingContext = new RecoverPassViewModel();
    }



}