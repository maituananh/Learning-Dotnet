using Application.Repository;
using Infra.Configuration;

namespace Infra.Repository;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _context;

    public UserRepository(ApplicationDbContext context)
    {
        this._context = context;
    }

    Task IUserRepository.Delete()
    {
        throw new NotImplementedException();
    }

    Task IUserRepository.FindByID(Guid id)
    {
        throw new NotImplementedException();
    }

    Task IUserRepository.Save()
    {
        throw new NotImplementedException();
    }

    Task IUserRepository.Update()
    {
        throw new NotImplementedException();
    }
}
