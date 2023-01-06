using Newtonsoft.Json;
using s3665887_a1.DTOs;

namespace s3665887_a1;

class Program
{
    public static void Main()
    {
        // Menu.useMenu();
        const string Url = "https://coreteaching01.csit.rmit.edu.au/~e103884/wdt/services/customers/";

        using var client = new HttpClient();
        var json = client.GetStringAsync(Url).Result;

        var customers = JsonConvert.DeserializeObject<List<Customer>>(json, new JsonSerializerSettings
        {
            DateFormatString = "DD/MM/YYYY hh:mm:ss tt"

        });
        foreach (Customer customer in customers)
        {
            foreach (Account account in customer.Accounts)
            {
                Console.WriteLine(account.Transactions[0].TransactionTimeUtc.ToString("dd/MM/yyyy hh:mm:ss tt"));
            }

            
            
        }
        Console.WriteLine(customers.Count);
    }
}