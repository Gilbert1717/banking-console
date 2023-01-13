using Database;
using s3665887_a1.Models;
using s3665887_a1.Repositories.SqlRepositories;
using s3665887_a1.Services;

namespace s3665887_a1.IOs;

public class Menu
{
    public Menu(SqlConnection sqlConnection)
    {
        MenuService = new MenuService(
            new CustomerSqlRepository(sqlConnection),
            new LoginSqlRepository(sqlConnection),
            new AccountSqlRepository(sqlConnection),
            new TransactionSqlRepository(sqlConnection)
        );
    }

    public Customer _customer { get; private set; } = null;
    public void SetCustomer(Customer customer) => _customer = customer;
    public Account _account { get; private set; } = null;


    private readonly string menuString = """
    [1] Deposit
    [2] Withdraw
    [3] Transfer
    [4] My Statement
    [5] Logout
    [6] Exit

    Enter an option: 
    """;

    protected readonly MenuService MenuService;

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

    protected void PrintTitle()
    {
        Console.WriteLine($"---{_customer.Name}---");
    }

    protected string LeaveCommentMenu()
    {
        Console.WriteLine("Do you want to leave a comment: Y/N");
        ConsoleKey consoleKey;
        do
        {
            consoleKey = Console.ReadKey(intercept: true).Key;
        } while (consoleKey != ConsoleKey.Y && consoleKey != ConsoleKey.N);

        if (consoleKey == ConsoleKey.Y)
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
                    _account = dicAccounts[AccountType.C];
                    break;
                case "S":
                    _account = dicAccounts[AccountType.S];
                    break;
                default:
                    MenuService.PrintWarning("Invalid input");
                    _account = null;
                    break;
            }
        } while (_account == null);
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
                Console.WriteLine($"[S] Savings Account: {account.Balance:C}");
                dicAccounts.Add(account.AccountType, account);
            }
            else if (account.AccountType == AccountType.C)
            {
                Console.WriteLine($"[C] Checking Account: {account.Balance:C}");
                dicAccounts.Add(account.AccountType, account);
            }

            else
            {
                Console.Clear();
                Console.WriteLine("DataBase Error, please contact customer service");
                Environment.Exit(0);
            }
        }

        Console.Write("Please select an account: ");
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