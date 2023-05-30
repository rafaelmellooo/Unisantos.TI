namespace Unisantos.TI.Domain.DTO.Company;

public record BusinessHoursResponseDTO
{
    public Guid Id { get; init; }
    
    public DayOfWeek DayOfWeek { get; set; }
    
    public TimeOnly OpeningTime { get; set; }
    
    public TimeOnly ClosingTime { get; set; }
}