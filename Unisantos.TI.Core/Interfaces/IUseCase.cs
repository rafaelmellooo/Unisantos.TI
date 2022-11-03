namespace Unisantos.TI.Core.Interfaces;

public interface IUseCase<TRequest, TResponse>
{
    Task<TResponse> Execute(TRequest request, CancellationToken cancellationToken = default);
}

public interface IUseCase<TRequest>
{
    Task Execute(TRequest request, CancellationToken cancellationToken = default);
}