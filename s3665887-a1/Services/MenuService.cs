using s3665887_a1.Models;
using s3665887_a1.Repositories;

namespace s3665887_a1.Services;

public class MenuService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ILoginRepository _loginRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;

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
    }

    public List<Account> getAccountList(Customer customer)
    {
        return _accountRepository.GetById(customer.CustomerID);
    }
    
    public List<Transaction> GetTransactionHistory(Account account)
    {
        return _transactionRepository.GetById(account.AccountNumber);
    }

    public Customer? LoginCustomer(string userName, string userPassword)
    { 
        LoginService loginService = new LoginService(_loginRepository); 
        return loginService.AuthPassword(userName,userPassword);
    }
        
}