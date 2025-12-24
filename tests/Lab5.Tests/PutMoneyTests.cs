using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Services;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.ValueObjects;
using NSubstitute;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab5.Tests;

public class PutMoneyTests
{
    [Fact]
    public void PutMoneyOperation_ImplementsSuccessfully()
    {
        // arrange
        IAccountRepository accountRepository = Substitute.For<IAccountRepository>();
        IUserSessionRepository userSessionRepository = Substitute.For<IUserSessionRepository>();
        IAdminSessionRepository adminSessionRepository = Substitute.For<IAdminSessionRepository>();
        IOperationRepository operationRepository = Substitute.For<IOperationRepository>();
        IPersistenceContext persistenceContext = Substitute.For<IPersistenceContext>();

        persistenceContext.Accounts.Returns(accountRepository);
        persistenceContext.UserSessions.Returns(userSessionRepository);
        persistenceContext.AdminSessions.Returns(adminSessionRepository);
        persistenceContext.Operations.Returns(operationRepository);

        var account = new Account(new Money(100000), new AccountId(2000), 1234);
        var userSession = new UserSession(Guid.NewGuid(), account.Id);

        accountRepository.Query(Arg.Any<AccountQuery>()).Returns(new[] { account });
        userSessionRepository.Query(Arg.Any<SessionQuery>()).Returns(new[] { userSession });

        var accountService = new AccountService(persistenceContext);

        var putMoneyRequest = new PutMoney.Request(userSession.Key, 20000);
        var balanceRequest = new GetBalance.Request(userSession.Key);

        // act
        PutMoney.Response result = accountService.PutMoney(putMoneyRequest);
        GetBalance.Response getBalanceResult = accountService.GetBalance(balanceRequest);

        // assert
        Assert.IsType<PutMoney.Response.Success>(result);
        GetBalance.Response.Success success = Assert.IsType<GetBalance.Response.Success>(getBalanceResult);
        Assert.Equal(120000, success.Balance);
    }
}