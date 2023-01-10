using s3665887_a1.Models;
using s3665887_a1.Repositories;

namespace s3665887_a1.Services;

public class MenuService
{
    public List<Account> getAccountList(Customer customer)
    {
        AccountRepository accountRepository = new AccountRepository();
        return accountRepository.GetById(customer.CustomerID);
    }
    
    public List<Transaction> GetTransactionHistory(Account account)
    {
        TransactionRepository transactionRepository = new TransactionRepository();
        return transactionRepository.GetById(account.AccountNumber);
    }

    public Customer? LoginCustomer(string userName, string userPassword)
    { 
        LoginService loginService = new LoginService(); 
        return loginService.AuthPassword(userName,userPassword);
    }
        
}