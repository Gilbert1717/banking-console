using s3665887_a1.Models;
using s3665887_a1.Repositories.SqlRepositories;

namespace s3665887_a1.Services;

public static class Menu
{
    private static string menuString = """
    [1] Deposit
    [2] Withdraw
    [3] Transfer
    [4] My Statement
    [5] Logout
    [6] Exit

    Enter an option: 
    """;

    private static MenuService menuService = new MenuService();

    public static void useMenu()
    {
        Customer? customer = null;
        string? menuSelect = null;
        do
        {
            if (customer == null)
            {
                customer = loginMenu();
            }

            else
            {
                displayMenu(customer);
                menuSelect = Console.ReadLine();
                customer = menuSwitch(menuSelect, customer);
            }
        } while (menuSelect != "6");
    }

    private static Customer? menuSwitch(string? s, Customer customer)
    {
        switch (s)
        {
            case "1":
                deposit(customer);
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
                return null;
            case "6":
                Console.WriteLine("Thanks for using the system");
                return null;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid input\n");
                Console.ResetColor();
                break;
        }

        return customer;
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

    public static Customer? loginMenu()
    {
        Console.Write("Enter Login ID: ");
        string userName = Console.ReadLine();
        Console.Write("Enter Password: ");
        string userPassword = PasswordMasking();
        return menuService.LoginCustomer(userName, userPassword);
    }

    public static void displayMenu(Customer customer)
    {
        Console.WriteLine($"---{customer.Name}---");
        Console.Write(menuString);
    }

    public static Dictionary<string, Account> selectAccountMenu(Customer customer)
    {
        Console.WriteLine($"---{customer.Name}---");
        Console.WriteLine("Please select an Account");
        var accounts = menuService.getAccountList(customer);
        Dictionary<string, Account> dicAccounts = new Dictionary<string, Account>();
        foreach (var account in accounts)
        {
            Console.Write("i");
            if (account.AccountType == AccountType.S)
            {
                Console.WriteLine("[S]avings Account");
                dicAccounts.Add("S", account);
            }

            else if (account.AccountType == AccountType.C)
            {
                Console.WriteLine("[C]hecking Account");
                dicAccounts.Add("C", account);
            }

            else
            {
                Console.Clear();
                Console.WriteLine("DataBase Error, please contact customer service");
            }
        }

        return dicAccounts;
    }

    public static Account? selectAccount(Customer customer)
    {
        var dicAccounts = selectAccountMenu(customer);
        string accountSelection = Console.ReadLine().ToUpper();
        switch (accountSelection)
        {
            case "C":
                return dicAccounts["C"];
            case "S":
                return dicAccounts["S"];
            default:
                Console.WriteLine("Invalid input");
                return null;
        }
    }

    public static void deposit(Customer customer)
    {
        Console.WriteLine($"---{customer.Name}---");
        Console.WriteLine("deposit");
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