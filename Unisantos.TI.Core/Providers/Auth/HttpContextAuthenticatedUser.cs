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

    public Guid Id
    {
        get
        {
            if (_httpContextAccessor.HttpContext is null)
            {
                throw new Exception("Erro ao obter contexto da requisição");
            }

            return new Guid(_httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier));
        }
    }

    public string Name
    {
        get
        {
            if (_httpContextAccessor.HttpContext is null)
            {
                throw new Exception("Erro ao obter contexto da requisição");
            }

            return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Name);
        }
    }
}