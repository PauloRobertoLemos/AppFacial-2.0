using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PontoTech.Mvvm.Models
{
    public class BancoDadosContext 
    {   private MySqlConnectionStringBuilder strconexao = new MySqlConnectionStringBuilder 
        {
            Server = "a3.cy9jxemryba8.us-east-2.rds.amazonaws.com",
            UserID = "admin",
            Password = "DhomynyFarias1512",
            Database = "PontoTech",
            Port = 3306,
        };

        

        public void InserirFuncionario(String nome,String cpf,string email, string senha)
        {

            var cmd = new MySqlCommand();
            MySqlConnection conexao = new MySqlConnection(strconexao.ConnectionString);
            
            

            try
            {
                conexao.Open();
                cmd.Connection = conexao;

                cmd.CommandText= "INSERT INTO `PontoTech`.`Funcionario`(`FuncionarioNome`,`FuncionarioCpf`,`FuncionarioEmail`,`FuncionarioSenha`) VALUES(@nome,@cpf,@email,@senha);";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@nome",nome);
                cmd.Parameters.AddWithValue("@cpf", cpf);
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@senha", senha);
                cmd.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                App.Current.MainPage.DisplayAlert("SQL ERROR", ex.Message, "Fechar");
            } 
            finally { conexao.Close(); }
            
        }


       
    }
}
