using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions.Options;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;
using Microsoft.Extensions.Options;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Services;

public sealed class SessionService : ISessionService
{
    private readonly IPersistenceContext _context;
    private readonly AdminSessionOptions _adminOptions;

    public SessionService(IPersistenceContext context, IOptions<AdminSessionOptions> adminOptions)
    {
        _context = context;
        _adminOptions = adminOptions.Value;
    }

    public CreateAdminSession.Response CreateAdminSession(CreateAdminSession.Request request)
    {
        if (request.Password != _adminOptions.SystemPassword)
        {
            return new CreateAdminSession.Response.Failure("incorrect system password");
        }

        var adminSession = new AdminSession(Guid.NewGuid());
        _context.AdminSessions.Add(adminSession);

        return new CreateAdminSession.Response.Success(adminSession.Key);
    }

    public CreateUserSession.Response CreateUserSession(CreateUserSession.Request request)
    {
        Account? account = _context.Accounts
            .Query(AccountQuery.Build(builder => builder.WithId(new AccountId(request.AccountId))))
            .SingleOrDefault();

        if (account is null)
        {
            return new CreateUserSession.Response.Failure("cannot find account");
        }

        if (request.PinCode != account.PinCode)
        {
            return new CreateUserSession.Response.Failure("incorrect pin code");
        }

        var userSession = new UserSession(Guid.NewGuid(), account.Id);
        _context.UserSessions.Add(userSession);

        return new CreateUserSession.Response.Success(userSession.Key);
    }
}