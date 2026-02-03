using Domain;

namespace Application.Repository;

public interface IUserRepository
{
    Task<User?> GetById(User user);
    void Insert(User user);
    Task Update(User user);
    Task Delete(User user);
}
