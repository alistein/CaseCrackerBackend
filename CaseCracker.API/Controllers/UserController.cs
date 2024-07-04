using CaseCracker.Application.Features.UserManagement.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CaseCracker.API.Controllers;
public class UserController(IMediator mediator) : BaseController
{
    [HttpPost("register")]
    public async Task<IActionResult> Register(CreateUserRequest request)
    {
        return Ok(await mediator.Send(request));
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> Update(UpdateUserRequest request)
    {
        return Ok(await mediator.Send(request));
    }
}