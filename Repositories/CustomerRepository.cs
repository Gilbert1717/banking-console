using s3665887_a1.DTOs;

namespace s3665887_a1.Repositories;

public class CustomerRepository
{
    public void SaveCustomer(Customer customer)
    {
        string customerId = "CustomerID";
        string name = "Name";
        string address = "Address";
        string city = "City";
        string postCode = "PostCode";

        string sqlCommand = $"INSERT INTO Customer ({customerId}, {name}, {address}, {city}, {postCode})" +
                            $"VALUES(@{customerId}, @{name}, @{address}, @{city}, @{postCode});";


        var parameters = new Dictionary<string, string?>();
        parameters.Add(customerId, customer.CustomerID.ToString());
        parameters.Add(name, customer.Name);
        parameters.Add(address, customer.Address);
        parameters.Add(city, customer.City);
        parameters.Add(postCode, customer.PostCode);
        DatabaseConnection.SaveData(sqlCommand, parameters);
    }

    public Customer GetCustomerById(int id)
    {
        string sqlCommand = "select * from Customer where CustomerID = @CustomerID;";
        var parameters = new Dictionary<string, string?>();
        parameters.Add("CustomerID", id.ToString());
        var customerData = DatabaseConnection.GetDataTable(sqlCommand, parameters);

        return new Customer(
            int.Parse(customerData[0]["CustomerID"].ToString()),
            customerData[0]["Name"].ToString(),
            customerData[0]["Address"].ToString(),
            customerData[0]["City"].ToString(),
            customerData[0]["PostCode"].ToString(),
            null,
            null
        );
    }
}