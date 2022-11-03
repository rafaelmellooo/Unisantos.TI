using Unisantos.TI.Domain.DTO.Token;
using Unisantos.TI.Domain.Entities.User;

namespace Unisantos.TI.Domain.Providers.Auth;

public interface IAuthProvider
{
    Task<TokenResponseDTO> GenerateToken(UserEntity user, CancellationToken cancellationToken = default);

    Task<TokenResponseDTO> RefreshToken(RefreshTokenInputDTO refreshToken,
        CancellationToken cancellationToken = default);
}