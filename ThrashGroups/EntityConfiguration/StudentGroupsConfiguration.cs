using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThrashGroups.Entity;

namespace ThrashGroups.EntityConfiguration;

public class StudentGroupsConfiguration : IEntityTypeConfiguration<StudentGroup>
{
    public void Configure(EntityTypeBuilder<StudentGroup> builder)
    {
        builder.HasKey(e => new{e.StudentId, e.GroupId, e.Type});

        builder.HasIndex(e => new { e.StudentId, e.Type })
            .IsUnique()
            .HasFilter("\"Type\"=1")
            .HasName("IX_TypeCondition");

        builder.Property(e => e.Type)
            .IsRequired();

        builder.HasCheckConstraint("CHK_StudentGroup_Type", "\"Type\" IN (1, 2)");
    }
}