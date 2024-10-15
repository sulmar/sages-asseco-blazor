using Domain.Models;

namespace Domain.Abstractions;

public interface IAccountRepository
{
    IEnumerable<Account> GetAll();
    Account Get(int id);
    void Add(Account account);
}
