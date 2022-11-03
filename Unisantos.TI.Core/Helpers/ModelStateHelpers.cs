using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Unisantos.TI.Core.Helpers;

public static class ModelStateHelpers
{
    public static string GetErrorMessages(this ModelStateDictionary modelState)
    {
        return string.Join(" | ", modelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage));
    }
}