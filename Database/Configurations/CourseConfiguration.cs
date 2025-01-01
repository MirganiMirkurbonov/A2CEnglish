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

        // Category: Optional with max length.
        builder.Property(c => c.Category)
            .HasColumnName("category")
            .HasMaxLength(50);

        builder.Property(p => p.PhotoPath)
            .HasColumnName("photo_path")
            .HasMaxLength(255);

        builder.Property(c => c.EnglishLevel)
            .HasColumnName("english_level")
            .HasConversion<short>()
            .IsRequired();

        builder.Property(c => c.CreatedUserId)
            .HasColumnName("created_user_id")
            .IsRequired();

        builder.Property(i => i.IsVisible)
            .HasColumnName("is_visible");
        
        builder.HasMany(c => c.Lessons)
            .WithOne(l => l.Course)
            .HasForeignKey(l => l.CourseId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
