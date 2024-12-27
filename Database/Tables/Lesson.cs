using Database.Enums;
using Database.Models;

namespace Database.Tables;

public class Lesson : BaseEntity
{
    public string Title { get; set; } = null!;
    public string? Content { get; set; }
    public string? VideoUrl { get; set; }
    public LessonType LessonType { get; set; }
    public Guid CourseId { get; set; }
    public virtual Course Course { get; set; }
    public short CoinCount { get; set; }
}