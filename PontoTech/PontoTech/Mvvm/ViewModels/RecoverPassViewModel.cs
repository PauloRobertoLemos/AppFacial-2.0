using Microsoft.Maui.ApplicationModel.Communication;
using PontoTech.Mvvm.Models;
using PontoTech.Mvvm.View;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PontoTech.Mvvm.ViewModels
{
    public class RecoverPassViewModel
    {
        public string txtCpf {  get; set; } 
        public string txtEmail {  get; set; }
        public string txtPassword {  get; set; }
        public string txtPasswordConf {  get; set; }

        BancoDadosContext db = new BancoDadosContext();

        public ICommand BtnAlterarSenha => new Command(() => validar(txtCpf,txtEmail,txtPassword));

        public async void validar(string Cpf,string email,string senha)
        {
            if (!string.IsNullOrWhiteSpace(txtCpf) && !string.IsNullOrWhiteSpace(txtEmail) &&
                !string.IsNullOrWhiteSpace(txtPassword) && !string.IsNullOrWhiteSpace(txtPasswordConf))
            {
                if (txtPassword.Equals(txtPasswordConf))
                {
                    if (IsValidCpf(Cpf))
                    {
                        db.recuperarSenha(email,Cpf,senha);
                        await App.Current.MainPage.DisplayAlert("Sucesso", "Senha alterada com sucesso!", "OK");
                        await App.Current.MainPage.Navigation.PushAsync(new LoginUserPage());
                    }
                    else
                    {
                        await App.Current.MainPage.DisplayAlert("Erro", "CPF ou e-mail incorretos. Verifique e tente novamente.", "OK");
                    }
                }
                else await App.Current.MainPage.DisplayAlert("Erro", "As senhas não coincidem. Tente novamente.", "OK");
            }
            else await App.Current.MainPage.DisplayAlert("Erro", "Todos os campos são obrigatórios.", "OK");
        }
        private bool IsValidCpf(string cpf)
        {
                int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
                string tempCpf;
                string digito;
                int soma;
                int resto;

                cpf = cpf.Trim();
                cpf = cpf.Replace(".", "").Replace("-", "");

                if (cpf.Length != 11)
                    return false;

                tempCpf = cpf.Substring(0, 9);
                soma = 0;

                for (int i = 0; i < 9; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

                resto = soma % 11;

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = resto.ToString();

                tempCpf = tempCpf + digito;

                soma = 0;

                for (int i = 0; i < 10; i++)
                    soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

                resto = soma % 11;

                if (resto < 2)
                    resto = 0;
                else
                    resto = 11 - resto;

                digito = digito + resto.ToString();

                return cpf.EndsWith(digito);
        }
    }
}
