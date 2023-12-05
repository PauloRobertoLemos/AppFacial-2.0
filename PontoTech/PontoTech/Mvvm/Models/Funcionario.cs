
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoTech.Mvvm.Models
{
    public class Funcionario
    {  public String nome { get { return nome;}set { } }
       public String Cpf { get { return Cpf;}set { } }
       public String Email { get { return Email;}set { } }
       public String Senha { get { return Senha;} set { } }
       public List<Entradas> entradas { get; set; }

       public Funcionario(String nome, String Cpf, String email, String senha)
       {
            this.nome = nome;
            this.Cpf = Cpf;
            this.Email = email;
            this.Senha = senha;
            this.entradas = new List<Entradas>();
       }

       public void AdicionarEntrada (String marcador)
        {
            this.entradas.Add(new Entradas(marcador));
        }

        public override string ToString()
        {
            return $"Nome:{nome}\n Cpf:{Cpf}\n Email:{Email}\n Senha:{Senha}";
        }
    }

    
}
