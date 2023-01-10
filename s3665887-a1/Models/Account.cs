namespace s3665887_a1.Models;

public class Account
{
    public int AccountNumber { get; private init; }
    public AccountType AccountType { get; private init; } = AccountType.Savings;
    public int CustomerID { get; private set; }
    public decimal Balance { get; private set; }


    public Account(int accountNumber, AccountType accountType, int customerId, decimal balance)
    {
        AccountNumber = accountNumber;
        AccountType = accountType;
        CustomerID = customerId;
        Balance = balance;
    }
}