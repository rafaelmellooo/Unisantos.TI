namespace Unisantos.TI.Domain.DTO.Company;

public class BusinessHoursResponseDTO
{
    public TimeOnly OpeningTime { get; set; }
    
    public TimeOnly ClosingTime { get; set; }

    public DayOfWeek DayOfWeek { get; set; }
}