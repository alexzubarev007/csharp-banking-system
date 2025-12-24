using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Repositories;

public sealed class AccountRepository : IAccountRepository
{
    private readonly Dictionary<AccountId, Account> _values = [];

    public Account Add(Account account)
    {
        account = new Account(
            account.Balance,
            new AccountId(_values.Count + 1),
            account.PinCode);

        _values.Add(account.Id, account);

        return account;
    }

    public IEnumerable<Account> Query(AccountQuery query)
    {
        return _values.Values.Where(x => query.Ids.Contains(x.Id) ||
                                         query.Ids is []);
    }

    public void Update(Account account)
    {
        if (!_values.ContainsKey(account.Id))
        {
            throw new InvalidOperationException("Account not found.");
        }

        _values[account.Id] = account;
    }
}