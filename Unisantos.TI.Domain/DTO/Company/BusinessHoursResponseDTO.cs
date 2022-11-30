namespace Unisantos.TI.Domain.DTO.Company;

public record BusinessHoursResponseDTO
{
    public byte Id { get; set; }
    
    public DayOfWeek DayOfWeek { get; set; }
    
    public TimeOnly OpeningTime { get; set; }
    
    public TimeOnly ClosingTime { get; set; }
}