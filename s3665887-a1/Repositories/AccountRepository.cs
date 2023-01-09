using s3665887_a1.Models;

namespace s3665887_a1.Repositories;

public class AccountRepository
{
    private const string TableName = "[Account]";
    
    
    public void InsertToDB(DTOs.AccountDTO account)
    {
        var parameters = new Dictionary<string, object?>();
        parameters.Add("AccountNumber", account.AccountNumber);
        parameters.Add("AccountType", account.AccountType);
        parameters.Add("CustomerID", account.CustomerID);
        parameters.Add("Balance", caculateBalance(account.Transactions));

        DatabaseConnection.InsertData(TableName, parameters);
    }

    public decimal caculateBalance(DTOs.TransactionDTO[] transactions)
    {
        decimal balance = 0.00m;
        foreach (var transaction in transactions)
        {
            balance += transaction.Amount;
        }

        return balance;
    }

    public void Update(Account account)
    {
        var parameters = new Dictionary<string, object?>();


        var conditions = new Dictionary<string, object?>();
        parameters.Add("AccountNumber", account.AccountNumber.ToString());


        DatabaseConnection.UpdateData(TableName, parameters, conditions);
    }

    // public Account GetAccount(int CustomerID)
    // {
    //     // TODO: to be implemented
    //     List<Account>? Accounts = null;
    //     string sqlCommand = $"select * from {TableName} where AccountNumber = @AccountNumber;";
    //
    //     var parameters = new Dictionary<string, object?>();
    //     parameters.Add("CustomerID", id.ToString());
    //     var accountDatas = DatabaseConnection.GetDataTable(sqlCommand, parameters);
    //     foreach (var accountData in accountDatas)
    //     {
    //         Accounts.Add(Account(
    //             int.Parse(accountData["AccountNumber"].ToString()),
    //             accountData["AccountNumber"].ToString(),
    //             accountData["AccountNumber"].ToString(),
    //             accountData["AccountNumber"].ToString(),
    //             null,
    //             null));
    //     }
    //     return new Account();
    // }

        

}