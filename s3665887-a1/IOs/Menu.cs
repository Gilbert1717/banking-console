using s3665887_a1.Models;
using s3665887_a1.Repositories.SqlRepositories;
using s3665887_a1.Services;

namespace s3665887_a1.IOs;

public class Menu
{
    public Customer _customer { get; private set; } = null;
    public void SetCustomer(Customer customer) => _customer = customer;
    protected Account _account { get; private set; } = null;


    private readonly string menuString = """
    [1] Deposit
    [2] Withdraw
    [3] Transfer
    [4] My Statement
    [5] Logout
    [6] Exit

    Enter an option: 
    """;

    protected readonly MenuService MenuService = new MenuService(
        new CustomerSqlRepository(),
        new LoginSqlRepository(),
        new AccountSqlRepository(),
        new TransactionSqlRepository()
    );

    public void LoginMenu()
    {
        Console.Write("Enter Login ID: ");
        string userName = Console.ReadLine();
        Console.Write("Enter Password: ");
        string userPassword = PasswordMasking();
        _customer = MenuService.LoginCustomer(userName, userPassword);
    }

    public void DisplayMenu()
    {
        PrintTitle();
        Console.Write(menuString);
    }

    public void MyStatement()
    {
        Console.WriteLine("myStatement");
    }

    protected void PrintTitle()
    {
        Console.WriteLine($"---{_customer.Name}---");
    }

    protected string LeaveCommentMenu()
    {
        Console.Clear();
        Console.WriteLine("Press Y to leave a comment: ");
        if (Console.ReadLine().ToUpper() == "Y")
        {
            Console.WriteLine("Please leave a comment: ");
            return Console.ReadLine();
        }

        return null;
    }

    protected void SelectAccount()
    {
        do
        {
            var dicAccounts = SelectAccountMenu();
            string accountSelection = Console.ReadLine().ToUpper();
            switch (accountSelection)
            {
                case "C":
                    this._account = dicAccounts[AccountType.C];
                    break;
                case "S":
                    this._account = dicAccounts[AccountType.S];
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    this._account = null;
                    break;
            }
        } while (this._account == null);
    }

    private Dictionary<AccountType, Account> SelectAccountMenu()
    {
        PrintTitle();
        var accounts = MenuService.GetAccountList(_customer);
        Dictionary<AccountType, Account> dicAccounts = new Dictionary<AccountType, Account>();
        foreach (var account in accounts)
        {
            if (account.AccountType == AccountType.S)
            {
                Console.WriteLine("[S] Savings Account");
                dicAccounts.Add(account.AccountType, account);
            }
            else if (account.AccountType == AccountType.C)
            {
                Console.WriteLine("[C] Checking Account");
                dicAccounts.Add(account.AccountType, account);
            }

            else
            {
                Console.Clear();
                Console.WriteLine("DataBase Error, please contact customer service");
                Environment.Exit(0);
            }
        }

        Console.WriteLine("Please select an account: ");
        return dicAccounts;
    }

    /**
     * Adapted from https://stackoverflow.com/questions/3404421/password-masking-console-application
     */
    private string PasswordMasking()
    {
        var password = string.Empty;
        ConsoleKey key;
        do
        {
            var keyInfo = Console.ReadKey(intercept: true);
            key = keyInfo.Key;

            if (key == ConsoleKey.Backspace && password.Length > 0)
            {
                Console.Write("\b \b");
                password = password[0..^1];
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                Console.Write("*");
                password += keyInfo.KeyChar;
            }
        } while (key != ConsoleKey.Enter);

        Console.WriteLine();
        return password;
    }
}