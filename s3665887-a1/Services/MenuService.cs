using s3665887_a1.Models;
using s3665887_a1.Repositories;

namespace s3665887_a1.Services;

public class MenuService
{
    private readonly decimal atmWithdraw = -0.05m;
    private readonly decimal accountTransfer = -0.1m;

    private readonly ICustomerRepository _customerRepository;
    private readonly ILoginRepository _loginRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly LoginService _loginService;

    public MenuService(
        ICustomerRepository customerRepository,
        ILoginRepository loginRepository,
        IAccountRepository accountRepository,
        ITransactionRepository transactionRepository)
    {
        _customerRepository = customerRepository;
        _loginRepository = loginRepository;
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;

        _loginService = new LoginService(_loginRepository);
    }

    public List<Account> GetAccountList(Customer customer)
    {
        return _accountRepository.GetById(customer.CustomerID);
    }

    public Account GetByAccountNumber(int destinationAccountNumber)
    {
        return _accountRepository.GetByAccountNumber(destinationAccountNumber);
    }

    public List<Transaction> GetTransactionHistory(Account account)
    {
        return _transactionRepository.GetById(account.AccountNumber);
    }

    public Customer LoginCustomer(string userName, string userPassword)
    {
        return _loginService.AuthPassword(userName, userPassword);
    }

    public decimal? DepositAmountValidation(string amount)
    {
        if (decimal.TryParse(amount, out decimal validAmount)
            && decimal.Round(validAmount, 2) == validAmount
            && validAmount > 0)
            return validAmount;

        Console.WriteLine("Invalid Input");
        return null;
    }

    public decimal? WithdrawAmountValidation(string amount, Account account)
    {
        if (decimal.TryParse(amount, out decimal validAmount)
            && decimal.Round(validAmount, 2) == validAmount
            && validAmount > 0)
        {
            if ((account.AccountType == AccountType.S && account.Balance - validAmount < 0) ||
                (account.AccountType == AccountType.C && account.Balance - validAmount < 300))
            {
                Console.WriteLine("Insufficient balance");
                Console.WriteLine("Direct to main menu");
                return null;
            }

            return validAmount;
        }

        Console.WriteLine("Invalid Input");
        return null;
    }

    public void WithdrawMoney(string comment, decimal amount, Account account)
    {
        HandleTransaction(CreateTransaction(TransactionType.W, comment, amount * -1, account), account);
        if (TransactionFeeValidation(_transactionRepository.GetById(account.AccountNumber)))
        {
            HandleTransaction(
                CreateTransaction(TransactionType.S, "Atm Withdraw charge", atmWithdraw, account),
                account
            );
        }

        Console.WriteLine($"Successfully withdraw {amount:C} from your account");
        Console.WriteLine(new string('-', 80));
        Console.WriteLine();
    }


    public void DepositMoney(string comment, decimal amount, Account account)
    {
        HandleTransaction(CreateTransaction(TransactionType.D, comment, amount, account), account);
        Console.WriteLine($"Successfully deposit {amount:C} to your account");
        Console.WriteLine(new string('-', 80));
        Console.WriteLine();
    }


    public void TransferMoney(string comment, decimal amount, Account account, Account destinationAccount)
    {
        HandleTransaction(
            CreateTransaction(TransactionType.T, comment, amount * -1, account, destinationAccount),
            account
        );
        if (TransactionFeeValidation(_transactionRepository.GetById(account.AccountNumber)))
        {
            HandleTransaction(
                CreateTransaction(TransactionType.S, "Transfer charge", accountTransfer, account),
                account
            );
        }

        HandleTransaction(
            CreateTransaction(TransactionType.T, comment, amount, destinationAccount),
            destinationAccount
        );
        Console.WriteLine($"Successfully transfer {amount:C} to account {destinationAccount.AccountNumber}");
        Console.WriteLine(new string('-', 80));
        Console.WriteLine();
    }

    private void SaveTransaction(Transaction transaction)
    {
        _transactionRepository.Save(transaction);
    }


    private void UpdateAccount(Account account)
    {
        _accountRepository.Update(account);
    }

    private Transaction CreateTransaction(TransactionType transactionType, string comment, decimal amount,
        Account account, Account destinationAccount = null)
    {
        return new Transaction
        {
            TransactionType = transactionType,
            AccountNumber = account.AccountNumber,
            Comment = comment,
            Amount = amount,
            DestinationAccountNumber = destinationAccount?.AccountNumber,
            TransactionTimeUtc = DateTime.Now.ToUniversalTime()
        };
    }

    private bool TransactionFeeValidation(List<Transaction> transactions)
    {
        int count = 0;
        foreach (var transaction in transactions)
        {
            if (transaction.TransactionType == TransactionType.W
                || (transaction.TransactionType == TransactionType.T
                    && transaction.DestinationAccountNumber != null))
            {
                count++;
                if (count > 2)
                    return true;
            }
        }

        return false;
    }

    private void HandleTransaction(Transaction transaction, Account account)
    {
        SaveTransaction(transaction);
        account.updateBalance(account.Balance + transaction.Amount);
        UpdateAccount(account);
    }
}