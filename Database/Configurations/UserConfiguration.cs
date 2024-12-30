using Database.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Configurations;

internal class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");

        builder.Property(u => u.Name)
            .HasColumnName("name")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(u => u.Phone)
            .HasColumnName("phone")
            .HasMaxLength(20);

        builder.Property(u => u.Email)
            .HasColumnName("email")
            .HasMaxLength(50);

        builder.Property(u => u.EnglishLevel)
            .HasColumnName("english_level")
            .HasConversion<int>()
            .IsRequired();

        builder.Property(u => u.TelegramChatId)
            .HasColumnName("telegram_chat_id");
        
        builder.Property(u => u.Password)
            .HasColumnName("password");

        builder.Property(u => u.RoleId)
            .HasColumnName("role_id")
            .IsRequired();

        // Relationships
        builder.HasOne(u => u.Role)
            .WithMany(x=>x.Users)
            .HasForeignKey(u => u.RoleId)
            .OnDelete(DeleteBehavior.Restrict); // Prevent cascading delete
    }
}