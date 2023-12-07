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
            Server = "mysql-157000-0.cloudclusters.net",
            UserID = "admin",
            Password = "kjOAt4X2",
            Database = "PontoTech",
            Port = 18608,
            SslMode = MySqlSslMode.VerifyCA,
            SslCa = ,

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
        public int ValidarLogin(string nomeUsuario, string senha)
        {
            
            
                MySqlConnection conn = new MySqlConnection(strconexao.ConnectionString);

                string query = "SELECT * FROM PontoTech.Funcionario WHERE FuncionarioEmail=@email AND FuncionarioSenha=@Senha";

                using (MySqlCommand command = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    command.Parameters.AddWithValue("@email", "d@gmail.com");
                    command.Parameters.AddWithValue("@Senha", "dho");

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        
                    // Se o leitor tiver linhas, as credenciais são válidas
                    bool loginValido = reader.HasRows;

                        // Adicione uma linha de log
                        if (loginValido)
                        {
                            Console.WriteLine("Login bem-sucedido para o usuário: " + nomeUsuario);
                            return 1;
                        }
                        else
                        {
                            Console.WriteLine("Login falhou para o usuário: " + nomeUsuario);
                            return -1;
                        }

                        return 0;
                    }
                }
          
        }

    }
}
