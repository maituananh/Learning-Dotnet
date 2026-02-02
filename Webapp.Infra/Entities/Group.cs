namespace Infra.Entity;

public class Group
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public ICollection<GroupUser> GroupUsers { get; set; } = [];
}
