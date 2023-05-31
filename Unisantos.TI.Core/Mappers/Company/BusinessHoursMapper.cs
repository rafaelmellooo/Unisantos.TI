using Unisantos.TI.Domain.DTO.Company;
using Unisantos.TI.Domain.Entities.Company;

namespace Unisantos.TI.Core.Mappers.Company;

public static class BusinessHoursMapper
{
    public static BusinessHoursEntity Mapper(BusinessHoursInputDTO businessHours)
    {
        var businessHoursEntity = new BusinessHoursEntity
        {
            DayOfWeek = businessHours.DayOfWeek,
            OpeningTime = TimeOnly.Parse(businessHours.OpeningTime),
            ClosingTime = TimeOnly.Parse(businessHours.ClosingTime)
        };

        if (businessHours.Id.HasValue)
        {
            businessHoursEntity.Id = businessHours.Id.Value;
        }

        return businessHoursEntity;
    }
}