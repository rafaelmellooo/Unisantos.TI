using System.ComponentModel.DataAnnotations;

namespace Unisantos.TI.Domain.DTO.Token;

public record RefreshTokenInputDTO
{
    [Required]
    public required string Token { get; set; }
        
    [Required]
    public required string RefreshToken { get; set; }
}