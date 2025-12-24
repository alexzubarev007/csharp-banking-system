using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure;

public class PersistenceContext : IPersistenceContext
{
    public PersistenceContext(
        IAccountRepository accounts,
        IOperationRepository operations,
        IUserSessionRepository userSessions,
        IAdminSessionRepository adminSessions)
    {
        Accounts = accounts;
        Operations = operations;
        UserSessions = userSessions;
        AdminSessions = adminSessions;
    }

    public IAccountRepository Accounts { get; }

    public IUserSessionRepository UserSessions { get; }

    public IOperationRepository Operations { get; }

    public IAdminSessionRepository AdminSessions { get; }
}