using s3665887_a1.Models;

namespace s3665887_a1.IOs;

public class TransferMenu : Menu
{
    public void Transfer()
    {
        SelectAccount();
        TransferMoney();
    }

    private Account SelectDestinationAccount()
    {
        Account destinationAccount;
        do
        {
            PrintTitle();
            Console.WriteLine("Please input the destination account number : ");
            string destinationAccountNumber = Console.ReadLine();
            destinationAccount = AccountValidation(destinationAccountNumber, _account);
        } while (destinationAccount == null);

        return destinationAccount;
    }

    private Account AccountValidation(string input, Account account)
    {
        if (account.AccountNumber.ToString() == input)
        {
            Console.Clear();
            Console.WriteLine("You can only transfer to a different account, please re-try");
            return null;
        }

        if (int.TryParse(input, out int destinationAccountNumber))
        {
            return MenuService.GetByAccountNumber(destinationAccountNumber);
        }

        Console.Clear();
        Console.WriteLine("Destination account does not exist, please re-try");
        return null;
    }

    private decimal? TransferAmountValidation()
    {
        decimal? transferAmount;
        do
        {
            PrintTitle();
            Console.WriteLine("Please input the amount(maximum 2 digits after decimal): ");
            string amount = Console.ReadLine();
            transferAmount = MenuService.WithdrawAmountValidation(amount, _account);
        } while (transferAmount == null);

        return (decimal)transferAmount;
    }

    private void TransferMoney()
    {
        Account destinationAccount = SelectDestinationAccount();
        decimal transferAmount = (decimal)TransferAmountValidation();
        string comment = LeaveCommentMenu();

        MenuService.TransferMoney(comment, transferAmount, _account, destinationAccount);
    }
}