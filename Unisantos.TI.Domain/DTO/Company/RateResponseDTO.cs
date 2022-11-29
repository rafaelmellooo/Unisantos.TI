namespace Unisantos.TI.Domain.DTO.Company;

public record RateResponseDTO
{
    public required string User { get; set; }
    
    public required string Comment { get; set; }
    
    public float Rate { get; set; }
}