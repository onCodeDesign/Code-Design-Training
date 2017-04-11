using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Sales.Services
{
    public interface IOrdersService
    {
        void PlaceSellLimitOrder(string securityCode, decimal sellingPrice, DateTime validUntil);
        void PlaceBuyLimitOrder(string securityCode, decimal buyingPrice, DateTime validUntil);
        LimitOrder[] GetLimitOrders();
    }
}
