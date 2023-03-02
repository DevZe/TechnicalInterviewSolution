
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

namespace ExcelUploaderDataLibrary.DataAccess;

public class SQLDataAccess : ISQLDataAccess
{
    readonly IConfiguration _configuration;
    public SQLDataAccess(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    //Get the connection string from configuration
    public string GetConnectionString(string name)
    {
        return _configuration.GetConnectionString(name);
    }

    //Load Data
    public List<T> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
    {
        string connectionString = GetConnectionString(connectionStringName);

        using IDbConnection connection = new SqlConnection(connectionString);
        List<T> rows = connection.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();
        return rows;
    }

    //Save Data
    public int SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
    {
        string connectionString = GetConnectionString(connectionStringName);

        using (IDbConnection connection = new SqlConnection(connectionString))
        {
            var affectedrows = connection.Execute(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
            return affectedrows;
        }

    }

}