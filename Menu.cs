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
}