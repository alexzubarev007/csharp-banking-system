namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Operations;

public static class Withdraw
{
    public readonly record struct Request(Guid SessionKey, decimal Money);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(decimal Balance) : Response;

        public sealed record IncorrectAuthorization(string Message) : Response;

        public sealed record NotEnoughMoney(string Message) : Response;
    }
}