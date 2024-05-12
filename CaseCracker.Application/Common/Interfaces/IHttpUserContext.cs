namespace CaseCracker.Application.Common.Interfaces;

public interface IHttpUserContext
{
    public int CurrentUserId { get; }
    public string? IpAddress { get; }
}