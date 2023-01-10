using s3665887_a1.Models;

namespace s3665887_a1.Repositories;

public interface ILoginRepository
{
    void InsertToDB(Login login);

    void Update(Login login);

    Login? GetById(string loginID);
}