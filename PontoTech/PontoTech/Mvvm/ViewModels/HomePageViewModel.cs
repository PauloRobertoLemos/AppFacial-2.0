using PontoTech.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PontoTech.Mvvm.ViewModels
{
    public class HomePageViewModel
    {
         ContentPage paginaLogin = new LoginUserPage();
        public ICommand BtnResgistrarCommand => new Command(() => {App.Current.; });

        public ICommand BtnEntrarCommand => new Command(LoginPage);

        private void LoginPage()
        {
            App.Current.MainPage.DisplayAlert("erro", "erro", "erro");
        }
    }
}
