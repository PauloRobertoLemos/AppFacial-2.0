using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Threading.Tasks;

public class DatabaseContext
{
    private readonly string _connectionString;

    public DatabaseContext(string connectionString)
    {
        _connectionString = connectionString;
    }

    private IDbConnection Connection => new MySqlConnection(_connectionString);

    public async Task<Funcionario> GetFuncionarioByIdAsync(int id)
    {
        using var connection = Connection;
        connection.Open();

        return await connection.QueryFirstOrDefaultAsync<Funcionario>(
            "SELECT * FROM Funcionario WHERE idFuncionario = @Id",
            new { Id = id }
        );
    }
}