using CaseCracker.Application.Common.Interfaces;
using MediatR;
using Microsoft.Extensions.Logging;

namespace CaseCracker.Application.Common.Behaviours;

public class UnitOfWorkBehaviour<TRequest, TResponse>(IUnitOfWork uow, ILogger<UnitOfWorkBehaviour<TRequest,TResponse>> _logger) 
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : class
{
    //TODO: How this pipeline works? 
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        await using var connection = await uow.BeginTransaction();

        TResponse? response = default;

        try
        {
            response = await next();
            await uow.SaveChangesAsync();
            await connection.CommitAsync(cancellationToken);
        }
        catch (Exception e)
        {
            _logger.LogError(e, "An error occured on transaction.");
            await connection.RollbackAsync(cancellationToken);
        }

        return response!;
    }
}
