using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Http.Models;

public sealed class CreateAccountRequest
{
    [Range(minimum: 1, maximum: long.MaxValue)]
    public long PinCode { get; set; }

    public Guid SessionKey { get; set; }
}