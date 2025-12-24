using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Repositories;

public interface IOperationRepository
{
    Operation Add(Operation operation);

    IEnumerable<List<Operation>> Query(OperationQuery query);
}