using Database.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Configurations;

internal class LessonConfiguration : IEntityTypeConfiguration<Lesson>
{
    public void Configure(EntityTypeBuilder<Lesson> builder)
    {
        // Table name
        builder.ToTable("lessons");

        // Primary Key
        builder.HasKey(l => l.Id);

        // Title: Required with max length
        builder.Property(l => l.Title)
            .HasColumnName("title")
            .HasMaxLength(100)
            .IsRequired();

        // Content: Optional
        builder.Property(l => l.Content)
            .HasColumnName("content")
            .HasColumnType("nvarchar(max)");

        // VideoUrl: Optional with max length
        builder.Property(l => l.VideoUrl)
            .HasColumnName("video_url")
            .HasMaxLength(255);

        // LessonType: Enum stored as integer
        builder.Property(l => l.LessonType)
            .HasColumnName("lesson_type")
            .HasConversion<int>()
            .IsRequired();

        // CourseId: Required foreign key
        builder.Property(l => l.CourseId)
            .HasColumnName("course_id")
            .IsRequired();

        // Define relationship between Lesson and Course
        builder.HasOne(l => l.Course)
            .WithMany(c => c.Lessons)
            .HasForeignKey(l => l.CourseId)
            .OnDelete(DeleteBehavior.Cascade);

        // CoinCount: Default value with constraints
        builder.Property(l => l.CoinCount)
            .HasColumnName("coin_count")
            .HasDefaultValue(0)
            .IsRequired();
    }
}
