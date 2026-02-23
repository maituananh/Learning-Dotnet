namespace Domain.Group;

public class Group
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public List<User> Users { get; private set; } = [];

    public Group(Guid id)
    {
        Id = id;
    }

    public Group(Guid id, string name, List<User> users)
    {
        Id = id;
        Name = name;
        Users = users;
    }

    public Group(Guid id, string name)
    {
        Id = id;
        Name = name;
    }
}
