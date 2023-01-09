using System.Transactions;
using s3665887_a1.Models;
using Transaction = s3665887_a1.Models.Transaction;

namespace s3665887_a1.Repositories;

public class TransactionRepository
{
    private const string TableName = "[Transaction]";

    public void Save(Transaction transaction)
    {
        var parameters = new Dictionary<string, object?>();
        // TODO: need to get unknown values from somewhere
        parameters.Add("TransactionType", transaction.TransactionType.ToString());
        parameters.Add("AccountNumber", transaction.AccountNumber);
        parameters.Add("DestinationAccountNumber", transaction.DestinationAccountNumber);
        parameters.Add("Amount", transaction.Amount);
        parameters.Add("Comment", transaction.Comment);
        parameters.Add("TransactionTimeUtc", transaction.TransactionTimeUtc);

        DatabaseConnection.InsertData(TableName, parameters);
    }

    // public Transaction GetTransaction(Account account)
    // {
    //     // TODO: to be implemented
    //     
    //     return new Transaction();
    // }
}