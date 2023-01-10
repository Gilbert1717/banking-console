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

    // public Transaction GetTransaction(Account account)
    // {
    //     // TODO: to be implemented
    //     
    //     return new Transaction();
    // }
}