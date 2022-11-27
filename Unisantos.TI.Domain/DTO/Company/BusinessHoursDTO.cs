namespace Unisantos.TI.Domain.DTO.Company;

public class BusinessHoursDTO
{
    public DayOfWeek DayOfWeek { get; set; }
    
    public TimeOnly OpeningTime { get; set; }
    
    public TimeOnly ClosingTime { get; set; }
}