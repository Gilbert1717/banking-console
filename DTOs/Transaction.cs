namespace s3665887_a1.DTOs;

public class Transaction
{
    private int Amount { get; init; }
    private string? Comment { get; init; }
    private string TransactionTimeUtc { get; init; }

    public Transaction(int amount, string? comment, string transactionTimeUtc)
    {
        Amount = amount;
        Comment = comment;
        TransactionTimeUtc = transactionTimeUtc;
    }
}