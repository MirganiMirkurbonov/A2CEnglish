using Database.Tables;
using Microsoft.EntityFrameworkCore;

namespace Database;

public partial class EntityContext
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserSession> UserSessions { get; set; }
    public virtual DbSet<Lesson> Lessons { get; set; }
    public virtual DbSet<Role> Roles { get; set; }
    public virtual DbSet<Permission> Permissions { get; set; }
    public virtual DbSet<RolePermission> RolePermissions { get; set; }
    public virtual DbSet<Course> Courses { get; set; }
}