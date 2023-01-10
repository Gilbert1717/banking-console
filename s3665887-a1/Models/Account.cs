namespace s3665887_a1.Models;



public class Account
{
    public int AccountNumber { get; private init; }
    public string AccountType { get; private init; } = "S";
    public int CustomerID { get; private set; }
    public decimal Balance { get; private set; }


    public Account(int accountNumber, string accountType, int customerId, decimal balance)
    {
        AccountNumber = accountNumber;
        AccountType = accountType;
        CustomerID = customerId;
        Balance = balance;
    }
}