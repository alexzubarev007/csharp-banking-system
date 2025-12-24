using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts;

public interface IAccountService
{
    Create.Response CreateAccount(Create.Request request);

    GetBalance.Response GetBalance(GetBalance.Request request);

    PutMoney.Response PutMoney(PutMoney.Request request);

    Withdraw.Response Withdraw(Withdraw.Request request);
}