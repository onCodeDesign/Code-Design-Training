using System.Linq;
using Contracts.Crm;
using Contracts.Location;
using DataAccess;
using Export.DataModel;

namespace Export.Services.PageXmlDemo
{
    public class PageContentEnricher
    {
        public void EnrichWithExternalData(PageXml content, PageData externalData, IRepository repository,
            ICrmService crmService, int salesOrders, bool addCustomerDetails, ILocationService locationService)
        {
            // enrich with  externalData other than customer


            if (externalData.CustomerData != null)
            {
                // enrich with externalData.CustomerData 
            }
            else
            {
                CustomerInfo customerData = crmService.GetCustomerInfo(content.Customer.Name);
            }

            if (salesOrders > 0)
            {
                var orders = repository.GetEntities<Order>()
                    .Where(o => o.Customer.CompanyName == content.Customer.Name)
                    .OrderBy(o => o.OrderDate)
                    .Take(salesOrders);

                //enrich with orders
            }
        }


        public void Enrich(PageXml content, IRepository repository, int salesOrder, bool addCustomerDetails)
        {
        }
    }
}