using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ThrashGroups.Entity;

namespace ThrashGroups.EntityConfiguration;

public class StudentUnderGroupConfiguration : IEntityTypeConfiguration<StudentUnderGroup>
{
    public void Configure(EntityTypeBuilder<StudentUnderGroup> builder)
    {
        builder.HasKey(e => new { e.StudentId, e.UnderGroupId });
    }
}