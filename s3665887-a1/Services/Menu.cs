using Microsoft.IdentityModel.Tokens;
using s3665887_a1.Models;
using s3665887_a1.Repositories.SqlRepositories;

namespace s3665887_a1.Services;

public static class Menu
{
    private static Account? _account = null;
    private static Customer? _customer = null;
    

    private static string menuString = """
    [1] Deposit
    [2] Withdraw
    [3] Transfer
    [4] My Statement
    [5] Logout
    [6] Exit

    Enter an option: 
    """;

    private static MenuService menuService = new MenuService(
        new CustomerSqlRepository(),
        new LoginSqlRepository(),
        new AccountSqlRepository(),
        new TransactionSqlRepository()
    );
    
    private static void PrintTitle()
    {
        Console.WriteLine($"---{_customer.Name}---");
    }

    public static void useMenu()
    {
        string? menuSelect = null;
        do
        {
            if (_customer == null)
            {
                loginMenu();
            }

            else
            {
                displayMenu();
                menuSelect = Console.ReadLine();
                menuSwitch(menuSelect);
            }
        } while (menuSelect != "6");
    }

    private static void menuSwitch(string? s)
    {
        switch (s)
        {
            case "1":
                deposit();
                break;
            case "2":
                withdraw();
                break;
            case "3":
                transfer();
                break;
            case "4":
                myStatement();
                break;
            case "5":
                Console.Clear();
                Console.WriteLine("Successfully Logout");
                _customer = null;
                break;
            case "6":
                Console.WriteLine("Thanks for using the system");
                _customer = null;
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid input\n");
                Console.ResetColor();
                break;
        }
    }

    /**
     * Adapted from https://stackoverflow.com/questions/3404421/password-masking-console-application
     */
    private static string PasswordMasking()
    {
        var pass = string.Empty;
        ConsoleKey key;
        do
        {
            var keyInfo = Console.ReadKey(intercept: true);
            key = keyInfo.Key;

            if (key == ConsoleKey.Backspace && pass.Length > 0)
            {
                Console.Write("\b \b");
                pass = pass[0..^1];
            }
            else if (!char.IsControl(keyInfo.KeyChar))
            {
                Console.Write("*");
                pass += keyInfo.KeyChar;
            }
        } while (key != ConsoleKey.Enter);

        Console.WriteLine();
        return pass;
    }

    public static void loginMenu()
    {
        Console.Write("Enter Login ID: ");
        string userName = Console.ReadLine();
        Console.Write("Enter Password: ");
        string userPassword = PasswordMasking();
        _customer = menuService.LoginCustomer(userName, userPassword);
    }

    public static void displayMenu()
    {
        PrintTitle();
        Console.Write(menuString);
    }

    public static Dictionary<string, Account> selectAccountMenu()
    {
        PrintTitle();
        var accounts = menuService.getAccountList(_customer);
        Dictionary<string, Account> dicAccounts = new Dictionary<string, Account>();
        foreach (var account in accounts)
        {
            if (account.AccountType == "S") 
            {
                Console.WriteLine("[S]avings Account");
            }
            else if (account.AccountType == "C")
            {
                Console.WriteLine("[C]hecking Account");
            }

            else
            {
                Console.Clear();
                Console.WriteLine("DataBase Error, please contact customer service");
            }
            dicAccounts.Add(account.AccountType, account);
        }
        Console.WriteLine("Please select an account: ");
        return dicAccounts;
    }

    

    public static void selectAccount()
    {
        var dicAccounts = selectAccountMenu();
        string accountSelection = Console.ReadLine().ToUpper();
        switch (accountSelection)
        {
            case "C":
            case "S":
                _account = dicAccounts[accountSelection];
                break;
            default:
                Console.WriteLine("Invalid input");
                _account = null;
                break;
        }
    }

    public static void depositAmountMenu()
    {
        Transaction? transaction;
        do
        {
            PrintTitle();
            Console.WriteLine("Please input the amount: ");
            string amount = Console.ReadLine();
            transaction = menuService.DepositAmountValidation(amount, _account);
        } while (transaction == null);

        menuService.SaveTransaction(transaction);
    }
    

    

    public static void deposit()
    {
        selectAccount();
        depositAmountMenu();
    }

    public static void withdraw()
    {
        Console.WriteLine("withdraw");
    }

    public static void transfer()
    {
        Console.WriteLine("transfer");
    }

    public static void myStatement()
    {
        Console.WriteLine("myStatement");
    }
}