using Application.Configurations;
using Domain;

namespace Application.Repository;

public interface IUserRepository
{
    Task Insert(User entity);
    Task Update(User entity);
    Task Delete(User entity);
}
