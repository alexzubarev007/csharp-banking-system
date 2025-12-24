using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Repositories;

public interface IAccountRepository
{
    Account Add(Account account);

    IEnumerable<Account> Query(AccountQuery query);

    void Update(Account account);
}