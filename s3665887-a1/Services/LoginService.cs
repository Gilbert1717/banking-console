using s3665887_a1.Models;
using s3665887_a1.Repositories;
using SimpleHashing.Net; 
namespace s3665887_a1.Services;

public class LoginService
{
    public Customer? authPassword(string loginID, string password)
    {
        LoginRepository loginRepository = new LoginRepository();
        Login login = loginRepository.GetById(loginID);
        if (login == null)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nLogin Failed\n");
            return null;
        }
        
        if (new SimpleHash().Verify(password, login.PasswordHash))
        {
            CustomerRepository customerRepository = new CustomerRepository();
            return customerRepository.GetById(login.CustomerID);
        }
        
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nLogin Failed\n");
        return null;
    }
}
    
    
   
 
