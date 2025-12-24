using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts;
using Itmo.ObjectOrientedProgramming.Lab5.Application.Contracts.Accounts.Operations;
using Itmo.ObjectOrientedProgramming.Lab5.Presentation.Http.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Itmo.ObjectOrientedProgramming.Lab5.Presentation.Http.Controllers;

[ApiController]
[Route("api/account")]
public sealed class AccountController : ControllerBase
{
    private readonly IAccountService _service;

    public AccountController(IAccountService service)
    {
        _service = service;
    }

    [HttpPost("create")]
    public ActionResult<long> CreateAccount([FromBody] CreateAccountRequest httpRequest)
    {
        var request = new Create.Request(httpRequest.SessionKey, httpRequest.PinCode);
        Create.Response response = _service.CreateAccount(request);

        return response switch
        {
            Create.Response.Success success => success.AccountId,
            Create.Response.Failure => Unauthorized(),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("withdraw")]
    public ActionResult<decimal> Withdraw([FromBody] WithdrawRequest httpRequest)
    {
        var request = new Withdraw.Request(httpRequest.SessionKey, httpRequest.Money);
        Withdraw.Response response = _service.Withdraw(request);

        return response switch
        {
            Withdraw.Response.Success success => success.Balance,
            Withdraw.Response.IncorrectAuthorization failure => Unauthorized(),
            Withdraw.Response.NotEnoughMoney failure => BadRequest(failure.Message),
            _ => throw new UnreachableException(),
        };
    }

    [HttpPost("put-money")]
    public ActionResult<decimal> PutMoney([FromBody] PutMoneyRequest httpRequest)
    {
        var request = new PutMoney.Request(httpRequest.SessionKey, httpRequest.Money);
        PutMoney.Response response = _service.PutMoney(request);

        return response switch
        {
            PutMoney.Response.Success success => success.Balance,
            PutMoney.Response.Failure failure => Unauthorized(),
            _ => throw new UnreachableException(),
        };
    }

    [HttpGet("get-balance")]
    public ActionResult<decimal> PutMoney([FromQuery] Guid sessionKey)
    {
        var request = new GetBalance.Request(sessionKey);
        GetBalance.Response response = _service.GetBalance(request);

        return response switch
        {
            GetBalance.Response.Success success => success.Balance,
            GetBalance.Response.Failure failure => Unauthorized(),
            _ => throw new UnreachableException(),
        };
    }
}