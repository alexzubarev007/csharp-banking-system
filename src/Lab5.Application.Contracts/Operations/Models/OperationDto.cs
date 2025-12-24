namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Operations.Models;

public sealed record OperationDto(DateTime Time, decimal Balance, string OperationType);