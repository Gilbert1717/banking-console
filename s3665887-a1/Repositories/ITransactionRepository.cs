using s3665887_a1.Models;

namespace s3665887_a1.Repositories;

public interface ITransactionRepository
{
    void Save(Transaction transaction);
}