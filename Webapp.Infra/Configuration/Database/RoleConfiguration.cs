using Microsoft.EntityFrameworkCore;
using Webapp.Infra.Entities;

namespace Webapp.Infra.Configuration.Database;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Role> builder)
    {
        builder.HasData(
            new Role
            {
                Id = new Guid("a1a9525c-51ab-45ee-9bb9-8958c6df85b0"),
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "3b10415d-2e9c-46bb-8b17-8eb5d6bb1ced"
            },
            new Role
            {
                Id = new Guid("cd583380-a397-4c43-87f0-dccf7f4c521a"),
                Name = "User",
                NormalizedName = "USER",
                ConcurrencyStamp = "3b10415d-2e9c-46bb-8b17-8eb5d6bb1ced"
            }
            );
    }
}
