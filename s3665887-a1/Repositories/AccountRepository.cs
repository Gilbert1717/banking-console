using System.Data;
using Database;
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

        SqlConnection.InsertData(TableName, parameters);
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


        SqlConnection.UpdateData(TableName, parameters, conditions);
    }

    public List<Account> GetById(int CustomerID)
    {
        string sqlCommand = $"select * from {TableName} where CustomerID = @CustomerID;";

        var parameters = new Dictionary<string, object?>();
        parameters.Add("CustomerID", CustomerID);
        var accountData = SqlConnection.GetDataTable(sqlCommand, parameters);
        var accounts = new List<Account>();
        foreach (var row in accountData)
        {
            accounts.Add(new Account(row.Field<int>("AccountNumber"),
                row.Field<AccountType>("AccountType"),
                row.Field<int>("CustomerID"),
                row.Field<decimal>("Balance")));
        }

        return accounts;
    }
}