using CaseCracker.Application.Features.UserManagement.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CaseCracker.API.Controllers;

public class UserController(IMediator mediator) : BaseController(mediator)
{
    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        return Ok(await mediator.Send(request));
    }
    
    [HttpPut]
    public async Task<IActionResult> UpdateUser(UpdateUserRequest request)
    {
        return Ok(await mediator.Send(request));
    }

}