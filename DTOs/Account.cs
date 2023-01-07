namespace s3665887_a1.DTOs;

public class Account
{
    public int AccountNumber { get; private init; }
    public string AccountType { get; private init; }
    public string CustomerID { get; private set; }
    public List<Transaction> Transactions { get; }

    public Account(int accountNumber, string accountType, string customerId, List<Transaction> transactions)
    {
        AccountNumber = accountNumber;
        AccountType = accountType;
        CustomerID = customerId;
        Transactions = transactions;
    }

    public void addTransaction(Transaction transaction)
    {
        this.Transactions.Add(transaction);
    }
}