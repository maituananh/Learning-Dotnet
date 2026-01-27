using Application.Repository;

namespace Application.Configurations;

public interface IUnitOfWork
{
    //IUserRepository UserRepository { get; }

    Task CommitAsync();
}
