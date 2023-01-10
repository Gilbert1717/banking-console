using s3665887_a1.Models;

namespace s3665887_a1.Repositories;

public interface IAccountRepository
{
    void InsertToDB(DTOs.AccountDTO account);
    void Update(Account account);

    Account GetAccountByAccountNumber(int accountNumber);

    List<Account> GetAccountsByCustomerID(int customerId);
}