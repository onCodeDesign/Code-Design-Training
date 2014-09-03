namespace Contracts.Sales
{
    public class OrderRequest
    {
        public ProductQuantity[] Products { get; set; }
    }

    public class ProductQuantity
    {
        public ProductDescription Product { get; set; }
        public float Quantity { get; set; }
        public UnitOfMeasure Unit { get; set; }
    }

    public class ProductDescription
    {
        public int? ProductId { get; set; }
        public string Code { get; set; }
        public string Description { get; set; }
    }

    public enum UnitOfMeasure
    {
        Item,
        Kilograms,
        Liters
    }
}