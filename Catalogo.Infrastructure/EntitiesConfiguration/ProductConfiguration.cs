using Catalogo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalogo.Infrastructure.EntitiesConfiguration
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(p => p.Id);
            builder.Property(x => x.Id).UseIdentityColumn().HasColumnType("INT");
            builder.Property(p => p.Name).HasMaxLength(50).HasColumnType("VARCHAR(50)").IsRequired();
            builder.Property(p => p.Price).HasPrecision(10,2).IsRequired();
            builder.Property(p => p.Stock).HasColumnType("INT").IsRequired();
            builder.Property(p => p.Description).HasMaxLength(200).HasColumnType("VARCHAR(200)").IsRequired();
            builder.Property(p => p.ImageURL).HasMaxLength(250).HasColumnType("VARCHAR(250)").IsRequired();
            builder.Property(p => p.CreatedAt).HasColumnType("DATETIME");
            builder.Property(p => p.UpdatedAt).HasColumnType("DATETIME");

            builder.HasOne<Category>().WithMany().HasForeignKey(x => x.CategoryId);
        }
    }
}
