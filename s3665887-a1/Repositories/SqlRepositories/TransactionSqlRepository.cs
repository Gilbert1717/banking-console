using System.Data;
using Database;
using s3665887_a1.Models;

namespace s3665887_a1.Repositories.SqlRepositories;

public class TransactionSqlRepository : ITransactionRepository
{
    private readonly SqlConnection _sqlConnection;
    private const string TableName = "[Transaction]";

    public TransactionSqlRepository(SqlConnection sqlConnection)
    {
        _sqlConnection = sqlConnection;
    }

    public void Save(Transaction transaction)
    {
        var parameters = new Dictionary<string, object?>();
        parameters.Add("TransactionType", transaction.TransactionType.ToString());
        parameters.Add("AccountNumber", transaction.AccountNumber);
        parameters.Add("DestinationAccountNumber", transaction.DestinationAccountNumber);
        parameters.Add("Amount", transaction.Amount);
        parameters.Add("Comment", transaction.Comment);
        parameters.Add("TransactionTimeUtc", transaction.TransactionTimeUtc);

        _sqlConnection.InsertData(TableName, parameters);
    }

    public List<Transaction> GetById(int accountNumber)
    {
        string sqlCommand =
            $"select * from {TableName} where AccountNumber = @AccountNumber order by TransactionTimeUtc DESC;";

        var parameters = new Dictionary<string, object?>();
        parameters.Add("AccountNumber", accountNumber);
        var accountData = _sqlConnection.GetDataTable(sqlCommand, parameters);
        var Transactions = new List<Transaction>();
        foreach (var row in accountData)
        {
            Transactions.Add(new Transaction(row.Field<int>("TransactionID"),
                (TransactionType)Enum.Parse(typeof(TransactionType), row.Field<string>("TransactionType")),
                row.Field<int>("AccountNumber"),
                row.Field<int?>("DestinationAccountNumber"),
                row.Field<decimal>("Amount"),
                row.Field<string>("Comment"),
                row.Field<DateTime>("TransactionTimeUtc")));
        }

        return Transactions;
    }
}