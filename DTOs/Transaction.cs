namespace s3665887_a1.DTOs;

public class Transaction
{
    private double Amount { get; init; }
    private string? Comment { get; init; }
    public DateTime TransactionTimeUtc { get; init; }

    public Transaction(double amount, string? comment, DateTime transactionTimeUtc)
    {
        Amount = amount;
        Comment = comment;
        TransactionTimeUtc = transactionTimeUtc;
    }
}