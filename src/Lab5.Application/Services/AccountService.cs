using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts.Results;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Services;

public sealed class AccountService : IAccountService
{
    private readonly IPersistenceContext _context;

    public AccountService(IPersistenceContext context)
    {
        _context = context;
    }

    public Create.Response CreateAccount(Create.Request request)
    {
        AdminSession? adminSession = _context.AdminSessions
            .Query(SessionQuery.Build(builder => builder.WithKey(request.SessionKey)))
            .SingleOrDefault();

        if (adminSession is null)
        {
            return new Create.Response.Failure();
        }

        var account = new Account(
            new Money(0),
            AccountId.Default,
            request.PinCode);

        account = _context.Accounts.Add(account);

        var createOperation = new Operation(
            OperationType.Create,
            DateTime.UtcNow,
            account.Id,
            account.Balance);

        _context.Operations.Add(createOperation);

        return new Create.Response.Success(account.Id.Value);
    }

    public GetBalance.Response GetBalance(GetBalance.Request request)
    {
        UserSession? userSession = _context.UserSessions
            .Query(SessionQuery.Build(builder => builder.WithKey(request.SessionKey)))
            .SingleOrDefault();

        if (userSession is null)
        {
            return new GetBalance.Response.Failure("incorrect session key");
        }

        Account? account = _context.Accounts
            .Query(AccountQuery.Build(builder => builder.WithId(userSession.AccountId)))
            .SingleOrDefault();

        if (account is null)
        {
            return new GetBalance.Response.Failure("cannot find account");
        }

        var getBalanceOperation = new Operation(
            OperationType.GetBalance,
            DateTime.UtcNow,
            account.Id,
            account.Balance);

        _context.Operations.Add(getBalanceOperation);

        return new GetBalance.Response.Success(account.Balance.Value);
    }

    public Withdraw.Response Withdraw(Withdraw.Request request)
    {
        UserSession? userSession = _context.UserSessions
            .Query(SessionQuery.Build(builder => builder.WithKey(request.SessionKey)))
            .SingleOrDefault();

        if (userSession is null)
        {
            return new Withdraw.Response.IncorrectAuthorization("incorrect session key");
        }

        Account? account = _context.Accounts
            .Query(AccountQuery.Build(builder => builder.WithId(userSession.AccountId)))
            .SingleOrDefault();

        if (account is null)
        {
            return new Withdraw.Response.IncorrectAuthorization("cannot find account");
        }

        WithdrawResult result = account.Withdraw(new Money(request.Money));

        if (result is WithdrawResult.Failure)
        {
            return new Withdraw.Response.NotEnoughMoney("cannot withdraw this amount");
        }

        var withdrawOperation = new Operation(
            OperationType.Withdraw,
            DateTime.UtcNow,
            account.Id,
            account.Balance);

        _context.Operations.Add(withdrawOperation);

        return new Withdraw.Response.Success(account.Balance.Value);
    }

    public PutMoney.Response PutMoney(PutMoney.Request request)
    {
        UserSession? userSession = _context.UserSessions
            .Query(SessionQuery.Build(builder => builder.WithKey(request.SessionKey)))
            .SingleOrDefault();

        if (userSession is null)
        {
            return new PutMoney.Response.Failure("incorrect session key");
        }

        Account? account = _context.Accounts
            .Query(AccountQuery.Build(builder => builder.WithId(userSession.AccountId)))
            .SingleOrDefault();

        if (account is null)
        {
            return new PutMoney.Response.Failure("cannot find account");
        }

        account.PutMoney(new Money(request.Money));

        var putMoneyOperation = new Operation(
            OperationType.PutMoney,
            DateTime.UtcNow,
            account.Id,
            account.Balance);

        _context.Operations.Add(putMoneyOperation);

        return new PutMoney.Response.Success(account.Balance.Value);
    }
}