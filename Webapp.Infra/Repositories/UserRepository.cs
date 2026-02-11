using Application.Repository;
using Infra.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository;

public class UserRepository(
    ApplicationDbContext context,
    UserManager<Entity.User> userManager
    ) : IUserRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task Delete(Guid id)
    {
        var entry = await _context.Users.FindAsync(id);

        if (entry != null)
        {
            await userManager.DeleteAsync(entry);
        }
    }

    public async Task<Domain.User?> GetById(Domain.User user)
    {
        var entity = await _context.Users.FindAsync(user.Id);

        return entity is null ? null : new Domain.User(
            id: entity.Id,
            name: entity.UserName!,
            email: entity.Email!
        );
    }

    public async Task Insert(Domain.User user)
    {
        Entity.User entity = new()
        {
            UserName = user.Name,
            Email = user.Email,
        };

        var userCreation = await userManager.CreateAsync(entity, user.Password);

        if (!userCreation.Succeeded)
        {
            throw new Exception("User creation failed");
        }

        var userRole = await userManager.AddToRoleAsync(entity, "User");

        if (!userRole.Succeeded)
        {
            throw new Exception("Assigning role failed");
        }
    }

    public async Task Update(Domain.User user)
    {
        var entity = await _context.Users.FindAsync(user.Id);

        if (entity != null)
        {
            entity.Email = user.Email;
            entity.UserName = user.Name;
            entity.PasswordHash = user.Password;

            _context.Update(entity);
        }
    }

    public async Task<Domain.User?> FindByUsername(string username)
    {
        var entity = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

        if (entity != null)
        {
            return new Domain.User(
                id: entity.Id,
                name: entity.UserName!,
                email: entity.Email!,
                password: entity.PasswordHash!
            );
        }

        return null;
    }
}
