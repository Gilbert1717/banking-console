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
        parameters.Add("AccountNumber", account.AccountNumber.ToString());

        SqlConnection.UpdateData(TableName, parameters, conditions);
    }

    public Account GetAccountByAccountNumber(int accountNumber)
    {
        string sqlCommand = $"select * from {TableName} where AccountNumber = @AccountNumber;";

        var parameters = new Dictionary<string, object?>();
        parameters.Add("AccountNumber", accountNumber);
        var accountData = SqlConnection.GetDataTable(sqlCommand, parameters)[0];
        return CreateAccountFromDataRow(accountData);
    }

    public List<Account> GetAccountsByCustomerID(int customerId)
    {
        string sqlCommand = $"select * from {TableName} where CustomerID = @CustomerID;";

        var parameters = new Dictionary<string, object?>();
        parameters.Add("CustomerID", customerId);
        return SqlConnection.GetDataTable(sqlCommand, parameters)
            .Select(CreateAccountFromDataRow)
            .ToList();
    }

    private decimal CalculateBalance(DTOs.TransactionDTO[] transactions)
    {
        return transactions.Sum(transaction => transaction.Amount);
    }

    private Account CreateAccountFromDataRow(DataRow accountData)
    {
        return new Account(
            accountData.Field<int>("AccountNumber"),
            accountData.Field<AccountType>("AccountType"),
            accountData.Field<int>("CustomerID"),
            accountData.Field<decimal>("Balance")
        );
    }
}