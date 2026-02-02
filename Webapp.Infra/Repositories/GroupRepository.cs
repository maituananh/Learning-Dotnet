using Application.Repository;
using Infra.Configuration;
using Infra.Entity;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repository;

public class GroupRepository(ApplicationDbContext context) : IGroupRepository
{
    private readonly ApplicationDbContext _context = context;

    public async Task<Domain.Group> GetById(Domain.Group group)
    {
        var entity = _context.Groups
            //.Include(g => g.GroupUsers)
            //.ThenInclude(u => u.User)
            .FirstOrDefault(g => g.Id == group.Id);

        

        return Task.FromResult([]);
    }
}
