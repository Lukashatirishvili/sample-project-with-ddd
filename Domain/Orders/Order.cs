using Domain.Customers;
using Domain.Products;

namespace Domain.Orders;

public class Order
{
    private readonly HashSet<LineItem> _lineItems;

    private Order()
    {
        
    }
    
    public OrderId Id { get; private set; }
    public CustomerId CustomerId { get; private set; }

    public void Add(ProductId productId, Money price)
    {
        var lineItem = new LineItem(new LineItemId(Guid.NewGuid()), Id, productId, price);
        _lineItems.Add(lineItem);
    }

    public static Order Create(Customer customer)
    {
        var order = new Order
        {
            Id = new OrderId(Guid.NewGuid()),
            CustomerId = new CustomerId(customer.Id),
        };
        
        return order;
    }
}

public class LineItem
{

    internal LineItem(LineItemId id, OrderId orderId, ProductId productId, Money price)
    {
        Id = id;
        OrderId = orderId;
        ProductId = productId;
        Price = price;
    }
    
    public LineItemId Id { get; private set; }
    public OrderId OrderId { get; private set; }
    public ProductId ProductId { get; private set; }
    public Money Price { get; private set; }
    
}

public record LineItemId(Guid Value);