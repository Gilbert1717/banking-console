using Newtonsoft.Json;
using s3665887_a1.DTOs;
using s3665887_a1.Repositories;

namespace s3665887_a1;

public static class Program
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

        CustomerRepository customerRepository = new CustomerRepository();
        foreach (Customer customer in customers)
        {
            // customerRepository.SaveCustomer(customer);
            customerRepository.Update(customer);
        }

        var someCustomer = customerRepository.GetById(2300);
        Console.WriteLine($"Address: {someCustomer.Address}");
    }
}