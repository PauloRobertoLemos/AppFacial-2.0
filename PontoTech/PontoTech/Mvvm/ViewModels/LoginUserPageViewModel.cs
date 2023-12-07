using MySqlConnector;
using PontoTech.Mvvm.Models;
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
            var db = new BancoDadosContext();
            try
            {
                int i = db.ValidarLogin(email, senha);
                string s = i.ToString();
                App.Current.MainPage.DisplayAlert("login", s, "fechar");
            }
            catch (MySqlException ex)
            {
                App.Current.MainPage.DisplayAlert("login", ex.Message, "fechar");

            }

        }

        public ICommand BtnUserRegister => new Command(() => App.Current.MainPage.Navigation.PushAsync(new RegisterUserPage()));
    }
}