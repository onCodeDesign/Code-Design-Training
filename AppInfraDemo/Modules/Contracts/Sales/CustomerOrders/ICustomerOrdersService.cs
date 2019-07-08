using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Sales.CustomerOrders
{
    public interface ICustomerOrdersService
    {
        IEnumerable<CustomerData> GetCustomersWithOrders();
        IEnumerable<CustomerData> GetCustomersWithOrdersByName(string nameContains, string nameStartsWith);
        void CancelAllOrdersForCustomer(string customerName);
    }
}
