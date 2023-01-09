using Newtonsoft.Json;
using s3665887_a1.Repositories;

namespace s3665887_a1.Models;

public class JSONConvert
{
    const string Url = "https://coreteaching01.csit.rmit.edu.au/~e103884/wdt/services/customers/";
    
    public List<DTOs.CustomerDTO> covertJSON()
    {
        using var client = new HttpClient();
        var json = client.GetStringAsync(Url).Result;

        var customers = JsonConvert.DeserializeObject<List<DTOs.CustomerDTO>>(json, new JsonSerializerSettings
        {
            DateFormatString = "DD/MM/YYYY hh:mm:ss tt"
        });

        CustomerRepository customerRepository = new CustomerRepository();
        return customers;
        
    }
    
}