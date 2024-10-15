using Domain.Abstractions;
using Domain.Models;

namespace Infrastructure;

public class FakeAccountRepository : IAccountRepository
{
    private IDictionary<int, Account> _accounts;

    public FakeAccountRepository()
    {
        var accounts = new List<Account>
            {
                new Account { Id = 1, Number = "11110000", Balance = 100},
                new Account { Id = 2, Number = "22220000", Balance = 100 },
                new Account { Id = 3, Number = "33330000", Balance = 100, Status = AccountStatus.Closed },
                new Account { Id = 4, Number = "44440000", Balance = 100 },
                new Account { Id = 5, Number = "66660000", Balance = 100, Status = AccountStatus.Locked },
            };

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
