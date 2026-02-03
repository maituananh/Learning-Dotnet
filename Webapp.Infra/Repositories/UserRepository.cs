using Application.Repository;
using Infra.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository;

public class UserRepository(ApplicationDbContext context) : IUserRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task Delete(Guid id)
    {
        var entry = await _context.Users.FindAsync(id);

        if (entry != null)
        {
            _context.Remove(entry);
        }
    }

    public async Task<Domain.User?> GetById(Domain.User user)
    {
        var entity = await _context.Users.FindAsync(user.Id);

        return entity is null ? null : new Domain.User(
            id: entity.Id,
            name: entity.Name,
            email: entity.Email
        );
    }

    public void Insert(Domain.User user)
    {
        Entity.User entity = new()
        {
            Id = user.Id,
            Name = user.Name,
            Email = user.Email,
            Password = user.Password
        };

        _context.Add(entity);
    }

    public async Task Update(Domain.User user)
    {
        var entity = await _context.Users.FindAsync(user.Id);

        if (entity != null)
        {
            entity.Email = user.Email;
            entity.Name = user.Name;
            entity.Password = user.Password;

            _context.Update(entity);
        }
    }
}
