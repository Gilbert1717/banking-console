using s3665887_a1.DTOs;

namespace s3665887_a1.Repositories;

public class CustomerRepository
{
    public void SaveCustomer(Customer customer)
    {
        string CustomerID = "CustomerID";
        string Name = "Name";
        string Address = "Address";
        string City = "City";
        string PostCode = "PostCode";
        
        string sqlCommand = $"INSERT INTO Customer ({CustomerID}, {Name}, {Address}, {City}, {PostCode})" +
                            $"VALUES(@{CustomerID}, @{Name}, @{Address}, @{City}, @{PostCode});";
        

        var parameters = new Dictionary<string, string?>();
        parameters.Add(CustomerID,customer.CustomerID.ToString());
        parameters.Add(Name,customer.Name);
        parameters.Add(Address,customer.Address );
        parameters.Add(City,customer.City);
        parameters.Add(PostCode,customer.PostCode);
        DatabaseConnection.SaveData(sqlCommand, parameters);
    }
}