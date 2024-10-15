using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class FakeAccountRepository : IAccountRepository
{
    private IDictionary<int, Account> _accounts;

    public FakeAccountRepository(IEnumerable<Account> accounts)
    {
        _accounts = accounts.ToDictionary(p => p.Id);
    }
    public void Add(Account account)
    {
        var id = _accounts.Max(p=>p.Key);

        account.Id = ++id;

        _accounts.Add(account.Id, account);
    }

    public Account Get(int id)
    {
        return _accounts[id];
    }

    public IEnumerable<Account> GetAll()
    {
        return _accounts.Values;
    }
}
