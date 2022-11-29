namespace Unisantos.TI.Domain.DTO.Token;

public record TokenResponseDTO
{
    public required string Token { get; set; }
        
    public required string RefreshToken { get; set; }
}