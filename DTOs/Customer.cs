namespace s3665887_a1.DTOs;

public class Customer
{
    private int CustomerID { get; init; }
    private string Name { get; init; }
    private string Address { get; set; }
    private string City { get; set; }
    private string PostCode { get; set; }
    private List<Account> Accounts { get; }
    private Dictionary<string, string> Login { get; }

    public Customer(
        int customerId,
        string name,
        string address,
        string city,
        string postCode,
        List<Account> accounts,
        Dictionary<string, string> login)
    {
        CustomerID = customerId;
        Name = name;
        Address = address;
        City = city;
        PostCode = postCode;
        Accounts = accounts;
        Login = login;
    }
}