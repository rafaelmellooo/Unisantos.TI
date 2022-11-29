using System.ComponentModel.DataAnnotations;

namespace Unisantos.TI.Domain.DTO.Session;

public record CreateSessionInputDTO
{
    [Required(ErrorMessage = "O campo e-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo e-mail está em um formato inválido")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "O campo senha é obrigatório")]
    public required string Password { get; set; }
}