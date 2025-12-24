using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Repositories;

public interface IAdminSessionRepository
{
    AdminSession Add(AdminSession adminSession);

    IEnumerable<AdminSession> Query(SessionQuery query);
}