using Database;
using s3665887_a1.Models;

namespace s3665887_a1.IOs;

public class TransferMenu : Menu
{
    public TransferMenu(SqlConnection sqlConnection) : base(sqlConnection)
    {
    }

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
            Console.Write("Please input the destination account number: ");
            string destinationAccountNumber = Console.ReadLine();
            destinationAccount = AccountValidation(destinationAccountNumber, _account);
        } while (destinationAccount == null);

        return destinationAccount;
    }

    private Account AccountValidation(string input, Account account)
    {
        if (account.AccountNumber.ToString() == input)
        {
            MenuService.PrintWarning("You can only transfer to a different account, please re-try");
            return null;
        }

        if (!int.TryParse(input, out int destinationAccountNumber))
        {
            MenuService.PrintWarning("Invalid account number, please re-try");
            return null;
        }

        var destinationAccount = MenuService.GetByAccountNumber(destinationAccountNumber);

        if (destinationAccount == null)
        {
            MenuService.PrintWarning("Destination account does not exist, please re-try");
            return null;
        }

        return destinationAccount;
    }

    private decimal? TransferAmountValidation()
    {
        decimal? transferAmount;
        do
        {
            PrintTitle();
            Console.Write("Please input the transfer amount (maximum 2 digits after decimal): ");
            string amount = Console.ReadLine();
            transferAmount = MenuService.WithdrawAmountValidation(amount, _account);
        } while (transferAmount == null && transferAmount != 0);

        return (decimal)transferAmount;
    }

    private void TransferMoney()
    {
        Account destinationAccount = SelectDestinationAccount();
        decimal transferAmount = (decimal)TransferAmountValidation();

        if (transferAmount != 0)
        {
            string comment = LeaveCommentMenu();
            MenuService.TransferMoney(comment, transferAmount, _account, destinationAccount);
        }
    }
}