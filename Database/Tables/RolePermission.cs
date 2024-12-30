﻿using Database.Models;

namespace Database.Tables;

public class RolePermission : BaseEntity
{
    public Guid RoleId { get; set; }
    public virtual Role Role { get; set; }

    public Guid PermissionId { get; set; }
    public virtual Permission Permission { get; set; }
}