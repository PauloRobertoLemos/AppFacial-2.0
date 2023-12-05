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

            // Verificar se os campos est�o vazios
            if (string.IsNullOrWhiteSpace(cpf) || string.IsNullOrWhiteSpace(email) ||
                string.IsNullOrWhiteSpace(newPassword) || string.IsNullOrWhiteSpace(confirmPassword))
            {
                DisplayAlert("Erro", "Todos os campos s�o obrigat�rios.", "OK");
                return;
            }

            // Verificar se as senhas coincidem
            if (newPassword != confirmPassword)
            {
                DisplayAlert("Erro", "As senhas n�o coincidem. Tente novamente.", "OK");
                return;
            }

            // Verificar se o CPF e o e-mail correspondem a algum registro no banco de dados
            if (IsValidCpfAndEmail(cpf, email))
            {
                // Se os dados coincidirem, voc� pode prosseguir com a altera��o da senha
                // Implemente a l�gica para alterar a senha aqui

                DisplayAlert("Sucesso", "Senha alterada com sucesso!", "OK");
            }
            else
            {
                DisplayAlert("Erro", "CPF ou e-mail incorretos. Verifique e tente novamente.", "OK");
            }
        }

        // M�todo de exemplo para validar o CPF e o e-mail no banco de dados (substitua com sua l�gica real)
        private bool IsValidCpfAndEmail(string cpf, string email)
        {
            // Implemente sua l�gica para verificar se o CPF e o e-mail correspondem a registros no banco de dados
            // Esta � apenas uma simula��o de exemplo
            return (cpf == "12345678900" && email == "usuario@email.com");
        }
    }