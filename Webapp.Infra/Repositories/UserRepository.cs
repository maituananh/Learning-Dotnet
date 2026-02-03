using Application.Repository;
using Infra.Configuration;
using Infra.Entity;

namespace Infra.Repository;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task Delete(Domain.User user)
    {
        var entry = _context.Entry(user);
        entry.State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        
        await Task.CompletedTask;
    }

    public void Insert(Domain.User user)
    {
        User entity = new()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Password = user.Password
        };

        _context.Add(entity);
    }

    public async Task Update(Domain.User entity)
    {
        var entry = _context.Entry(entity);
        entry.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

        await Task.CompletedTask;
    }
}
