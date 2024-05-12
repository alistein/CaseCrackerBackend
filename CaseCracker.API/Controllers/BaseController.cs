using CaseCracker.API.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CaseCracker.API.Controllers;

[ApiController]
[ValidationExceptionFormatter]
[Route("api/v1/[controller]")]
public class BaseController(IMediator mediator) : Controller
{
    protected readonly IMediator Mediator = mediator;
}