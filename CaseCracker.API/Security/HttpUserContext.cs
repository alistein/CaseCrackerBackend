using CaseCracker.Application.Common.Interfaces;
using Microsoft.AspNetCore.Authentication;

namespace CaseCracker.API.Security;

public class HttpUserContext(IHttpContextAccessor httpContextAccessor) : IHttpUserContext
{
    public int CurrentUserId
    {
        get
        {
            var user = httpContextAccessor.HttpContext?.User;

            if (user is null) return 0;
        
            var userId = user.Claims.FirstOrDefault(c => c.Type == "UserId")?.Value;
        
            _ = int.TryParse(userId, out var id);

            return id;
        }
    }

    public string? IpAddress => httpContextAccessor.HttpContext?.Connection.RemoteIpAddress?.ToString() ?? "-";
}