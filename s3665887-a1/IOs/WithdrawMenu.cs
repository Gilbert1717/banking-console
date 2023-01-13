using Database;

namespace s3665887_a1.IOs;

public class WithdrawMenu : Menu
{
    public WithdrawMenu(SqlConnection sqlConnection) : base(sqlConnection)
    {
    }

    public void Withdraw()
    {
        SelectAccount();
        WithdrawMoney();
    }

    private void WithdrawMoney()
    {
        decimal? withdrawAmount;
        do
        {
            PrintTitle();
            Console.WriteLine("Please input the amount(maximum 2 digits after decimal): ");
            string amount = Console.ReadLine();
            withdrawAmount = MenuService.WithdrawAmountValidation(amount, _account);
        } while (withdrawAmount == null);

        string comment = LeaveCommentMenu();

        MenuService.WithdrawMoney(comment, (decimal)withdrawAmount, _account);
    }
}