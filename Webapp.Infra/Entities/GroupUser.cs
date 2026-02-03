namespace Infra.Entity;

public class GroupUser
{
    public Guid UserId { get; set; }

    public Guid GroupId { get; set; }

    public User User { get; set; }

    public Group Group { get; set; }

    public GroupUser(Group group, User user)
    {
        GroupId = group.Id;
        UserId = user.Id;
        Group = group;
        User = user;
    }

    public GroupUser(Guid groupId, Guid userId)
    {
        GroupId = groupId;
        UserId = userId;
    }
}
