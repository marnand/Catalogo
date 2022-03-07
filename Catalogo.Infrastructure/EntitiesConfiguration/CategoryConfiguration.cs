using Catalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogo.Infrastructure.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).UseIdentityColumn().HasColumnType("INT");
            builder.Property(c => c.Name).HasMaxLength(50).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(c => c.ImageURL).HasMaxLength(250).HasColumnType("VARCHAR(250)").IsRequired();
            builder.Property(c => c.CreatedAt).HasColumnType("DATETIME");
            builder.Property(c => c.UpdatedAt).HasColumnType("DATETIME");
        }
    }
}
