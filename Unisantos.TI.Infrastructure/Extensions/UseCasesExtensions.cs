using Microsoft.Extensions.DependencyInjection;
using Unisantos.TI.Core.UseCases.Address;
using Unisantos.TI.Core.UseCases.Admin;
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

        services.AddScoped<GetStatesUseCase, GetStatesUseCase>();
        services.AddScoped<GetCitiesUseCase, GetCitiesUseCase>();
        
        services.AddScoped<GetTagsUseCase, GetTagsUseCase>();
        services.AddScoped<GetCompaniesUseCase, GetCompaniesUseCase>();
        services.AddScoped<GetCompanyDetailsUseCase, GetCompanyDetailsUseCase>();
        services.AddScoped<CreateCompanyUseCase, CreateCompanyUseCase>();
        services.AddScoped<UpdateCompanyUseCase, UpdateCompanyUseCase>();
        services.AddScoped<DeleteCompanyUseCase, DeleteCompanyUseCase>();
        services.AddScoped<FavoriteCompanyUseCase, FavoriteCompanyUseCase>();
        services.AddScoped<RateCompanyUseCase, RateCompanyUseCase>();
        services.AddScoped<GetFavoriteCompaniesUseCase, GetFavoriteCompaniesUseCase>();

        services.AddScoped<GetAdminCompaniesUseCase, GetAdminCompaniesUseCase>();
    }
}