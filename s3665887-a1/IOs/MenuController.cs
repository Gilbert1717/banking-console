using Database;
using s3665887_a1.Repositories.SqlRepositories;
using s3665887_a1.Services;

namespace s3665887_a1.IOs;

public static class MenuController
{
    private const string ConnectionString =
        "server=rmit.australiaeast.cloudapp.azure.com;Encrypt=False;uid=s3665887_a1;pwd=abc123";

    private static readonly SqlConnection SqlConnection = new(ConnectionString);

    private static readonly DataLoading DataLoading = new(
        new CustomerSqlRepository(SqlConnection),
        new LoginSqlRepository(SqlConnection),
        new AccountSqlRepository(SqlConnection),
        new TransactionSqlRepository(SqlConnection)
    );

    private static readonly Menu _menu = new(SqlConnection);
    private static readonly DepositMenu _dmenu = new(SqlConnection);
    private static readonly WithdrawMenu _wmenu = new(SqlConnection);
    private static readonly TransferMenu _tmenu = new(SqlConnection);
    private static readonly StatementMenu _smenu = new(SqlConnection);

    public static void UseMenu()
    {
        Task task = DataLoading.Preloading();
        MainMenu(task);
    }

    private static async void MainMenu(Task task)
    {
        string? menuSelect = null;
        do
        {
            if (_menu._customer == null)
            {
                _menu.LoginMenu();
            }

            else
            {
                await task;
                _menu.DisplayMenu();
                menuSelect = Console.ReadLine();
                MenuSwitch(menuSelect);
            }
        } while (menuSelect != "6");
    }

    private static void MenuSwitch(string menuSelection)
    {
        switch (menuSelection)
        {
            case "1":
                _dmenu.SetCustomer(_menu._customer);
                _dmenu.Deposit();
                break;
            case "2":
                _wmenu.SetCustomer(_menu._customer);
                _wmenu.Withdraw();
                break;
            case "3":
                _tmenu.SetCustomer(_menu._customer);
                _tmenu.Transfer();
                break;
            case "4":
                _smenu.SetCustomer(_menu._customer);
                _smenu.MyStatement();
                break;
            case "5":
                Console.Clear();
                _menu.SetCustomer(null);
                break;
            case "6":
                Console.WriteLine("Thanks for using the system");
                _menu.SetCustomer(null);
                break;
            default:
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nInvalid input\n");
                Console.ResetColor();
                break;
        }
    }
}