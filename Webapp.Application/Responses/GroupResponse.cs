namespace Application.Responses;

public class GroupResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public List<UserResponse> Users { get; set; } = [];
}
