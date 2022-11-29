using Unisantos.TI.Domain.Entities.User;

namespace Unisantos.TI.Domain.Entities.Company;

public class RateEntity
{
    public Guid Id { get; set; }

    public float Rate { get; set; }

    public required string Comment { get; set; }

    public Guid CompanyId { get; set; }

    public required CompanyEntity Company { get; set; }

    public Guid UserId { get; set; }

    public required UserEntity User { get; set; }
}