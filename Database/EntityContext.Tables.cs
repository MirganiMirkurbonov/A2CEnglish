using Database.Tables;
using Microsoft.EntityFrameworkCore;

namespace Database;

public partial class EntityContext
{
    internal DbSet<User> Users { get; set; }
}