
using System.Data;
using Microsoft.Data.SqlClient;

namespace s3665887_a1.Repositories;

public static class DatabaseConnection
{
    const string connectionString =
        "server=rmit.australiaeast.cloudapp.azure.com;Encrypt=False;uid=s3665887_a1;pwd=abc123";
    
    
    public static DataRow[] GetDataTable(string sqlCommand)
    {
        // NOTE: Can use a using declaration instead of a using block.
        using var connection = new SqlConnection(connectionString);
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = sqlCommand;

        var table = new DataTable();
        new SqlDataAdapter(command).Fill(table);

        return table.Select();
    }

    public static void SaveData(string sqlCommand, Dictionary<string,string?> sqlParameters)
    {
        using var connection = new SqlConnection(connectionString);
        connection.Open();
        
        var command = connection.CreateCommand();
        command.CommandText = @sqlCommand;
        foreach(var parameter in sqlParameters)
        {
            command.Parameters.AddWithValue(parameter.Key, parameter.Value ?? (object) DBNull.Value);
        }
        Console.WriteLine(command.CommandText);
        command.ExecuteNonQuery();
    }
}