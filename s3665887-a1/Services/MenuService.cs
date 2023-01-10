using s3665887_a1.Models;
using s3665887_a1.Repositories;

namespace s3665887_a1.Services;

public class MenuService
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ILoginRepository _loginRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;
    private readonly DepositService _depositService;
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
        _depositService = new DepositService(_transactionRepository);
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
        return _loginService.AuthPassword(userName,userPassword);
    }

    public Transaction? DepositAmountValidation(string amount, Account _account)
    {
        return _depositService.DepositAmountValidation(amount, _account);
    }

    public void SaveTransaction(Transaction transaction)
    {
        _depositService.SaveTransaction(transaction);
    }
        
}