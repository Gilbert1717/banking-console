using s3665887_a1.Models;

namespace s3665887_a1.Repositories;

public interface ICustomerRepository
{
    void InsertToDB(DTOs.CustomerDTO customer);

    void Update(Customer customer);

    //check if there is any existing customer in database
    bool Any();

    Customer GetById(int customerId);
}