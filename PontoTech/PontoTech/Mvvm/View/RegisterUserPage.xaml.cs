using PontoTech.Mvvm.ViewModels;
using System;
using System.Text.RegularExpressions;

namespace PontoTech.Mvvm.View
{
    public partial class RegisterUserPage : ContentPage
    {
        public RegisterUserPage()
        {
            InitializeComponent();
            BindingContext = new RegisterUserPageViewModel();
        }

        private void BtnUserLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginUserPage());
        }

        private bool IsStrongPassword(string password)
        {
            // Expressão regular para validar a complexidade da senha
            string pattern = @"^(?=.*[!@#$%^&*()_+\\-=\\[\]{};':\""\|,.<>\/?])(?=.*[a-zA-Z0-9]).{8,12}$";

            // Verifica se a senha corresponde ao padrão
            return Regex.IsMatch(password, pattern);
        }

        private void BtnEntrar_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginUserPage());
            
        }
    }
}
