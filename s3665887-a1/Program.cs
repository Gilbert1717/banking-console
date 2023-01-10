using s3665887_a1.Repositories.SqlRepositories;
using s3665887_a1.Services;

namespace s3665887_a1;

class Program
{
    static void Main()
    {
        DataLoading dataLoading = new DataLoading(
            new CustomerSqlRepository(),
            new LoginSqlRepository(),
            new AccountSqlRepository(),
            new TransactionSqlRepository()
        );
        dataLoading.Preloading();
        
        Menu.useMenu();
    }
}