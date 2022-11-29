namespace Unisantos.TI.Domain.DTO.Company;

public record BusinessHoursDTO
{
    public DayOfWeek DayOfWeek { get; set; }
    
    public TimeOnly OpeningTime { get; set; }
    
    public TimeOnly ClosingTime { get; set; }
}