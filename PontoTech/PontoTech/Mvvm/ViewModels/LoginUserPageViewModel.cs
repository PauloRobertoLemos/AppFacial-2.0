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
            await ValidateLogin(email,senha);
        });

        private async Task ValidateLogin(string email, string senha)
        {
            var db = new BancoDadosContext();
            try
            {
                string cpf = db.ValidarLogin(email, senha);
               if (!cpf.Equals(null))
                {
                    
                     await App.Current.MainPage.Navigation.PushAsync(new PanelUserPage(cpf));
                }
                else
                {
                     await App.Current.MainPage.DisplayAlert("login invalido","senha ou email invalido", "fechar");
                }
            }
            catch (MySqlException ex)
            {
                await App.Current.MainPage.DisplayAlert("login", ex.Message, "fechar");

            }

        }

        public ICommand BtnUserRegister => new Command(() => App.Current.MainPage.Navigation.PushAsync(new RegisterUserPage()));
    }
}