using System.ComponentModel.DataAnnotations.Schema;
using Database.Models;

namespace Database.Tables;

public class Role : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Keyword { get; set; } = null!;
    public virtual ICollection<RolePermission> RolePermissions { get; set; }
    public virtual ICollection<User> Users { get; set; }

}