using s3665887_a1.DTOs;

namespace s3665887_a1.Repositories;

public class TransactionRepository
{
    private const string TableName = "[Transaction]";

    public void Save(Transaction transaction)
    {
        var parameters = new Dictionary<string, string?>();
        // TODO: need to get unknown values from somewhere
        parameters.Add("TransactionType", transaction.TransactionType);
        parameters.Add("AccountNumber", transaction.AccountNumber);
        parameters.Add("DestinationAccountNumber", transaction.DestinationAccountNumber);
        parameters.Add("Amount", transaction.Amount.ToString());
        parameters.Add("Comment", transaction.Comment);
        parameters.Add("TransactionTimeUtc", transaction.TransactionTimeUtc);

        DatabaseConnection.InsertData(TableName, parameters);
    }

    public Transaction Get()
    {
        // TODO: to be implemented
        return new Transaction();
    }
}