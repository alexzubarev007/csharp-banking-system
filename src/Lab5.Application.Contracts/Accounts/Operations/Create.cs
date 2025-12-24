namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Operations;

public static class Create
{
    public readonly record struct Request(Guid SessionKey, long PinCode);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(long AccountId) : Response;

        public sealed record Failure() : Response;
    }
}