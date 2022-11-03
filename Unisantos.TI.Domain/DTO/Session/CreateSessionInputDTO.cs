using System.ComponentModel.DataAnnotations;

namespace Unisantos.TI.Domain.DTO.Session;

public class CreateSessionInputDTO
{
    [Required(ErrorMessage = "O campo e-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo e-mail está em um formato inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo senha é obrigatório")]
    public string Password { get; set; }
}