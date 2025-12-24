namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Accounts;

public readonly record struct AccountId(long Value)
{
    public static readonly AccountId Default = new(default);
}