using s3665887_a1.Models;

namespace s3665887_a1.IOs;

public class StatementMenu : Menu
{
    public void MyStatement(Account account)
    {
        SelectAccount();
        DisplayStatement(account);
    }

    private void DisplayStatement(Account account)
    {
        List<Transaction> transactions = MenuService.GetTransactionHistory(account);
    }
}