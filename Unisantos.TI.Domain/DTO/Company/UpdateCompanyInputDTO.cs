namespace Unisantos.TI.Domain.DTO.Company;

public record UpdateCompanyBodyInputDTO : CreateCompanyInputDTO
{
    public ICollection<Guid> RemovedBusinessHours { get; set; } = new List<Guid>();

    public ICollection<Guid> RemovedProductSections { get; set; } = new List<Guid>();

    public ICollection<Guid> RemovedProducts { get; set; } = new List<Guid>();
}

public record UpdateCompanyInputDTO : UpdateCompanyBodyInputDTO
{
    public Guid Id { get; set; }
}