namespace Application.Commands;

public class AssignUserToGroupCommand
{
    public Guid UserId { get; set; }
    public Guid GroupId { get; set; }

    public AssignUserToGroupCommand(Guid userId, Guid groupId)
    {
        UserId = userId;
        GroupId = groupId;
    }
}
