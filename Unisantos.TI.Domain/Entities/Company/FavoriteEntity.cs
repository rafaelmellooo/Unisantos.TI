using Unisantos.TI.Domain.Entities.User;

namespace Unisantos.TI.Domain.Entities.Company;

public class FavoriteEntity
{
    public Guid CompanyId { get; set; }

    public required CompanyEntity Company { get; set; }

    public Guid UserId { get; set; }

    public required UserEntity User { get; set; }

    public DateTime CreatedAt { get; set; }
}