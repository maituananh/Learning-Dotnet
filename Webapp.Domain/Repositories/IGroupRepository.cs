namespace Domain.Repository;

public interface IGroupRepository
{
    Task<Group?> GetById(Group group);
}
