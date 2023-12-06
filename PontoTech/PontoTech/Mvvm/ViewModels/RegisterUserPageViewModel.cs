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
            f.AdicionarEntrada("PrimeiroAcesso");
            var db = new BancoDadosContext();
            if(f != null) {
                try {
                    db.Funcionarios.Add(f);
                    db.Entradas.Add(new Entradas("PrimeiroAcesso"));
                    db.SaveChanges();
                }catch(Exception ex) {
                    App.Current.MainPage.DisplayAlert("Erro", ex.Message, "fechar");
                }
                App.Current.MainPage.Navigation.PushAsync(new LoginUserPage());
            }
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

            }
            if (validEmail.Equals(true) && validEqualPassword.Equals(true))
            {
                return true;
            }
            else return false;

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
            // Expressão regular para validar o formato de e-mail
            string pattern = @"^[a-zA-Z0-9_.+-]+@[a-zA-Z0-9-]+\.[a-zA-Z0-9-.]+$";

            // Verifica se o e-mail corresponde ao padrão
            return Regex.IsMatch(email, pattern);
        }

        
    }
}
