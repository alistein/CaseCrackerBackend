using CaseCracker.Application.Common.Interfaces;
using Microsoft.AspNetCore.Http;

namespace CaseCracker.Infrastructure.Services;

public class HttpUserContext(IHttpContextAccessor contextAccessor) : IHttpUserContext
{
    public int CurrentUserId { get; }
    public string IpAddress { get; }
}