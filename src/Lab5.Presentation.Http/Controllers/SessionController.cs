using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Sessions.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Http.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Http.Controllers;

[ApiController]
[Route("api/session")]
public sealed class SessionController : ControllerBase
{
    private readonly ISessionService _service;

    public SessionController(ISessionService service)
    {
        _service = service;
    }

    [HttpPost("create-user")]
    public ActionResult<long> CreateUserSession([FromBody] CreateUserSessionRequest httpRequest)
    {
        var request = new CreateUserSession.Request(httpRequest.AccountId, httpRequest.PinCode);
        CreateUserSession.Response response = _service.CreateUserSession(request);

        return response switch
        {
            CreateUserSession.Response.Success success => Ok(success.Key),
            CreateUserSession.Response.Failure failure => Unauthorized(),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("create-admin")]
    public ActionResult<long> CreateAdminSession([FromQuery] Guid systemPassword)
    {
        var request = new CreateAdminSession.Request(systemPassword);
        CreateAdminSession.Response response = _service.CreateAdminSession(request);

        return response switch
        {
            CreateAdminSession.Response.Success success => Ok(success.Key),
            CreateAdminSession.Response.Failure failure => Unauthorized(),
            _ => throw new UnreachableException(),
        };
    }
}