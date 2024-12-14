using System.Reflection;
using Database.Tables;
using Microsoft.EntityFrameworkCore;

namespace Database;

public partial class EntityContext : DbContext
{
    public EntityContext(DbContextOptions<EntityContext> options) : base(options) { }
    public EntityContext() { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
    
    internal DbSet<User> Users { get; set; }
}