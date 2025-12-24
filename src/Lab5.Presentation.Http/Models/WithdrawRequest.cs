using System.ComponentModel.DataAnnotations;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Http.Models;

public sealed class WithdrawRequest
{
    [Range(minimum: 1, maximum: long.MaxValue)]
    public long Money { get; set; }

    public Guid SessionKey { get; set; }
}