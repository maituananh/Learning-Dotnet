namespace Domain.Repository;

public interface IUserRepository
{
    Task<User?> GetById(User user);
    Task Insert(User user);
    Task Update(User user);
    Task Delete(Guid id);
    Task<User?> FindByUsername(string username);
}
