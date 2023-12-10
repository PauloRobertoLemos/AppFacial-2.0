using PontoTech.Mvvm.Models;
using PontoTech.Mvvm.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PontoTech.Mvvm.ViewModels
{
    public class RegisterUserPageViewModel
    {
        public string txtCpf {get; set;}
        public string txtPassword {get; set;}
        public string txtName {get; set;}
        public string txtEmail {get; set;}
        public string txtPasswordConf {get; set;}

        

        public ICommand BtnRegister => new Command(() => 
        { Funcionario f = Cadastrar(txtName, txtCpf, txtEmail, txtPassword);
            var db = new BancoDadosContext();
            if (f != null)
            {
                db.InserirFuncionario(f.nome, f.Cpf, f.Email, f.Senha);
                App.Current.MainPage.Navigation.PushAsync(new LoginUserPage());
            }
            else App.Current.MainPage.DisplayAlert("Funcionario Vazio", "Tente novamente", "Fechar");
        });

        public ICommand BtnEntrar => new Command(() => App.Current.MainPage.Navigation.PushAsync(new LoginUserPage()));


        private Funcionario Cadastrar(String nome, String cpf, String email, String senha)
        {
            if (ValidarTodasPropriedades(nome,cpf,email,senha,txtPasswordConf))
            {
                 return new Funcionario(nome, cpf, email, senha);
            }
            return null;
        }

          bool ValidarTodasPropriedades(String nome,String cpf,String email,String senha,String senhaConf)
          {
            bool validEmail = false;
            bool validEqualPassword = false;
            bool validCpf = false;
            
            if (CamposVazios().Equals(true)) {
                App.Current.MainPage.DisplayAlert("Campos", "Você deixou Algum Campo Vazio", "Fechar");
            }
            else{
               if (validarEmail(email))
               {
                    validEmail = true;
               }
               else App.Current.MainPage.DisplayAlert("Email inválido", "Este e-mail é inválido, informe um email valido", "Fechar");

               if (validarIgualdadeSenha(senhaConf, senha))
               {
                   validEqualPassword = true;
               }
               else App.Current.MainPage.DisplayAlert("Senhas Não iguais", "As senhas não conhecidem, insira senhas iguais", "Fechar");
               
               if (validarCpf(cpf))
               {
                   validCpf = true;
               }
               else App.Current.MainPage.DisplayAlert("Cpf Invalido", "insira um cpf valido para prosseguir", "Fechar");
            }
            return validEmail.Equals(true) && validEqualPassword.Equals(true) && validCpf.Equals(true);

          }

        private bool CamposVazios()
        {
            if (String.IsNullOrEmpty(txtCpf) || String.IsNullOrEmpty(txtEmail)
                || String.IsNullOrEmpty(txtName) || String.IsNullOrEmpty(txtPassword) || String.IsNullOrEmpty(txtPasswordConf))
            {
                return true;
            }
            else return false;
        }
        private bool validarIgualdadeSenha(string passwordConf, string password)
        {
             return password.Equals(passwordConf);
        }

        private bool validarEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            return Regex.IsMatch(email, pattern);
        }

        private bool validarCpf(string cpf)
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
