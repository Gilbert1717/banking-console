using s3665887_a1.Services;

namespace s3665887_a1.Models;

public enum TransactionType
{
    D,//Credit (Deposit money) 
    W,//Debit (Withdraw money) 
    T,//Credit and Debit (Transferring money between accounts) 
    S//Debit (Service charge) 
}

public class Transaction
{
    public int? TransactionID { get; } = null;
    public TransactionType TransactionType { get; init; }
    public int AccountNumber{get; init; }
    public decimal Amount { get; init; }
    public string? DestinationAccountNumber { get; init; } = null;
    public string? Comment { get; init; } = null;
    public DateTime TransactionTimeUtc { get; init; }

    
    public Transaction(TransactionType transactionType, int accountNumber, decimal amount, string? destinationAccountNumber, string? comment, DateTime transactionTimeUtc)
    {
        TransactionType = transactionType;
        AccountNumber = accountNumber;
        Amount = amount;
        DestinationAccountNumber = destinationAccountNumber;
        Comment = comment;
        TransactionTimeUtc = transactionTimeUtc;
    }
    
    public Transaction(int transactionId, decimal amount,TransactionType transactionType, int accountNumber, string? destinationAccountNumber, string? comment, DateTime transactionTimeUtc)
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



