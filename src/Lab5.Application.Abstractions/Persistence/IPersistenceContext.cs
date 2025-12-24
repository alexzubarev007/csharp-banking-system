using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Repositories;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence;

public interface IPersistenceContext
{
    IAccountRepository Accounts { get; }

    IUserSessionRepository UserSessions { get; }

    IAdminSessionRepository AdminSessions { get; }

    IOperationRepository Operations { get; }
}