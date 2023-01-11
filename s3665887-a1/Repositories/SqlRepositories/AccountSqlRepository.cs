using System.Data;
using Database;
using s3665887_a1.Models;

namespace s3665887_a1.Repositories.SqlRepositories;

public class AccountSqlRepository : IAccountRepository
{
    private const string TableName = "[Account]";

    public void InsertToDB(DTOs.AccountDTO account)
    {
        var parameters = new Dictionary<string, object?>();
        parameters.Add("AccountNumber", account.AccountNumber);
        parameters.Add("AccountType", account.AccountType);
        parameters.Add("CustomerID", account.CustomerID);
        parameters.Add("Balance", CalculateBalance(account.Transactions));

        SqlConnection.InsertData(TableName, parameters);
    }

    public void Update(Account account)
    {
        var parameters = new Dictionary<string, object?>();
        parameters.Add("Balance", account.Balance);

        var conditions = new Dictionary<string, object?>();
        conditions.Add("AccountNumber", account.AccountNumber.ToString());

        SqlConnection.UpdateData(TableName, parameters, conditions);
    }

    public List<Account> GetById(int CustomerID)
    {
        string sqlCommand = $"select * from {TableName} where CustomerID = @CustomerID;";

        var parameters = new Dictionary<string, object?>();
        parameters.Add("CustomerID", CustomerID);
        var accountData = SqlConnection.GetDataTable(sqlCommand, parameters);

        return accountData.Select(CreateAccount).ToList();
    }

    public Account GetByAccountNumber(int accountNumber)
    {
        string sqlCommand = $"select * from {TableName} where AccountNumber = @AccountNumber;";

        var parameters = new Dictionary<string, object?>();
        parameters.Add("AccountNumber", accountNumber);
        var accountData = SqlConnection.GetDataTable(sqlCommand, parameters);
        if (accountData.Length == 0)
            return null;
        return CreateAccount(accountData[0]);
    }

    private Account CreateAccount(DataRow accountData)
    {
        return new Account(accountData.Field<int>("AccountNumber"),
            (AccountType)Enum.Parse(typeof(AccountType), accountData.Field<string>("AccountType")),
            accountData.Field<int>("CustomerID"),
            accountData.Field<decimal>("Balance"));
    }

    private decimal CalculateBalance(DTOs.TransactionDTO[] transactions)
    {
        return transactions.Sum(transaction => transaction.Amount);
    }
}