using Newtonsoft.Json;
using s3665887_a1.Models;
using s3665887_a1.Repositories;

namespace s3665887_a1.Services;

public class DataLoading
{
    private readonly ICustomerRepository _customerRepository;
    private readonly ILoginRepository _loginRepository;
    private readonly IAccountRepository _accountRepository;
    private readonly ITransactionRepository _transactionRepository;

    public DataLoading(
        ICustomerRepository customerRepository,
        ILoginRepository loginRepository,
        IAccountRepository accountRepository,
        ITransactionRepository transactionRepository
    )
    {
        _customerRepository = customerRepository;
        _loginRepository = loginRepository;
        _accountRepository = accountRepository;
        _transactionRepository = transactionRepository;
    }

    public async Task Preloading()
    {
        if (_customerRepository.Any())
        {
            return;
        }

        //Create instances which will be used for loading data
        List<DTOs.CustomerDTO> customers = LoadDataFromServer();


        //nested for loop to convert DTO to Business Obj and load them to database.
        foreach (var customer in customers)
        {
            _customerRepository.InsertToDB(customer);
            Login login = LoginCovert(customer, customer.Login);
            _loginRepository.InsertToDB(login);
            foreach (var account in customer.Accounts)
            {
                _accountRepository.InsertToDB(account);
                foreach (var transaction in account.Transactions)
                {
                    Transaction transactionB = TransactionCovert(account, transaction);
                    _transactionRepository.Save(transactionB);
                }
            }
        }
    }
    
    private List<DTOs.CustomerDTO> LoadDataFromServer()
    {
        const string Url = "https://coreteaching01.csit.rmit.edu.au/~e103884/wdt/services/customers/";
        using var client = new HttpClient();
        var json = client.GetStringAsync(Url).Result;

        return JsonConvert.DeserializeObject<List<DTOs.CustomerDTO>>(json, new JsonSerializerSettings
        {
            DateFormatString = "DD/MM/YYYY hh:mm:ss tt"
        });
    }

    private static Login LoginCovert(DTOs.CustomerDTO customer, DTOs.LoginDTO login)
    {
        return new Login(login.LoginID, customer.CustomerID, login.PasswordHash);
    }

    private static Transaction TransactionCovert(DTOs.AccountDTO account,
        DTOs.TransactionDTO transaction)
    {
        return new Transaction(TransactionType.D, account.AccountNumber, transaction.Amount,
            null, transaction.Comment, transaction.TransactionTimeUtc);
    }
}