namespace Domain.Products;

public record Sku
{
    private const int DefaultSkuLength = 15;
    private Sku(string value)
    {
        Value = value;
    }
    
    public string Value { get; init; }
    
    
    // Stock keeping Unit
    public static Sku? Create(string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return null;
        }

        if (value.Length != DefaultSkuLength)
        {
            return null;    
        }

        return new Sku(value);
    }
}