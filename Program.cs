using System;
using System.Data;
using Microsoft.Data.SqlClient;
using s3665887_a1;

class Program
{
    static void Main()
    {
        Menu.displayMenu();
        string menuSelect = Console.ReadLine();
        if (menuSelect == "5")
        {
            Console.WriteLine("Successfully Logout");
        }
        
        else if (menuSelect == "6")
        {
            Console.WriteLine("Thanks for using the system6");
        }
        
        while (menuSelect != "5"&&menuSelect != "6")
        {
            switch (menuSelect)
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
                default:
                    break;
            }
            Menu.displayMenu();
            menuSelect = Console.ReadLine();
        }
    }
}