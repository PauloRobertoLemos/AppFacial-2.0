using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PontoTech.Mvvm.Models
{
    public class BancoDadosContext
    {
        private MySqlConnectionStringBuilder strconexao = new MySqlConnectionStringBuilder
        {
            Server = "18.226.185.16",
            UserID = "aplicacao",
            Password = "1234",
            Database = "PontoTech",
            Port = 3306,
            SslMode = MySqlSslMode.None
            

        };



        public void InserirFuncionario(String nome, String cpf, string email, string senha)
        {

            var cmd = new MySqlCommand();
            MySqlConnection conexao = new MySqlConnection(strconexao.ConnectionString );



            try
            {
                
                conexao.Open();
                cmd.Connection = conexao;

                cmd.CommandText = "INSERT INTO `Funcionario`(`FuncionarioNome`,`FuncionarioCpf`,`FuncionarioEmail`,`FuncionarioSenha`) VALUES(@nome,@cpf,@email,@senha);";
                cmd.Prepare();

                cmd.Parameters.AddWithValue("@nome", nome);
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
        public int ValidarLogin(string email, string senha)
        {
            
            
                MySqlConnection conn = new MySqlConnection(strconexao.ConnectionString);

                string query = "SELECT * FROM PontoTech.Funcionario WHERE FuncionarioEmail=@email AND FuncionarioSenha=@Senha";

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@Senha", senha);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        
                    // Se o leitor tiver linhas, as credenciais são válidas
                    bool loginValido = reader.HasRows;

                        // Adicione uma linha de log
                        if (loginValido)
                        {
                            Console.WriteLine("Login bem-sucedido para o usuário: " + email);
                            return 1;
                        }
                        else
                        {
                            Console.WriteLine("Login falhou para o usuário: " + email);
                            return -1;
                        }

                        return 0;
                    }
                }
          
        }

    }
}
