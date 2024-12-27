using Database.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Configurations;

public class CourseConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        // Table name
        builder.ToTable("courses");

        // Primary Key
        builder.HasKey(c => c.Id);

        // Title: Required with max length
        builder.Property(c => c.Title)
            .HasColumnName("title")
            .HasMaxLength(100)
            .IsRequired();

        // Description: Required with max length
        builder.Property(c => c.Description)
            .HasColumnName("description")
            .HasMaxLength(500)
            .IsRequired();

        // Category: Optional with max length
        builder.Property(c => c.Category)
            .HasColumnName("category")
            .HasMaxLength(50);

        // EnglishLevel: Enum stored as integer
        builder.Property(c => c.EnglishLevel)
            .HasColumnName("english_level")
            .HasConversion<short>()
            .IsRequired();

        // CreatedUserId: Required foreign key
        builder.Property(c => c.CreatedUserId)
            .HasColumnName("created_user_id")
            .IsRequired();
        
        // Define relationship between Course and Lessons
        builder.HasMany(c => c.Lessons)
            .WithOne(l => l.Course)
            .HasForeignKey(l => l.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
