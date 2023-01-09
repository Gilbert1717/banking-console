using s3665887_a1.Models;

namespace s3665887_a1.Repositories;

public class CustomerRepository
{
    private const string TableName = "[Customer]";

    public void Save(DTOs.CustomerDTO customer)
    {
        var parameters = new Dictionary<string, object?>();
        parameters.Add("CustomerID", customer.CustomerID);
        parameters.Add("Name", customer.Name);
        parameters.Add("Address", customer.Address);
        parameters.Add("City", customer.City);
        parameters.Add("PostCode", customer.PostCode);

        DatabaseConnection.InsertData(TableName, parameters);
    }

    public void Update(Customer customer)
    {
        var parameters = new Dictionary<string, object?>();
        parameters.Add("Name", customer.Name);
        parameters.Add("Address", customer.Address);
        parameters.Add("City", customer.City);
        parameters.Add("PostCode", customer.PostCode);

        var conditions = new Dictionary<string, object?>();
        conditions.Add("CustomerID", customer.CustomerID.ToString());

        DatabaseConnection.UpdateData(TableName, parameters, conditions);
    }

    // public Customer GetById(int CustomerID)
    // {
    //     string sqlCommand = $"select * from {TableName} where CustomerID = @CustomerID;";
    //
    //     var parameters = new Dictionary<string, object?>();
    //     parameters.Add("CustomerID", CustomerID.ToString());
    //     var customerData = DatabaseConnection.GetDataTable(sqlCommand, parameters);
    //
    //     return new Customer(
    //         int.Parse(customerData[0]["CustomerID"].ToString()),
    //         customerData[0]["Name"].ToString(),
    //         customerData[0]["Address"].ToString(),
    //         customerData[0]["City"].ToString(),
    //         customerData[0]["PostCode"].ToString(),
    //         null,
    //         null
    //     );
    // }
}