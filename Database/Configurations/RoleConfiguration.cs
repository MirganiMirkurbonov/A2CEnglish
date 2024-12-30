using Database.Tables;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.Configurations;

internal class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.ToTable("roles");

        builder.Property(r => r.Name)
            .HasColumnName("name")
            .HasMaxLength(150)
            .IsRequired();

        builder
            .Property(x => x.Keyword)
            .HasColumnName("keyword")
            .HasMaxLength(200)
            .IsRequired();

        builder.HasData(
            new Role
            {
                Id = Guid.Parse("CE9B1D65-086A-4C11-8F40-E5DBB43391CD"),
                Name = "Admin",
                Keyword = "admin"
            },
            new Role
            {
                Id = Guid.Parse("CE9B1D69-086A-4C11-8F40-E5DBB43391CD"),
                Name = "User",
                Keyword = "user"
            }
        );
    }
}