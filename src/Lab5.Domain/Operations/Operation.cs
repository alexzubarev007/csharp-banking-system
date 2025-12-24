using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Operations;

public sealed class Operation
{
    public Operation(
        OperationType type,
        DateTime time,
        AccountId accountId,
        Money accountBalance)
    {
        Time = time;
        Type = type;
        AccountId = accountId;
        AccountBalance = accountBalance;
    }

    public DateTime Time { get; }

    public OperationType Type { get; }

    public Money AccountBalance { get; }

    public AccountId AccountId { get; }
}