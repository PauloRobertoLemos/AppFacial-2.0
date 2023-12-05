using Microsoft.Maui.ApplicationModel.Communication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PontoTech.Mvvm.ViewModels
{
    internal class RecoverPassViewModel
    {
        public string txtCpf {  get; set; } 
        public string txtEmail {  get; set; }
        public string txtPassword {  get; set; }
        public string txtPasswordConf {  get; set; }

        public ICommand BtnAlterarSenha = new Command(() => App.Current.MainPage.DisplayAlert("", "", ""));

        public void validar()
        {
            if (string.IsNullOrWhiteSpace(txtCpf) && string.IsNullOrWhiteSpace(txtEmail) ||
                string.IsNullOrWhiteSpace(txtPassword) && string.IsNullOrWhiteSpace(txtPasswordConf))
            {
                App.Current.MainPage.DisplayAlert("Erro", "Todos os campos são obrigatórios.", "OK");
                return;
                if (!txtPassword.Equals(txtPasswordConf))
                {
                    App.Current.MainPage.DisplayAlert("Erro", "As senhas não coincidem. Tente novamente.", "OK");
                    return;
                    if (IsValidCpfAndEmail(txtCpf, txtEmail))
                    {
                        // Se os dados coincidirem, você pode prosseguir com a alteração da senha
                        // Implemente a lógica para alterar a senha aqui

                       App.Current.MainPage.DisplayAlert("Sucesso", "Senha alterada com sucesso!", "OK");
                    }
                    else
                    {
                        App.Current.MainPage.DisplayAlert("Erro", "CPF ou e-mail incorretos. Verifique e tente novamente.", "OK");
                    }
                }
            }
        }
        private bool IsValidCpfAndEmail(string cpf, string email)
        {

            return (cpf == "12345678900" && email == "usuario@email.com");
        }
    }
}
