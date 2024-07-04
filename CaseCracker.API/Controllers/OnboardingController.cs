using CaseCracker.Application.Features.Onboardings.Commands;
using CaseCracker.Application.Features.UserManagement.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CaseCracker.API.Controllers;

public class OnboardingController(IMediator mediator) : BaseController
{
    [HttpPost]
    public async Task<IActionResult> AddOnboardingAsync(AddOnboardingRequest request)
    {
        return Ok(await mediator.Send(request));
    }
}