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

        

        private void BtnAlterarSenha_Clicked(object sender, EventArgs e)
        {
            string cpf = txtCpf.Text;
            string email = txtEmail.Text;
            string newPassword = txtPassword.Text;
            string confirmPassword = txtPasswordConf.Text;

            // Verificar se os campos estão vazios
            if (string.IsNullOrWhiteSpace(cpf) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                DisplayAlert("Erro", "Todos os campos são obrigatórios.", "OK");
                return;
            }

            // Verificar se as senhas coincidem
            if (newPassword != confirmPassword)
            {
                DisplayAlert("Erro", "As senhas não coincidem. Tente novamente.", "OK");
                return;
            }

            // Verificar se o CPF e o e-mail correspondem a algum registro no banco de dados
            if (IsValidCpfAndEmail(cpf, email))
            {
                // Se os dados coincidirem, você pode prosseguir com a alteração da senha
                // Implemente a lógica para alterar a senha aqui

                DisplayAlert("Sucesso", "Senha alterada com sucesso!", "OK");
            }
            else
            {
                DisplayAlert("Erro", "CPF ou e-mail incorretos. Verifique e tente novamente.", "OK");
            }
        }

        // Método de exemplo para validar o CPF e o e-mail no banco de dados (substitua com sua lógica real)
        private bool IsValidCpfAndEmail(string cpf, string email)
        {
            // Implemente sua lógica para verificar se o CPF e o e-mail correspondem a registros no banco de dados
            // Esta é apenas uma simulação de exemplo
            return (cpf == "12345678900" && email == "usuario@email.com");
        }
    }