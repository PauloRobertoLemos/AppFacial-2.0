using System;
using System.Text.RegularExpressions;

namespace PontoTech.Pages
{
    public partial class RegisterUserPage : ContentPage
    {
        public RegisterUserPage()
        {
            InitializeComponent();
        }

        private void BtnUserLogin_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new LoginUserPage());
        }

        private void BtnRegister_Clicked(object sender, EventArgs e)
        {
            ValidateRegister();
        }

        private async void ValidateRegister()
        {
            string name = txtName.Text;
            string cpf = txtCpf.Text;
            string email = txtEmail.Text;
            string password = txtPassword.Text;
            string passwordconf = txtPasswordConf.Text;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password) ||
                string.IsNullOrWhiteSpace(passwordconf) || string.IsNullOrWhiteSpace(name) ||
                string.IsNullOrWhiteSpace(cpf))
            {
                await DisplayAlert("Erro", "Todos os campos são obrigatórios.", "OK");
                return;
            }

            // Validar se as senhas coincidem
            if (password != passwordconf)
            {
                await DisplayAlert("Erro", "As senhas não coincidem. Tente novamente.", "OK");
                return;
            }

            // Validar o formato do e-mail
            if (!IsValidEmail(email))
            {
                await DisplayAlert("Erro", "Digite um endereço de e-mail válido.", "OK");
                return;
            }

            // Validar a complexidade da senha
            if (!IsStrongPassword(password))
            {
                await DisplayAlert("Erro", "A senha deve conter de 8 a 12 caracteres e pelo menos um caractere especial.", "OK");
                return;
            }

            // Implementar a lógica de conexão com o banco de dados aqui
            if (email == "email" && password == "password" && name == "name" && cpf == "cpf")
            {
                // Credenciais corretas, redirecione para o painel do usuário
                await Navigation.PushAsync(new PanelUserPage());
            }
            else
            {
                // Credenciais inválidas, exiba uma mensagem de erro
                await DisplayAlert("Erro", "Credenciais inválidas. Tente novamente.", "OK");
            }
        }

        private bool IsValidEmail(string email)
        {
            // Expressão regular para validar o formato de e-mail
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            // Verifica se o e-mail corresponde ao padrão
            return Regex.IsMatch(email, pattern);
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
