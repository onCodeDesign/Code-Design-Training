using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts.Crm
{
    public interface ICrmService
    {
        CustomerInfo GetCustomerInfo(string customerName);
    }

    public class CustomerInfo
    {
    }
}
