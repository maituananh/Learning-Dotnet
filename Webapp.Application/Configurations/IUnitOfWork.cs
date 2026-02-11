namespace Application.Configurations;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken cancellationToken);

    Task BeginTransactionAsync(CancellationToken cancellationToken);

    Task RollbackAsync(CancellationToken cancellationToken);
}
