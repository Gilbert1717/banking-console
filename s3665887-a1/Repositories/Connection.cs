using System.Data;
using Microsoft.Data.SqlClient;

namespace s3665887_a1.Repositories;

public static class Connection
{
    private const string ConnectionString =
        "server=rmit.australiaeast.cloudapp.azure.com;" +
        "Encrypt=False;" +
        "uid=s3665887_a1;" +
        "pwd=abc123";

    public static DataRow[] GetDataTable(string sqlCommand, Dictionary<string, object?>? sqlParameters = null)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var command = GetCommandWithParameters(sqlCommand, sqlParameters, connection);

        var table = new DataTable();
        new SqlDataAdapter(command).Fill(table);

        return table.Select();
    }
    
    

    public static void InsertData(string table, Dictionary<string, object?> sqlParameters)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        string sqlCommand = $"INSERT INTO {table} ({string.Join(", ", sqlParameters.Keys)}) " +
                            $"VALUES(@{string.Join(", @", sqlParameters.Keys)});";

        var command = GetCommandWithParameters(sqlCommand, sqlParameters, connection);

        command.ExecuteNonQuery();
    }

    public static void UpdateData(
        string table,
        Dictionary<string, object?> valueParameters,
        Dictionary<string, object?> conditions)
    {
        using var connection = new SqlConnection(ConnectionString);
        connection.Open();

        var value = valueParameters.Keys.Select(key => $"{key} = @{key}");
        var condition = conditions.Keys.Select(key => $"{key} = @{key}");
        string sqlCommand = $"UPDATE {table} " +
                            $"SET {string.Join(", ", value)} " +
                            $"WHERE {string.Join(", ", condition)};";

        // Combine two dictionaries as both are needed for SQL parameters
        var sqlParameters = valueParameters.Union(conditions).ToDictionary(k => k.Key, v => v.Value);
        var command = GetCommandWithParameters(sqlCommand, sqlParameters, connection);

        command.ExecuteNonQuery();

       
    }

    private static SqlCommand GetCommandWithParameters(
        string sqlCommand,
        Dictionary<string, object?>? sqlParameters,
        SqlConnection connection)
    {
        var command = connection.CreateCommand();
        command.CommandText = @sqlCommand;
        if (sqlParameters != null)
        {
            foreach (var parameter in sqlParameters)
            {
                command.Parameters.AddWithValue(parameter.Key, parameter.Value ?? (object)DBNull.Value);
            }
        }

        return command;
    }
}