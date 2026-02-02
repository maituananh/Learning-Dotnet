using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infra.Entity;

namespace Webapp.Infra.Configuration.Database;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");
        builder.HasKey(e => e.Id);
        builder
            .HasMany(e => e.GroupUsers)
            .WithOne(e => e.User)
            .HasForeignKey(e => e.UserId);
    }
}
