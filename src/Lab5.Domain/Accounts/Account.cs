using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts.Results;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;

public sealed class Account
{
    public Account(Money money, AccountId accountId, long pinCode)
    {
        Balance = money;
        Id = accountId;
        PinCode = pinCode;
    }

    public Money Balance { get; private set; }

    public AccountId Id { get; }

    public long PinCode { get; }

    public WithdrawResult Withdraw(Money money)
    {
        if (Balance < money)
        {
            return new WithdrawResult.Failure();
        }

        Balance -= money;

        return new WithdrawResult.Success();
    }

    public void PutMoney(Money money)
    {
        Balance += money;
    }
}