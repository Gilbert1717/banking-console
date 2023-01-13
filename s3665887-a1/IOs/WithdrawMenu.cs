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
            Console.Write("Please input the withdrawal amount (maximum 2 digits after decimal): ");
            string amount = Console.ReadLine();
            withdrawAmount = MenuService.WithdrawAmountValidation(amount, _account);
        } while (withdrawAmount == null && withdrawAmount != 0);

        if (withdrawAmount != 0)
        {
            string comment = LeaveCommentMenu();
            MenuService.WithdrawMoney(comment, (decimal)withdrawAmount, _account);
        }
    }
}