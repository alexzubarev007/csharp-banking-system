using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Operations.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Operations;

public interface IOperationService
{
    GetHistory.Response GetHistory(GetHistory.Request request);
}