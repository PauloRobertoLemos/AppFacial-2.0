using PontoTech.Mvvm.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PontoTech.Mvvm.ViewModels
{
    internal class LoginUserPageViewModel
    {
        public string email { get; set; }
        public string senha { get; set; }


        public ICommand BtnUserLogin => new Command(async () => { 
            App.Current.MainPage.DisplayAlert("login", mensagem(), "fechar");
            await ValidateLogin();
            
        });

        private string mensagem()
        {
            return "email:" + email + " senha:" + senha;
        }

        private async Task ValidateLogin()
        {
            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(senha))
            {
                await App.Current.MainPage.DisplayAlert("Erro", "O endereço de email e senha são obrigatórios.", "OK");
                return;
                
            }
            else
            {
                App.Current.MainPage.Navigation.PushAsync(new PanelUserPage());
            }
        }

        public ICommand BtnUserRegister => new Command(() => App.Current.MainPage.Navigation.PushAsync(new RegisterUserPage()));
    }
}