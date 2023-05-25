using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Unisantos.TI.Domain.Providers.Auth;

namespace Unisantos.TI.Core.Providers.Auth;

public class HttpContextAuthenticatedUser : IAuthenticatedUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpContextAuthenticatedUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? Id
    {
        get
        {
            var value = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (string.IsNullOrEmpty(value))
            {
                return null;
            }

            return Guid.Parse(value);
        }
    }

    public string Name => _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.Name);
}