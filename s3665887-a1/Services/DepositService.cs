using s3665887_a1.Models;
using s3665887_a1.Repositories;
using s3665887_a1.Repositories.SqlRepositories;

namespace s3665887_a1.Services;


public class DepositService
{
    private readonly ITransactionRepository _transactionRepository;

    public DepositService(ITransactionRepository transactionRepository)
    {
        _transactionRepository = transactionRepository;
    }
    public Transaction? DepositAmountValidation(string amount, Account _account)
    {
        if (decimal.TryParse(amount, out decimal validAmount))
        {
            return new Transaction
            {
                TransactionType = TransactionType.D,
                AccountNumber = _account.AccountNumber,
                Amount = validAmount,
                TransactionTimeUtc = DateTime.Now
            };
        }
        else
        {
            Console.WriteLine("Invalid Input");
            return null;
        }
    }

    public void SaveTransaction(Transaction transaction)
    {
        _transactionRepository.Save(transaction);
    }
    
}