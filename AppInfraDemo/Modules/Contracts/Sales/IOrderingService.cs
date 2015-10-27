namespace Contracts.Sales
{
    public interface IOrderingService
    {
        SalesOrderResult PlaceOrder(string customerName, OrderRequest request);
    }
}