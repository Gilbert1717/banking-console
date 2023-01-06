namespace s3665887_a1;

public class Customer
{
    public int CustomerID {get; init; }
    public string Name {get; init; }
    public string Address {get; set; }
    public string City {get; set; }
    public string PostCode {get; set; }
    public List<Account> Accounts {get; }
    public Dictionary<string,string> Login {get; }
}