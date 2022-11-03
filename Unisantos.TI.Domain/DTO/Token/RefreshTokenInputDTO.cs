using System.ComponentModel.DataAnnotations;

namespace Unisantos.TI.Domain.DTO.Token;

public class RefreshTokenInputDTO
{
    [Required]
    public string Token { get; set; }
        
    [Required]
    public string RefreshToken { get; set; }
}