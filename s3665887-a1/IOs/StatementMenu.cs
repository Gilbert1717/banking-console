using Database;
using s3665887_a1.Models;

namespace s3665887_a1.IOs;

public class StatementMenu : Menu
{
    private int recordsPerPage = 4;
    const string titleFormat = "| {0,-16} | {1,-16} | {2,-16} | {3,-26} | {4,-10} | {5,-22} | {6,-20} ";
    const string transactionFormat = "| {0,-16} | {1,-16} | {2,-16} | {3,-26} | {4,-10:C} | {5,-22} | {6,-20} ";
    string row = new string('-', 165);
    private List<Transaction> transactions { get; set; }

    public StatementMenu(SqlConnection sqlConnection) : base(sqlConnection)
    {
    }

    public void MyStatement()
    {
        SelectAccount();
        DisplayMenu();
    }

    private void SetTransactions()
    {
        transactions = MenuService.GetTransactionHistory(_account);
    }

    private void DisplayMenu(int startIndex = 0)
    {
        DisplayStatement(startIndex);
        StatementMenuSwitch(startIndex);
    }

    private void DisplayHeader(int startIndex)
    {
        string headerFormat = "{0,-80} {1,80}";
        string balance = $"Account balance: {_account.Balance:C}";
        int currentPage = startIndex / recordsPerPage + 1;
        int totalPage = (transactions.Count + recordsPerPage - 1) / recordsPerPage;
        string pageInfo = $"Page {currentPage}/{totalPage}";

        Console.WriteLine(headerFormat, balance, pageInfo);
    }

    private void DisplayStatement(int startIndex)
    {
        SetTransactions();
        Console.Clear();
        DisplayHeader(startIndex);
        Console.WriteLine(row);
        Console.WriteLine(titleFormat, "TransactionID", "TransactionType", "AccountNumber", "DestinationAccountNumber",
            "Amount", "TransactionTime", "Comment");
        Console.WriteLine(row);
        for (int i = startIndex; i < startIndex + recordsPerPage && i < transactions.Count; i++)
        {
            DisplayTransaction(transactions[i]);
        }

        Console.WriteLine("[←] previous page [→] next page [B] Back to Menu");
    }

    private void StatementMenuSwitch(int startIndex)
    {
        ConsoleKey consoleKey;
        do
        {
            consoleKey = Console.ReadKey(intercept: true).Key;
            switch (consoleKey)
            {
                case ConsoleKey.LeftArrow:
                    if (startIndex >= recordsPerPage)
                    {
                        startIndex -= recordsPerPage;
                        DisplayStatement(startIndex);
                    }

                    break;
                case ConsoleKey.RightArrow:
                    if (startIndex + recordsPerPage < transactions.Count)
                    {
                        startIndex += recordsPerPage;
                        DisplayStatement(startIndex);
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
        DateTime transactionTime = transaction.TransactionTimeUtc.ToLocalTime();
        String transactionTimeString = transactionTime.ToString("dd/MM/yyyy hh:mm:ss tt");

        Console.WriteLine(transactionFormat, transaction.TransactionID, transaction.TransactionType,
            transaction.AccountNumber,
            destinationAccountNumber,
            transaction.Amount, transactionTimeString, transaction.Comment);
        Console.WriteLine(row);
    }
}