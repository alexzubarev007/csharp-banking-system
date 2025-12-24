namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts.Results;

public record WithdrawResult
{
    private WithdrawResult() { }

    public sealed record Success : WithdrawResult;

    public sealed record Failure : WithdrawResult;
}