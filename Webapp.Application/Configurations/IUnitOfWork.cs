namespace Application.Configurations;

public interface IUnitOfWork
{
    Task CommitAsync(CancellationToken cancellationToken);
}
