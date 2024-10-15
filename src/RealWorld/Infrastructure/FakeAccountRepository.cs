using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class FakeAccountRepository : FakeEntityRepository<Account>, IAccountRepository
{
    public FakeAccountRepository(IEnumerable<Account> entities) : base(entities)
    {
    }

    public Account Get(string number)
    {
        return _entities.Values.SingleOrDefault(e => e.Number == number)!;
    }
}
