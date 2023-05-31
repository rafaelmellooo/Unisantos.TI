using System.ComponentModel.DataAnnotations;

namespace Unisantos.TI.Domain.DTO.Company;

public record BusinessHoursInputDTO
{
    public Guid? Id { get; set; }
    
    [Required(ErrorMessage = "O dia da semana é obrigatório")]
    public DayOfWeek DayOfWeek { get; set; }
    
    [Required(ErrorMessage = "A hora de abertura é obrigatória")]
    public required string OpeningTime { get; set; }
    
    [Required(ErrorMessage = "A hora de fechamento é obrigatória")]
    public required string ClosingTime { get; set; }
}