using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Http.Models;

public sealed class CreateUserSessionRequest
{
    [Range(minimum: 1, maximum: long.MaxValue)]
    public long PinCode { get; set; }

    [Range(minimum: 1, maximum: long.MaxValue)]
    public long AccountId { get; set; }
}