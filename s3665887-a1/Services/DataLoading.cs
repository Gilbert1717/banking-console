using s3665887_a1.Models;
using s3665887_a1.Repositories;

namespace s3665887_a1.Services;

public class DataLoading
{
    private static Login loginCovert(DTOs.CustomerDTO customer, DTOs.LoginDTO login)
    {
        return new Login(login.LoginID, customer.CustomerID, login.PasswordHash);
    }
    private static Transaction transactionCovert(DTOs.AccountDTO account,
        DTOs.TransactionDTO transaction)
    {
        return new Transaction(TransactionType.D, account.AccountNumber, transaction.Amount, 
            null, transaction.Comment, transaction.TransactionTimeUtc);
    }
    
    public static void preloading()
    {
        JSONConvert jsonConvert = new JSONConvert();
        List<DTOs.CustomerDTO> customers = jsonConvert.covertJSON();
        CustomerRepository customerRepository = new CustomerRepository();
        AccountRepository accountRepository = new AccountRepository();
        TransactionRepository transactionRepository = new TransactionRepository();
        
        foreach (var customer in customers)
        {
            customerRepository.Save(customer);
            foreach (var account in customer.Accounts)
            {
                account.CustomerID = customer.CustomerID;
                accountRepository.Save(account);
                foreach (var transaction in account.Transactions)
                {
                    Transaction transactionB = transactionCovert(account, transaction);
                    transactionRepository.Save(transactionB);
                }
            }
        }
    }
}