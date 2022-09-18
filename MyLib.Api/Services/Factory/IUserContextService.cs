using System.Security.Claims;

namespace MyLib.Api.Services.Factory
{
    public interface IUserContextService
    {
        ClaimsPrincipal User { get; }
        int? UserId { get; }
    }
}