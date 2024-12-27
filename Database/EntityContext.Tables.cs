using Database.Tables;
using Microsoft.EntityFrameworkCore;

namespace Database;

public partial class EntityContext
{
    public virtual DbSet<User> Users { get; set; }
    public virtual DbSet<UserSession> UserSessions { get; set; }
}