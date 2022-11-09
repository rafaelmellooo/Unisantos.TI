using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Unisantos.TI.Domain.Enums.User;
using Unisantos.TI.Domain.Validations.Annotations;

namespace Unisantos.TI.Domain.DTO.User;

public class CreateUserInputDTO
{
    [Required(ErrorMessage = "O campo senha é obrigatório")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O campo e-mail é obrigatório")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo senha é obrigatório")]
    [StrongPassword(ErrorMessage =
        "O campo senha deve conter pelo menos 1 letra maiúscula, 1 letra minúscula, 1 número e 1 caractere especial")]
    public string Password { get; set; }

    [Required(ErrorMessage = "A confirmação de senha é obrigatória")]
    [Compare("Password", ErrorMessage = "A confirmação de senha não confere")]
    public string PasswordConfirmation { get; set; }
    
    [Required(ErrorMessage = "O campo tipo de usuário é obrigatório")]
    public UserRole Role { get; set; }
}