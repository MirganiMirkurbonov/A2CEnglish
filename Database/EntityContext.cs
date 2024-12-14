using System.Reflection;
using Database.Tables;
using Domain.Models.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Database;

public partial class EntityContext(IOptions<DatabaseOptions> options) : DbContext
{
    public EntityContext() : this(default)
    {
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(options.Value.ConnectionString);
        base.OnConfiguring(optionsBuilder);
    }

    internal DbSet<User> Users { get; set; }
}