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
    public decimal? DepositAmountValidation(string amount)
    {
        if (decimal.TryParse(amount, out decimal validAmount) && decimal.Round(validAmount, 2) == validAmount)
            return validAmount;
        
        Console.WriteLine("Invalid Input");
        return null;
        
    }
    
   

    public void SaveTransaction(Transaction transaction)
    {
        _transactionRepository.Save(transaction);
    }
    
}