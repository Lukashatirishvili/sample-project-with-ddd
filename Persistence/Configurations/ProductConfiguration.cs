using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class ProductConfiguration : IEntityTypeConfiguration<Product>
{
    public void Configure(EntityTypeBuilder<Product> builder)
    {
        builder.HasKey(c => c.Id);
        
        builder.Property(c => c.Id)
            .HasConversion(productId => productId.Value, productId => new ProductId(productId));
        
        builder.Property(c => c.Sku)
            .HasConversion(sku => sku.Value, value => Sku.Create(value)!);

        builder.OwnsOne(c => c.Price, priceBuilder =>
        {
            priceBuilder.Property(p => p.Currency).HasMaxLength(3);
        });
    }
}