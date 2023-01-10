using System.Data;
using Database;
using s3665887_a1.Models;

namespace s3665887_a1.Repositories.SqlRepositories;

public class CustomerSqlRepository : ICustomerRepository
{
    private const string TableName = "[Customer]";

    public void InsertToDB(DTOs.CustomerDTO customer)
    {
        var parameters = new Dictionary<string, object?>();
        parameters.Add("CustomerID", customer.CustomerID);
        parameters.Add("Name", customer.Name);
        parameters.Add("Address", customer.Address);
        parameters.Add("City", customer.City);
        parameters.Add("PostCode", customer.PostCode);

        SqlConnection.InsertData(TableName, parameters);
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

        SqlConnection.UpdateData(TableName, parameters, conditions);
    }

    //check if there is any existing customer in database
    public bool Any()
    {
        string sqlCommand = $"select count(*) as count from {TableName} ;";
        var count = SqlConnection.GetDataTable(sqlCommand)[0];
        return count.Field<int>("count") > 0;
    }

    public Customer GetById(int customerId)
    {
        string sqlCommand = $"select * from {TableName} where CustomerID = @CustomerID;";

        var parameters = new Dictionary<string, object?>();
        parameters.Add("CustomerID", customerId);
        var customerData = SqlConnection.GetDataTable(sqlCommand, parameters)[0];

        return new Customer(
            customerData.Field<int>("CustomerID"),
            customerData.Field<string>("Name"),
            customerData.Field<string?>("Address"),
            customerData.Field<string?>("City"),
            customerData.Field<string?>("PostCode")
        );
    }
}