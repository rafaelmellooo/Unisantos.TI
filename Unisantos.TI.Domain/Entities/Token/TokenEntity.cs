using Unisantos.TI.Domain.Entities.User;
using Unisantos.TI.Domain.Enums.Token;

namespace Unisantos.TI.Domain.Entities.Token;

public class TokenEntity
{
    public Guid Id { get; set; }
    
    public string Value { get; set; }
    
    public DateTime ExpiryAt { get; set; }
    
    public string JwtId { get; set; }
    
    public TokenType Type { get; set; }
    
    public bool IsUsed { get; set; }
    
    public bool IsRevoked { get; set; }
    
    public Guid UserId { get; set; }
    
    public UserEntity User { get; set; }
}