using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace Unisantos.TI.Domain.Validations.Annotations;

public class StrongPasswordAttribute : ValidationAttribute
{
    public override bool IsValid(object? value)
    {
        if (value is string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                return false;
            }

            return Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*[$*&@#])[0-9a-zA-Z$*&@#]{8,}$");
        }

        return false;
    }
}