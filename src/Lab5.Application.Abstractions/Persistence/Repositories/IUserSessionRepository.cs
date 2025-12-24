using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Repositories;

public interface IUserSessionRepository
{
    UserSession Add(UserSession userSession);

    IEnumerable<UserSession> Query(SessionQuery query);
}