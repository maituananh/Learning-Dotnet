using Domain;

namespace Application.Repository;

public interface IGroupRepository
{
    Task<Group?> GetById(Group group);
}
