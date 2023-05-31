namespace Unisantos.TI.Domain.DTO.Company;

public record BusinessHoursResponseDTO
{
    public Guid Id { get; init; }
    
    public DayOfWeek DayOfWeek { get; set; }
    
    public required string OpeningTime { get; set; }
    
    public required string ClosingTime { get; set; }
}