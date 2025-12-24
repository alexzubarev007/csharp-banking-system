using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Repositories;

public sealed class UserSessionRepository : IUserSessionRepository
{
    private readonly Dictionary<Guid, UserSession> _values = [];

    public UserSession Add(UserSession userSession)
    {
        _values.Add(userSession.Key, userSession);

        return userSession;
    }

    public IEnumerable<UserSession> Query(SessionQuery query)
    {
        return _values.Values.Where(x => query.Keys.Contains(x.Key) ||
                                         query.Keys is []);
    }
}