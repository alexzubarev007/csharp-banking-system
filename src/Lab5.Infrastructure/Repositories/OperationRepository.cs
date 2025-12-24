using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Queries;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Abstractions.Persistence.Repositories;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Infrastructure.Repositories;

public sealed class OperationRepository : IOperationRepository
{
    private readonly Dictionary<AccountId, List<Operation>> _values = [];

    public Operation Add(Operation operation)
    {
        if (!_values.TryGetValue(operation.AccountId, out List<Operation>? operations))
        {
            operations = new List<Operation>();
            _values[operation.AccountId] = operations;
        }

        _values[operation.AccountId].Add(operation);

        return operation;
    }

    public IEnumerable<List<Operation>> Query(OperationQuery query)
    {
        return _values.Where(x => query.Ids.Contains(x.Key) ||
                                  query.Ids is [])
            .Select(x => x.Value);
    }
}