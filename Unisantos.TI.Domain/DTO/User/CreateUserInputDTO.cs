using System.ComponentModel.DataAnnotations;
using Unisantos.TI.Domain.Enums.User;
using Unisantos.TI.Domain.Validations.Annotations;

namespace Unisantos.TI.Domain.DTO.User;

public record CreateUserInputDTO
{
    [Required(ErrorMessage = "O campo senha é obrigatório")]
    public required string Name { get; set; }

    [Required(ErrorMessage = "O campo e-mail é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo e-mail é inválido")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "O campo senha é obrigatório")]
    [StrongPassword(ErrorMessage =
        "O campo senha deve conter pelo menos 1 letra maiúscula, 1 letra minúscula, 1 número e 1 caractere especial")]
    public required string Password { get; set; }

    [Required(ErrorMessage = "A confirmação de senha é obrigatória")]
    [Compare("Password", ErrorMessage = "A confirmação de senha não confere")]
    public required string PasswordConfirmation { get; set; }
    
    [Required(ErrorMessage = "O campo tipo de usuário é obrigatório")]
    public UserRole Role { get; set; }
}