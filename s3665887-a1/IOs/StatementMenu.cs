using s3665887_a1.Models;

namespace s3665887_a1.IOs;

public class StatementMenu : Menu
{
    private int step = 4;
    const string headerFormat = "| {0,-16} | {1,-16} | {2,-16} | {3,-26} | {4,-10} | {5,-20} | {6,-20} ";
    const string transactionFormat = "| {0,-16} | {1,-16} | {2,-16} | {3,-26} | {4,-10:C} | {5,-20} | {6,-20} ";
    string row = new string('-', 165);
    private List<Transaction> transactions { get; set; }

    public void MyStatement()
    {
        SelectAccount();
        DisplayMenu();
    }

    private void setTransactions()
    {
        transactions = MenuService.GetTransactionHistory(_account);
    }

    private void DisplayMenu(int index = 0)
    {
        DisplayStatement(index);
        StatementMenuSwitch(index);
    }

    private void DisplayStatement(int index)
    {
        setTransactions();
        Console.Clear();
        Console.WriteLine($"Account balance: {_account.Balance:C}");
        Console.WriteLine(row);
        Console.WriteLine(headerFormat, "TransactionID", "TransactionType", "AccountNumber", "DestinationAccountNumber",
            "Amount", "TransactionTimeUtc", "Comment");
        Console.WriteLine(row);
        for (int i = index; i < index + step && i < transactions.Count; i++)
        {
            DisplayTransaction(transactions[i]);
        }

        Console.WriteLine("[←] previous page [→] next page [B] Back to Menu");
    }

    private void StatementMenuSwitch(int index)
    {
        ConsoleKey consoleKey;
        do
        {
            consoleKey = Console.ReadKey(intercept: true).Key;
            switch (consoleKey)
            {
                case ConsoleKey.LeftArrow:
                    if (index >= step)
                    {
                        index -= step;
                        DisplayStatement(index);
                    }

                    break;
                case ConsoleKey.RightArrow:
                    if (index + step < transactions.Count)
                    {
                        index += step;
                        DisplayStatement(index);
                    }

                    break;
            }
        } while (consoleKey != ConsoleKey.B);
    }

    private void DisplayTransaction(Transaction transaction)
    {
        string destinationAccountNumber = "-";
        if (transaction.DestinationAccountNumber != null)
            destinationAccountNumber = transaction.DestinationAccountNumber.ToString();

        Console.WriteLine(transactionFormat, transaction.TransactionID, transaction.TransactionType,
            transaction.AccountNumber,
            destinationAccountNumber,
            transaction.Amount, transaction.TransactionTimeUtc, transaction.Comment);
        Console.WriteLine(row);
    }
}