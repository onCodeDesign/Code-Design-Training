using Contracts.Crm;

namespace Contracts.Sales
{
    public interface IOrderingService
    {
        SalesOrderResult PlaceOrder(string customerName, OrderRequest request);

		SalesOrderInfo[] GetOrdersInfo(string customerName);

        CustomerInfo[] GetCustomersWithOrders();
    }
}