namespace s3665887_a1.IOs;

public class DepositMenu : Menu
{
    public void Deposit()
    {
        SelectAccount();
        DepositMoney();
    }

    private void DepositMoney()
    {
        decimal? transactionAmount;
        do
        {
            PrintTitle();
            Console.WriteLine("Please input the amount(maximum 2 digits after decimal): ");
            string amount = Console.ReadLine();
            transactionAmount = MenuService.DepositAmountValidation(amount);
        } while (transactionAmount == null);

        string comment = LeaveCommentMenu();

        MenuService.DepositMoney(comment, (decimal)transactionAmount, _account);
    }
}