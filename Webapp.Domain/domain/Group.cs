namespace Domain;

public class Group
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public ICollection<User> Users { get; private set; } = [];

    private Group(Guid id)
    {
        Id = id;
    }
}
