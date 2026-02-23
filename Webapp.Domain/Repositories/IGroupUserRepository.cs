namespace Domain.Repository;

public interface IGroupUserRepository
{
    void Insert(GroupUser groupUser);

    Task<GroupUser?> FindByGroupIdAndUserId(Guid groupId, Guid userId);
}
