using System.ComponentModel.DataAnnotations.Schema;
using Database.Models;

namespace Database.Tables;

public class UserSession : BaseEntity
{
    public string? Code { get; set; }
    public DateTime ExpireDate { get; set; }
    public Guid UserId { get; set; }
    public virtual User User { get; set; }
}