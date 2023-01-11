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
    public readonly decimal atmWithdraw = 0.05m;
    
    public readonly decimal accountTransfer  = 0.1m;
    public int? TransactionID { get; } = null;
    public TransactionType TransactionType { get; init; }
    public int AccountNumber{get; init; }
    public decimal Amount { get; init; }
    public string DestinationAccountNumber { get; init; } = null;
    public string Comment { get; init; }
    public DateTime TransactionTimeUtc { get; init; }

    public Transaction() {}
    
    public Transaction(TransactionType transactionType, int accountNumber, decimal amount, string destinationAccountNumber, string comment, DateTime transactionTimeUtc)
    {
        TransactionType = transactionType;
        AccountNumber = accountNumber;
        Amount = amount;
        DestinationAccountNumber = destinationAccountNumber;
        Comment = comment;
        TransactionTimeUtc = transactionTimeUtc;
    }
    
    public Transaction(int transactionId, TransactionType transactionType, int accountNumber, string? destinationAccountNumber, decimal amount, string? comment, DateTime transactionTimeUtc)
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



