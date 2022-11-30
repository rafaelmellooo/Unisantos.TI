using Microsoft.EntityFrameworkCore;
using Unisantos.TI.Core.Interfaces;
using Unisantos.TI.Domain.DTO.User;
using Unisantos.TI.Domain.Entities.User;
using Unisantos.TI.Domain.Exceptions.User;
using Unisantos.TI.Domain.Providers.Security;

namespace Unisantos.TI.Core.UseCases.User;

public class CreateUserUseCase : IUseCase<CreateUserInputDTO>
{
    private readonly IApplicationDbContext _applicationDbContext;
    private readonly IPasswordHashProvider _passwordHashProvider;

    public CreateUserUseCase(IApplicationDbContext applicationDbContext, IPasswordHashProvider passwordHashProvider)
    {
        _applicationDbContext = applicationDbContext;
        _passwordHashProvider = passwordHashProvider;
    }

    public async Task Execute(CreateUserInputDTO request, CancellationToken cancellationToken = default)
    {
        var user = await _applicationDbContext.Users.AsNoTracking()
            .FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

        if (user is not null)
        {
            throw new EmailAlreadyUsedException();
        }

        request.Password = _passwordHashProvider.Hash(request.Password);

        await _applicationDbContext.Users.AddAsync(new UserEntity
        {
            Email = request.Email,
            Name = request.Name,
            Password = request.Password,
            Role = request.Role,
            CreatedAt = DateTime.UtcNow
        }, cancellationToken);

        await _applicationDbContext.SaveChangesAsync(cancellationToken);
    }
}