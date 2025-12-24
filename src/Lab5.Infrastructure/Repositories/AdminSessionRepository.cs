using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Repositories;

public sealed class AdminSessionRepository : IAdminSessionRepository
{
    private readonly Dictionary<Guid, AdminSession> _values = [];

    public AdminSession Add(AdminSession adminSession)
    {
        _values.Add(adminSession.Key, adminSession);

        return adminSession;
    }

    public IEnumerable<AdminSession> Query(SessionQuery query)
    {
        return _values.Values.Where(x => query.Keys.Contains(x.Key) ||
                                         query.Keys is []);
    }
}