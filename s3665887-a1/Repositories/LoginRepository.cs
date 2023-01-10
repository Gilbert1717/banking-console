using System.Data;
using Database;
using s3665887_a1.Models;

namespace s3665887_a1.Repositories;

public class LoginRepository
{
    private const string TableName = "[Login]";

    public void InsertToDB(Login login)
    {
        var parameters = new Dictionary<string, object?>();
        parameters.Add("CustomerID", login.CustomerID);
        parameters.Add("LoginID", login.LoginID);
        parameters.Add("PasswordHash", login.PasswordHash);

        SqlConnection.InsertData(TableName, parameters);
    }

    public void Update(Login login)
    {
        var parameters = new Dictionary<string, object?>();
        parameters.Add("PasswordHash", login.PasswordHash);

        var conditions = new Dictionary<string, object?>();
        conditions.Add("LoginID", login.LoginID);

        SqlConnection.UpdateData(TableName, parameters, conditions);
    }

    public Login? GetById(string loginID)
    {
        string sqlCommand = $"select * from {TableName} where LoginID = @loginID;";
        var parameters = new Dictionary<string, object?>();
        parameters.Add("LoginID", loginID);
        var loginDatas = SqlConnection.GetDataTable(sqlCommand, parameters);
        if (loginDatas.Length == 0)
        {
            return null;
        }

        var loginData = loginDatas[0];
        return new Login
        {
            LoginID = loginData.Field<string>("LoginID"),
            CustomerID = loginData.Field<int>("CustomerID"),
            PasswordHash = loginData.Field<string>("PasswordHash")
        };
    }
}