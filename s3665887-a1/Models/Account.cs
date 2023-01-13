namespace s3665887_a1.Models;

public class Account
{
    public int AccountNumber { get; }
    public AccountType AccountType { get; } = AccountType.S;
    public int CustomerID { get; }
    public decimal Balance { get; private set; }


    public Account(int accountNumber, AccountType accountType, int customerId, decimal balance)
    {
        AccountNumber = accountNumber;
        AccountType = accountType;
        CustomerID = customerId;
        Balance = balance;
    }

    public void UpdateBalance(decimal balance)
    {
        Balance = balance;
    }
}

public enum AccountType
{
    S,
    C
}