using s3665887_a1.Repositories;

namespace s3665887_a1.Models;

public class Customer
{
    public int CustomerID { get; }
    public string Name { get; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? PostCode { get; set; }
    

    public Customer(
        int customerId,
        string name,
        string? address,
        string? city,
        string? postCode)
        
    {
        CustomerID = customerId;
        Name = name;
        Address = address;
        City = city;
        PostCode = postCode;
    }
    
    
}