using Microsoft.EntityFrameworkCore;
using Unisantos.TI.Core.Interfaces;
using Unisantos.TI.Domain.DTO.Session;
using Unisantos.TI.Domain.DTO.Token;
using Unisantos.TI.Domain.Providers.Auth;
using Unisantos.TI.Domain.Providers.Security;

namespace Unisantos.TI.Core.UseCases.Session;

public class CreateSessionUseCase : IUseCase<CreateSessionInputDTO, TokenResponseDTO>
{
    private readonly IAuthProvider _authProvider;
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IPasswordHashProvider _passwordHashProvider;

    public CreateSessionUseCase(IAuthProvider authProvider, IApplicationDbContext applicationDbContext,
        IPasswordHashProvider passwordHashProvider)
    {
        _authProvider = authProvider;
        _applicationDbContext = applicationDbContext;
        _passwordHashProvider = passwordHashProvider;
    }

    public async Task<TokenResponseDTO> Execute(CreateSessionInputDTO request,
        CancellationToken cancellationToken = default)
    {
        var user = await _applicationDbContext.Users.AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

        if (user is null)
        {
            throw new Exception("Usuário não encontrado");
        }

        if (!_passwordHashProvider.Verify(user.Password, request.Password))
        {
            throw new Exception("Senha inválida");
        }

        return await _authProvider.GenerateToken(user, cancellationToken);
    }
}