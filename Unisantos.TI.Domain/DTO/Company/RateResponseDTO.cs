namespace Unisantos.TI.Domain.DTO.Company;

public record RateResponseDTO
{
    public Guid Id { get; init; }
    
    public required string User { get; set; }
    
    public required string Comment { get; set; }
    
    public float Rate { get; set; }
}