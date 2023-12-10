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
        
        ICommand BtnSair => new Command(async ()=>
        {
            try
            {
                await App.Current.MainPage.Navigation.PushAsync(new LoginUserPage());
            }
            catch (Exception ex)
            { 
                await App.Current.MainPage.DisplayAlert("erro",ex.Message, "fechar");
            }
        });

    }
}
