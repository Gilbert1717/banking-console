using s3665887_a1.Models;

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
        LoginService loginService = new LoginService();
        return loginService.authPassword(userName, userPassword);
    }

    public static void displayMenu(Customer customer)
    {
        Console.WriteLine($"---{customer.Name}---");
        Console.Write(menuString);
    }


    public static void deposit()
    {
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