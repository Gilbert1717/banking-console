using s3665887_a1.Models;

namespace s3665887_a1.Repositories;

public class LoginRepository
{
    private const string TableName = "[Login]";

    public void Save(Login login)
    {
        var parameters = new Dictionary<string, object?>();
        // TODO: need to get customerID from somewhere
        parameters.Add("CustomerID", login.CustomerID);
        parameters.Add("LoginID", login.LoginID);
        parameters.Add("PasswordHash", login.PasswordHash);

        DatabaseConnection.InsertData(TableName, parameters);
    }

    public void Update(Login login)
    {
        var parameters = new Dictionary<string, object?>();
        parameters.Add("PasswordHash", login.PasswordHash);

        var conditions = new Dictionary<string, object?>();
        conditions.Add("LoginID", login.LoginID);

        DatabaseConnection.UpdateData(TableName, parameters, conditions);
    }

    // public Login GetById(int id)
    // {
    //     // TODO: to be implemented
    //     return new Login();
    // }
}