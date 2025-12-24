using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Operations.Models;
using Itmo.ObjectOrientedProgramming.Lab5.Domain.Operations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Mapping;

public static class OperationMappingExtensions
{
    public static OperationDto MapToDto(this Operation operation)
        => new OperationDto(operation.Time, operation.AccountBalance.Value, operation.Type.ToString());

    public static IEnumerable<OperationDto> MapToDto(this IEnumerable<Operation> operations)
    {
        return operations.Select(operation => operation.MapToDto());
    }
}