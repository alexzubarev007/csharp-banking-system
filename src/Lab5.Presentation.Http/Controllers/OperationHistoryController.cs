using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Operations.Models;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Operations.Operations;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Http.Controllers;

[ApiController]
[Route("api/operation")]
public sealed class OperationHistoryController : ControllerBase
{
    private readonly IOperationService _service;

    public OperationHistoryController(IOperationService service)
    {
        _service = service;
    }

    [HttpGet("get-history")]
    public ActionResult<IEnumerable<OperationDto>> GetHistory([FromQuery] Guid sessionKey)
    {
        var request = new GetHistory.Request(sessionKey);
        GetHistory.Response response = _service.GetHistory(request);

        return response switch
        {
            GetHistory.Response.Success success => Ok(success.Operations),
            GetHistory.Response.Failure failure => Unauthorized(),
            _ => throw new UnreachableException(),
        };
    }
}