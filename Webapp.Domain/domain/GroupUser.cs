namespace Domain;

public class GroupUser
{
    public Guid GroupId { get; private set; }
    public Guid UserId { get; private set; }
    public Group Group { get; private set; }
    public User User { get; private set; }

    delegate GroupUser AssignUserToGroupDelegate(Group group, User user);

    public GroupUser(Guid groupId, Guid userId)
    {
        GroupId = groupId;
        UserId = userId;
    }

    public GroupUser(Group group, User user)
    {
        GroupId = group.Id;
        UserId = user.Id;
        Group = group;
        User = user;
    }

    public static GroupUser AssignUserToGroup(GroupUser? groupUserExisted, Guid groupId, Guid userId)
    {
        if (groupUserExisted != null)
        {
            throw new InvalidOperationException("User is already assigned to the group.");
        }

        return new GroupUser(groupId, userId);
    }
}
