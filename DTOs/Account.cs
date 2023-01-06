namespace s3665887_a1.DTOs;

public class Account
{
    private int AccountNumber { get; init; }
    private string AccountType { get; init; }
    private string CustomerID { get; set; }
    public List<Transaction> Transactions { get; }

    public Account(int accountNumber, string accountType, string customerId, List<Transaction> transactions)
    {
        AccountNumber = accountNumber;
        AccountType = accountType;
        CustomerID = customerId;
        Transactions = transactions;
    }
}