using Infra.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Webapp.Infra.Configuration.Database;

public class GroupUserConfiguration : IEntityTypeConfiguration<GroupUser>
{
    public void Configure(EntityTypeBuilder<GroupUser> builder)
    {
        builder.ToTable("GroupUsers");
        builder.HasKey(e => new { e.UserId, e.GroupId });
        builder
            .HasOne(e => e.Group)
            .WithMany(e => e.GroupUsers)
            .HasForeignKey(e => e.GroupId);
        builder
            .HasOne(e => e.User)
            .WithMany(e => e.GroupUsers)
            .HasForeignKey(e => e.UserId);
    }
}
