using Domain;

namespace Application.Repository;

public interface IUserRepository
{
    void Insert(User entity);
    Task Update(User entity);
    Task Delete(User entity);
}
