using s3665887_a1.Models;
using s3665887_a1.Repositories;
using SimpleHashing.Net;

namespace s3665887_a1.Services;

public class LoginService
{
    public Customer? AuthPassword(string loginID, string password)
    {
        LoginRepository loginRepository = new LoginRepository();
        Login login = loginRepository.GetById(loginID);
        if (login == null)
        {
            LoginFailWarning();
            return null;
        }

        if (new SimpleHash().Verify(password, login.PasswordHash))
        {
            CustomerRepository customerRepository = new CustomerRepository();
            return customerRepository.GetById(login.CustomerID);
        }

        LoginFailWarning();
        return null;
    }

    private static void LoginFailWarning()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nLogin Failed\n");
        Console.ResetColor();
    }
}