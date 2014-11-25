using System;
using System.Collections.Generic;
using System.Linq;

namespace LessonsSamples.Lesson7.CohesionCoupling
{
    // A better cohesion by moving into IExportDataProvider_5 all the responsibilities of getting needed data, including from DB
    //   PageXmlExport_5 contains the enrichment responsibilities only 

    public class PageXmlExport_5
    {
        private readonly IPageFileWriter fileWriter;
        private readonly IExportDataProvider_5 dataProvider;
        private readonly ILocationService locationService;

        public PageXmlExport_5(
            IPageFileWriter fileWriter,
            IExportDataProvider_5 dataProvider,
            ILocationService locationService)
        {
            this.fileWriter = fileWriter;
            this.dataProvider = dataProvider;
            this.locationService = locationService;
        }

        public bool ExportCustomerPage(string customerName)
        {
            PageXml content = new PageXml {Customer = new CustomerXml {Name = customerName}};

            IEnumerable<CustomerData> orders = dataProvider.GetCustomerOrders(customerName);

            // enrich content with orders
            // ..

            // enrich content with customer data
            // ..

            return fileWriter.WriteFile(content, "CustomerPage");
        }

        public bool ExportCustomerPageWithExternalData(
            string customerName,
            PageData externalData)

        {
            PageXml content = new PageXml {Customer = new CustomerXml {Name = customerName}};

            if (externalData.CustomerData != null)
            {
                // enrich with externalData.CustomerData 
                // ...
            }
            else
            {
                CustomerInfo customerData = dataProvider.GetCustomerInfo(content.Customer.Name);
            }

            IEnumerable<CustomerData> orders = dataProvider.GetCustomerOrders(customerName);

            // enrich content with orders
            // ...

            // enrich content by merging the external customer data with what read from DB
            // ...

            foreach (var address in content.Customer.Addresses)
            {
                Coordinates coordinates = locationService.GetCoordinates(address.City, address.Street, address.Number);
                if (coordinates != null)
                    address.Coordinates = string.Format("{0},{1}", coordinates.Latitude, coordinates.Longitude);
            }

            return fileWriter.WriteFile(content);
        }

        public bool ExportOrders(string customerName)
        {
            PageXml content = new PageXml {Customer = new CustomerXml {Name = customerName}};

            IEnumerable<CustomerData> orders = dataProvider.GetCustomerOrders(customerName);

            //enrich content with orders

            return fileWriter.WriteFile(content);
        }

        public IEnumerable<PageXml> GetPagesFromOrders(IEnumerable<Order> orders)
        {
            Dictionary<string, IEnumerable<Order>> customerOrders = GroupOrdersByCustomer(orders);
            foreach (var customerName in customerOrders.Keys)
            {
                PageXml content = new PageXml {Customer = new CustomerXml {Name = customerName}};

                CustomerInfo customerData = dataProvider.GetCustomerInfo(content.Customer.Name);
                //enrich with data from crm

                var recentOrders = customerOrders[customerName]
                    .OrderBy(o => o.OrderDate);
                foreach (var order in recentOrders)
                {
                    // enrich content with orders
                    // ...
                }

                foreach (var address in content.Customer.Addresses)
                {
                    Coordinates coordinates = locationService.GetCoordinates(address.City, address.Street, address.Number);
                    if (coordinates != null)
                        address.Coordinates = string.Format("{0},{1}", coordinates.Latitude, coordinates.Longitude);
                }

                yield return content;
            }
        }

        private Dictionary<string, IEnumerable<Order>> GroupOrdersByCustomer(IEnumerable<Order> orders)
        {
            // group orders by customer name and return them in a dictionary, ordered by OrderDate
            throw new NotImplementedException();
        }

        public bool ExportPagesFromOrders(IEnumerable<Order> orders)
        {
            IEnumerable<PageXml> pages = GetPagesFromOrders(orders);
            foreach (var pageXml in pages)
            {
                bool wasWritten = fileWriter.WriteFile(pageXml, "OrdersPage");
                if (!wasWritten)
                    return false;
            }
            return true;
        }
    }

    public interface IExportDataProvider_5
    {
        IEnumerable<CustomerData> GetCustomerOrders(string customerName);
        CustomerInfo GetCustomerInfo(string name);
    }
}