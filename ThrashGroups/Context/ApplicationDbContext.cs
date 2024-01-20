using Microsoft.EntityFrameworkCore;
using ThrashGroups.Entity;
using ThrashGroups.EntityConfiguration;

namespace ThrashGroups.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Group> Groups { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<UnderGroup> UnderGroups { get; set; }
    public DbSet<StudentGroup> StudentGroups { get; set; }
    public DbSet<StudentUnderGroup> StudentUnderGroups { get; set; }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Apply entities configuration from files in directory "./EntityConfiguration".
        // See  more: https://docs.microsoft.com/en-us/ef/core/modeling/ .
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(StudentGroupsConfiguration).Assembly);

        base.OnModelCreating(modelBuilder);
    }
}