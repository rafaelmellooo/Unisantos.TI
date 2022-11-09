using Microsoft.Extensions.DependencyInjection;
using Unisantos.TI.Core.UseCases.Company;
using Unisantos.TI.Core.UseCases.Session;
using Unisantos.TI.Core.UseCases.User;

namespace Unisantos.TI.Infrastructure.Extensions;

public static class UseCasesExtensions
{
    public static void AddUseCases(this IServiceCollection services)
    {
        services.AddScoped<CreateSessionUseCase, CreateSessionUseCase>();

        services.AddScoped<CreateUserUseCase, CreateUserUseCase>();

        services.AddScoped<GetTagsUseCase, GetTagsUseCase>();
        services.AddScoped<GetCompaniesUseCase, GetCompaniesUseCase>();
    }
}