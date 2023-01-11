using System.Data;
using Database;
using s3665887_a1.Models;

namespace s3665887_a1.Repositories.SqlRepositories;

public class TransactionSqlRepository : ITransactionRepository
{
    private const string TableName = "[Transaction]";

    public void Save(Transaction transaction)
    {
        var parameters = new Dictionary<string, object?>();
        parameters.Add("TransactionType", transaction.TransactionType.ToString());
        parameters.Add("AccountNumber", transaction.AccountNumber);
        parameters.Add("DestinationAccountNumber", transaction.DestinationAccountNumber);
        parameters.Add("Amount", transaction.Amount);
        parameters.Add("Comment", transaction.Comment);
        parameters.Add("TransactionTimeUtc", transaction.TransactionTimeUtc);

        SqlConnection.InsertData(TableName, parameters);
    }

    public List<Transaction> GetById(int accountNumber)
    {
        string sqlCommand = $"select * from {TableName} where AccountNumber = @AccountNumber;";

        var parameters = new Dictionary<string, object?>();
        parameters.Add("AccountNumber", accountNumber);
        var accountData = SqlConnection.GetDataTable(sqlCommand, parameters);
        var Transactions = new List<Transaction>();
        foreach (var row in accountData)
        {
            Transactions.Add(new Transaction(row.Field<int>("TransactionID"),
                (TransactionType)Enum.Parse(typeof(TransactionType), row.Field<string>("TransactionType")),
                row.Field<int>("AccountNumber"),
                row.Field<string?>("DestinationAccountNumber"),
                row.Field<decimal>("Amount"),
                row.Field<string>("Comment"),
                row.Field<DateTime>("TransactionTimeUtc")));
        }

        return Transactions;
    }
}