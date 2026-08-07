using Dapper;
using IDS_API_Project.Models;
using Microsoft.Data.SqlClient;

namespace IDS_API_Project.Repositories;

public class DataRepository
{
    private readonly string _connectionString;

    // Constructor that takes an IConfiguration object to retrieve the database connection string from the appsettings.json file
    public DataRepository(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("Default")!;
    }

    public async Task<List<DataItem>> GetAll()
    {
        using var connection = new SqlConnection(_connectionString);
        // QueryAsync is Dapper's async version of Query
        var result = await connection.QueryAsync<DataItem>("SELECT Id, Name, Description FROM Data");
        return result.ToList();
    }
}
