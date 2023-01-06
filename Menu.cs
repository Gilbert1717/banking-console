using System.ComponentModel.DataAnnotations;

namespace s3665887_a1;

public static class Menu
{
    private static string menuString = """
    --- Gilbert Du---
    [1] Deposit
    [2] Withdraw
    [3] Transfer
    [4] My Statement
    [5] Logout
    [6] Exit

    Enter an option:
    """;
    
    private static void menuSwitch(string s)
    {
        switch (s)
        {
            case "1":
                Menu.deposit();
                break;
            case "2":
                Menu.withdraw();
                break;
            case "3":
                Menu.transfer();
                break;
            case "4":
                Menu.myStatement();
                break;
            case "5":
                Console.WriteLine("Successfully Logout");
                break;
            case "6":
                Console.WriteLine("Thanks for using the system6");
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid input\n");
                Console.ResetColor();
                break;
        }
    }

    // private static bool loginAuth(string userName, string userPassword)
    // {
    //     if (userPassword == password)
    //     {
    //         return true;
    //     }
    //     else
    //     {
    //         return false;
    //     }
    //      
    // }
    
    
    // public static void loginMenu()
    // {
    //     Console.WriteLine("Enter Login ID:");
    //     string userName = Console.ReadLine();
    //     Console.WriteLine("Enter Password:");
    //     string userPassword = Console.ReadLine();
    // }

    public static void displayMenu() => Console.WriteLine(menuString);

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

    public static void useMenu()
    {
        string? menuSelect = null;
        do
        {
            Menu.displayMenu();
            menuSelect = Console.ReadLine();
            Menu.menuSwitch(menuSelect);
        } while (menuSelect != "5" && menuSelect != "6");
    }
}