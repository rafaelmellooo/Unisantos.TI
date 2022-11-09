using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Unisantos.TI.Core.Helpers;
using Unisantos.TI.Core.Interfaces;
using Unisantos.TI.Domain.DTO.Token;
using Unisantos.TI.Domain.Entities.Token;
using Unisantos.TI.Domain.Entities.User;
using Unisantos.TI.Domain.Enums.Token;
using Unisantos.TI.Domain.Providers;
using Unisantos.TI.Domain.Providers.Auth;

namespace Unisantos.TI.Core.Providers.Auth;

public class JwtAuthProvider : IAuthProvider
{
    private readonly IConfigurationProvider _configurationProvider;
    private readonly IApplicationDbContext _applicationDbContext;

    public JwtAuthProvider(IConfigurationProvider configurationProvider, IApplicationDbContext applicationDbContext)
    {
        _configurationProvider = configurationProvider;
        _applicationDbContext = applicationDbContext;
    }

    private byte[] SecretKey => Encoding.UTF8.GetBytes(_configurationProvider.AuthSettings.Secret);

    public async Task<TokenResponseDTO> GenerateToken(UserEntity user, CancellationToken cancellationToken = default)
    {
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        var securityTokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.Name),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            }),
            Expires = DateTime.UtcNow.Add(_configurationProvider.AuthSettings.ExpiryTimeFrame),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(SecretKey),
                SecurityAlgorithms.HmacSha256Signature)
        };

        var token = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);

        var jwtToken = jwtSecurityTokenHandler.WriteToken(token);

        var refreshToken = new TokenEntity
        {
            JwtId = token.Id,
            UserId = user.Id,
            ExpiryAt = DateTime.UtcNow.AddYears(1),
            Type = TokenType.RefreshToken,
            Value = RandomHelpers.RandomString(25) + Guid.NewGuid()
        };

        await _applicationDbContext.Tokens.AddAsync(refreshToken, cancellationToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        return new TokenResponseDTO
        {
            Token = jwtToken,
            RefreshToken = refreshToken.Value
        };
    }

    public async Task<TokenResponseDTO> RefreshToken(RefreshTokenInputDTO refreshToken,
        CancellationToken cancellationToken = default)
    {
        var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

        var claimsPrincipal = jwtSecurityTokenHandler.ValidateToken(refreshToken.Token, new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(SecretKey),
            ValidateIssuer = false,
            ValidateAudience = false,
            ValidateLifetime = false,
            RequireExpirationTime = false
        }, out var validatedToken);

        if (validatedToken is not JwtSecurityToken jwtSecurityToken)
        {
            throw new Exception("Token inválido");
        }

        if (!jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
        {
            throw new Exception("Token não usa o algoritmo correto");
        }

        var storedRefreshToken = await _applicationDbContext.Tokens.FirstOrDefaultAsync(t =>
            t.Value == refreshToken.RefreshToken && t.Type == TokenType.RefreshToken, cancellationToken);

        if (storedRefreshToken is null)
        {
            throw new Exception("Refresh Token não encontrado");
        }

        var jti = claimsPrincipal.FindFirstValue(JwtRegisteredClaimNames.Jti);

        if (!storedRefreshToken.JwtId.Equals(jti))
        {
            throw new Exception("Refresh Token inválido");
        }

        if (DateTime.UtcNow > storedRefreshToken.ExpiryAt)
        {
            throw new Exception("Refresh Token expirado");
        }

        if (storedRefreshToken.IsUsed)
        {
            throw new Exception("Refresh Token já utilizado");
        }

        if (storedRefreshToken.IsRevoked)
        {
            throw new Exception("Refresh Token revogado");
        }

        storedRefreshToken.IsUsed = true;
        _applicationDbContext.Tokens.Update(storedRefreshToken);
        await _applicationDbContext.SaveChangesAsync(cancellationToken);

        var user = await _applicationDbContext.Users.AsNoTracking()
            .FirstAsync(u => u.Id == storedRefreshToken.UserId, cancellationToken);

        return await GenerateToken(user, cancellationToken);
    }
}