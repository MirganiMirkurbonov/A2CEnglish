using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Models;

public abstract class BaseEntity
{
    [Column("id")]
    public Guid Id { get; set; }
    
    [Column("created_date")]
    public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    
    [Column("updated_date")]
    public DateTime? UpdatedDate { get; set; }
}