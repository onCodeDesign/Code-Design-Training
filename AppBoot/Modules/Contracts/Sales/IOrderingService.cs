namespace Contracts.Sales
{
    public interface IOrderingService
    {
        SalesOrder PlaceOrder(string customerName, SalesOrderRequest request);
    }
}