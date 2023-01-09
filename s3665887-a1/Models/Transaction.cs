namespace s3665887_a1.Models;

public class Transaction
{
    

    public int? TransactionID { get; } = null;
    public TransactionType TransactionType { get; init; }
    public int AccountNumber{get; init; }
    public decimal Amount { get; init; }
    public string? DestinationAccountNumber { get; init; } = null;
    public string? Comment { get; init; } = null;
    public DateTime TransactionTimeUtc { get; init; }

    // private char transactionTypeValid(TransactionType transactionType)
    // {
    //     switch (transactionType)
    //     {
    //         case TransactionType.D:
    //         case TransactionType.W:
    //         case TransactionType.T:
    //         case TransactionType.S:
    //         
    //     }
    // }
    public Transaction(TransactionType transactionType, int accountNumber, decimal amount, string? destinationAccountNumber, string? comment, DateTime transactionTimeUtc)
    {
        TransactionType = transactionType;
        AccountNumber = accountNumber;
        Amount = amount;
        DestinationAccountNumber = destinationAccountNumber;
        Comment = comment;
        TransactionTimeUtc = transactionTimeUtc;
    }
    
    public Transaction(int transactionId, decimal amount, TransactionType transactionType, int accountNumber, string? destinationAccountNumber, string? comment, DateTime transactionTimeUtc)
    {
        TransactionID = transactionId;
        Amount = amount;
        TransactionType = transactionType;
        AccountNumber = accountNumber;
        DestinationAccountNumber = destinationAccountNumber;
        Comment = comment;
        TransactionTimeUtc = transactionTimeUtc;
    }
}

