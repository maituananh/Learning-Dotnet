using Domain;
using Domain.Repository;
using Infra.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository;

public class GroupRepository(ApplicationDbContext context) : IGroupRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Group?> GetById(Group group)
    {
        var entity = await _context.Groups
            .Include(g => g.GroupUsers)
            .ThenInclude(gu => gu.User)
            .FirstOrDefaultAsync(g => g.Id == group.Id);

        if (entity == null)
        {
            return null;
        }

        return new Group(
            entity.Id,
            entity.Name,
            [.. entity.GroupUsers.Select(gu => new User(gu.User.Id, gu.User.UserName, gu.User.Email))]);
    }
}
