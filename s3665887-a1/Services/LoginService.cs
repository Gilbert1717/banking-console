using s3665887_a1.Models;
using s3665887_a1.Repositories;
using SimpleHashing.Net;

namespace s3665887_a1.Services;

public class LoginService
{
    private readonly ILoginRepository _loginRepository;
    private readonly ICustomerRepository _customerSqlRepository;

    public LoginService(ILoginRepository loginRepository, ICustomerRepository customerSqlRepository)
    {
        _loginRepository = loginRepository;
        _customerSqlRepository = customerSqlRepository;
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
            return _customerSqlRepository.GetById(login.CustomerID);
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