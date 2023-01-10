using Newtonsoft.Json;
using s3665887_a1.Models;

namespace s3665887_a1.Services;

public class JSONConvert
{
    const string Url = "https://coreteaching01.csit.rmit.edu.au/~e103884/wdt/services/customers/";

    public List<DTOs.CustomerDTO> covertJSON()
    {
        using var client = new HttpClient();
        var json = client.GetStringAsync(Url).Result;

        return JsonConvert.DeserializeObject<List<DTOs.CustomerDTO>>(json, new JsonSerializerSettings
        {
            DateFormatString = "DD/MM/YYYY hh:mm:ss tt"
        });
    }
}