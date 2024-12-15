using Database.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Configurations;

internal class UserSessionConfiguration : IEntityTypeConfiguration<UserSession>
{
    public void Configure(EntityTypeBuilder<UserSession> builder)
    {
        builder.ToTable("user_sessions");

        builder.HasKey(us => us.Id);
        
        builder.Property(us => us.Code)
            .HasColumnName("code")
            .HasMaxLength(6);

        builder.Property(us => us.ExpireDate)
            .HasColumnName("expire_date")
            .IsRequired();

        builder.Property(us => us.UserId)
            .HasColumnName("user_id")
            .IsRequired();

        builder.HasOne(us => us.User)
            .WithMany(u => u.UserSessions)
            .HasForeignKey(us => us.UserId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}