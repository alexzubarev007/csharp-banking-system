using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Operations.Models;

namespace Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Operations.Operations;

public static class GetHistory
{
    public readonly record struct Request(Guid SessionKey);

    public abstract record Response
    {
        private Response() { }

        public sealed record Success(IEnumerable<OperationDto> Operations) : Response;

        public sealed record Failure(string Message) : Response;
    }
}