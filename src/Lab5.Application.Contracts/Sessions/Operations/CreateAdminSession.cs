namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions.Operations;

public static class CreateAdminSession
{
    public readonly record struct Request(Guid Password);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(Guid Key) : Response;

        public sealed record Failure(string Message) : Response;
    }
}