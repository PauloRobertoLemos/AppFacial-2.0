using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PontoTech.Mvvm.View;

namespace PontoTech.Mvvm.ViewModels
{
    internal class PanelUserPageViewModel
    {
        
        ICommand BtnSair => new Command( ()=>
        {
            try
            {
                 App.Current.MainPage.Navigation.PopAsync();
            }
            catch (Exception ex)
            { 
                App.Current.MainPage.DisplayAlert("erro",ex.Message, "fechar");
            }
        });

    }
}
