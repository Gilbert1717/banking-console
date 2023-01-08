namespace s3665887_a1.DTOs;

public class Customer
{
    public int CustomerID { get; }
    public string Name { get; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? PostCode { get; set; }
    public List<Account>? Accounts { get; }
    public Login? Login { get; }

    public Customer(
        int customerId,
        string name,
        string? address,
        string? city,
        string? postCode,
        List<Account> accounts,
        Login login)
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