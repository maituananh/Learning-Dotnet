using Domain;
using Domain.Repository;
using Infra.Configuration;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository;

public class GroupUserRepository(ApplicationDbContext context) : IGroupUserRepository
{
    private readonly ApplicationDbContext _context = context;

    public void Insert(GroupUser domain)
    {
        var entity = new Entity.GroupUser(
                groupId: domain.GroupId,
                userId: domain.UserId
            );

        _context.Add(entity);
    }

    public async Task<GroupUser?> FindByGroupIdAndUserId(Guid groupId, Guid userId)
    {
        var entity = await _context.GroupUsers
            .Where(x => x.GroupId == groupId && x.UserId == userId)
            .SingleOrDefaultAsync();

        if (entity == null)
        {
            return null;
        }

        var domain = new Domain.GroupUser(
            groupId: entity.GroupId,
            userId: entity.UserId
        );

        return domain;
    }
}
