using System;
using s3665887_a1;

class Program
{
    static void Main()
    {
        string? menuSelect = null;
        do
        {
            Menu.displayMenu();
            menuSelect = Console.ReadLine();
            menuSwitch(menuSelect);
        } while (menuSelect != "5" && menuSelect != "6");
    }

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
}