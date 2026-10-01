using Domain.Orders;
using Domain.Products;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Configurations;

public class LineItemConfiguration : IEntityTypeConfiguration<LineItem>
{
    public void Configure(EntityTypeBuilder<LineItem> builder)
    {
        builder.HasKey(o => o.Id);
        
        builder.Property(o => o.Id)
            .HasConversion(lineItemId => lineItemId.Value, lineItemId => new LineItemId(lineItemId));
        
        builder.HasOne<Product>()
            .WithMany()
            .HasForeignKey(o => o.ProductId);

        builder.OwnsOne(li => li.Price);
    }
}