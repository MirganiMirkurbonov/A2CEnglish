using Database.Models;
using Domain.Enums;

namespace Database.Tables;

public class Course : BaseEntity
{
    public string Title { get; set; } = null!;
    public string Description { get; set; } = null!;
    public string? PhotoPath { get; set; }
    public EnglishLevel EnglishLevel { get; set; }
    public Guid CreatedUserId { get; set; }
    public bool IsVisible { get; set; } = true;
    public virtual User CreatedUser { get; set; }
    public List<Lesson> Lessons { get; set; }

}