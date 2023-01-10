using s3665887_a1.Models;
using s3665887_a1.Repositories;
using s3665887_a1.Repositories.SqlRepositories;
using SimpleHashing.Net;

namespace s3665887_a1.Services;

public class LoginService
{
    private readonly ILoginRepository _loginRepository;

    public LoginService(ILoginRepository loginRepository)
    {
        _loginRepository = loginRepository;
    }

    public Customer? AuthPassword(string loginID, string password)
    {
        Login? login = _loginRepository.GetById(loginID);
        if (login == null)
        {
            LoginFailWarning();
            return null;
        }

        if (new SimpleHash().Verify(password, login.PasswordHash))
        {
            CustomerSqlRepository customerSqlRepository = new CustomerSqlRepository();
            return customerSqlRepository.GetById(login.CustomerID);
        }

        LoginFailWarning();
        return null;
    }

    private void LoginFailWarning()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nLogin Failed\n");
        Console.ResetColor();
    }
}