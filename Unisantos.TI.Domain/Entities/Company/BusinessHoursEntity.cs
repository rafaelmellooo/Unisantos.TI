namespace Unisantos.TI.Domain.Entities.Company;

public class BusinessHoursEntity
{
    public byte Id { get; set; }

    public Guid CompanyId { get; set; }

    public CompanyEntity? Company { get; set; }

    public TimeOnly OpeningTime { get; set; }

    public TimeOnly ClosingTime { get; set; }

    public DayOfWeek DayOfWeek { get; set; }
}