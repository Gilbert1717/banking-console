namespace s3665887_a1.IOs;

public class MenuController
{
    private readonly Menu _menu = new();
    private readonly DepositMenu _dmenu = new();
    private readonly WithdrawMenu _wmenu = new();
    private readonly TransferMenu _tmenu = new();
    private readonly StatementMenu _smenu = new();

    public void UseMenu()
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
                _menu.DisplayMenu();
                menuSelect = Console.ReadLine();
                MenuSwitch(menuSelect);
            }
        } while (menuSelect != "6");
    }

    private void MenuSwitch(string menuSelection)
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