using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;

namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

public sealed class UserSession
{
    public UserSession(Guid sessionKey, AccountId accountId)
    {
        Key = sessionKey;
        AccountId = accountId;
    }

    public Guid Key { get; }

    public AccountId AccountId { get; }
}