using Microsoft.AspNetCore.Http;
using Unisantos.TI.Domain.Providers.Auth;

namespace Unisantos.TI.Core.Providers.Auth;

public class HttpContextAuthenticatedUser : IAuthenticatedUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public HttpContextAuthenticatedUser(IHttpContextAccessor httpContextAccessor)
    {
        if (httpContextAccessor.HttpContext is null)
        {
            throw new Exception("Erro ao obter contexto da requisição");
        }

        _httpContextAccessor = httpContextAccessor;
    }

    public Guid? Id
    {
        get
        {
            var id = _httpContextAccessor.HttpContext!.User.Identity?.Name;

            if (string.IsNullOrEmpty(id))
            {
                return null;
            }

            return Guid.Parse(id);
        }
    }
}