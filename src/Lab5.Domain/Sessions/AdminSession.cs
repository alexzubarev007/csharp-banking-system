namespace Itmo.ObjectOrientedProgramming.Lab5.Domain.Sessions;

public sealed class AdminSession
{
    public AdminSession(Guid sessionKey)
    {
        Key = sessionKey;
    }

    public Guid Key { get; }
}