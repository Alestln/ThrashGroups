using Microsoft.EntityFrameworkCore;
using ThrashGroups.Entity;

namespace ThrashGroups.Context;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Group> Groups { get; set; }
}