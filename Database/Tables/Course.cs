using Database.Enums;
using Database.Models;

namespace Database.Tables;

public class Course : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? Category { get; set; }
    public EnglishLevel EnglishLevel { get; set; }
    public Guid CreatedUserId { get; set; }
    public virtual User CreatedUser { get; set; }
    public List<Lesson> Lessons { get; set; }

}