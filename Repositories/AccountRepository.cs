using s3665887_a1.DTOs;

namespace s3665887_a1.Repositories;

public class AccountRepository
{
    private const string TableName = "[Account]";

    public void Save(Account account)
    {
        var parameters = new Dictionary<string, string?>();
        parameters.Add("AccountType", account.AccountType);
        parameters.Add("CustomerID", account.CustomerID);
        parameters.Add("AccountNumber", account.AccountNumber.ToString());
        // TODO: need to get Balance from somewhere
        parameters.Add("Balance", account.Balance);

        DatabaseConnection.InsertData(TableName, parameters);
    }

    public void Update(Account account)
    {
        var parameters = new Dictionary<string, string?>();


        var conditions = new Dictionary<string, string?>();
        parameters.Add("AccountNumber", account.AccountNumber.ToString());


        DatabaseConnection.UpdateData(TableName, parameters, conditions);
    }

    public Account Get()
    {
        // TODO: to be implemented
        return new Account();
    }
}