using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Infra.Entity;

namespace Webapp.Infra.Configuration.Database;

public class GroupConfiguration : IEntityTypeConfiguration<Group>
{
    public void Configure(EntityTypeBuilder<Group> builder)
    {
        builder.ToTable("Groups");
        builder.HasKey(e => e.Id);
        builder
            .HasMany(e => e.GroupUsers)
            .WithOne(e => e.Group)
            .HasForeignKey(e => e.GroupId);
    }
}
