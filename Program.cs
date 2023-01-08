using s3665887_a1.Repositories;

namespace s3665887_a1;

class Program
{
    public static void Main()
    {
        // Menu.useMenu();
        // const string Url = "https://coreteaching01.csit.rmit.edu.au/~e103884/wdt/services/customers/";
        //
        // using var client = new HttpClient();
        // var json = client.GetStringAsync(Url).Result;
        //
        // var customers = JsonConvert.DeserializeObject<List<Customer>>(json, new JsonSerializerSettings
        // {
        //     DateFormatString = "DD/MM/YYYY hh:mm:ss tt"
        //
        // });
        // foreach (Customer customer in customers)
        // {
        //
        //     CustomerRepository customerRepository = new CustomerRepository();
        //     customerRepository.SaveCustomer(customer);
        // }
        CustomerRepository customerRepository = new CustomerRepository();
        var customer = customerRepository.GetCustomerById(2200);
        Console.WriteLine(customer.Name);
    }
}