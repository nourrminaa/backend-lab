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

    public List<DataItem> GetAll()
    {
        using var connection = new SqlConnection(_connectionString);
        // .Query<DataItem> is a Dapper method that executes the SQL query and maps the results to a list of DataItem objects
        return connection.Query<DataItem>("SELECT Id, Name, Description FROM Data").ToList();
    }
}
