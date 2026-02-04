using Microsoft.AspNetCore.Identity;

namespace Infra.Entity;

public class User : IdentityUser<Guid>
//, AuditEntity 
{
    public ICollection<GroupUser> GroupUsers { get; set; } = [];
}
