using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Operations.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Mapping;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Services;

public sealed class OperationHistoryService : IOperationService
{
    private readonly IPersistenceContext _context;

    public OperationHistoryService(IPersistenceContext context)
    {
        _context = context;
    }

    public GetHistory.Response GetHistory(GetHistory.Request request)
    {
        UserSession? userSession = _context.UserSessions
            .Query(SessionQuery.Build(builder => builder.WithKey(request.SessionKey)))
            .SingleOrDefault();

        if (userSession is null)
        {
            return new GetHistory.Response.Failure("incorrect session key");
        }

        Account? account = _context.Accounts
            .Query(AccountQuery.Build(builder => builder.WithId(userSession.AccountId)))
            .SingleOrDefault();

        if (account is null)
        {
            return new GetHistory.Response.Failure("cannot find account");
        }

        IEnumerable<Operation>? operations = _context.Operations
            .Query(OperationQuery.Build(builder => builder.WithId(account.Id)))
            .SingleOrDefault();

        if (operations is null)
        {
            return new GetHistory.Response.Failure("found account, but no operations");
        }

        return new GetHistory.Response.Success(operations.MapToDto());
    }
}