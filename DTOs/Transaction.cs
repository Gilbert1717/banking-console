namespace s3665887_a1.DTOs;

public class Transaction
{
    public double Amount { get; init; }
    public string? Comment { get; init; }
    public DateTime TransactionTimeUtc { get; init; }

    public Transaction(double amount, string? comment, DateTime transactionTimeUtc)
    {
        Amount = amount;
        Comment = comment;
        TransactionTimeUtc = transactionTimeUtc;
    }
}