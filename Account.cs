namespace s3665887_a1;

public class Account
{
    public int AccountNumber {get; init; }
    public string AccountType {get; init; }
    public string CustomerID {get; set; }
    public List<Transaction> Transactions {get; }
}