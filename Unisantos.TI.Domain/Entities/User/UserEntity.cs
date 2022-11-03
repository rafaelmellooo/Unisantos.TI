using Unisantos.TI.Domain.Entities.Token;

namespace Unisantos.TI.Domain.Entities.User;

public class UserEntity
{
    public Guid Id { get; set; }

    public string Email { get; set; }

    public string Name { get; set; }

    public string Password { get; set; }

    public bool IsAdmin { get; set; }

    public DateTime CreatedAt { get; set; }

    public ICollection<TokenEntity> Tokens { get; set; } = new List<TokenEntity>();
}