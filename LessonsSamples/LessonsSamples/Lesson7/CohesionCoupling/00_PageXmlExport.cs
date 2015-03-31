using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;

namespace LessonsSamples.Lesson7.CohesionCoupling
{
    // Initial class
    //  - Refactor in small steps. Start by looking at functions parameters

    public class PageXmlExport
    {
        private const string exportFolder = "c:\temp";

        public bool ExportCustomerPage(
            string fileNameFormat,
            bool overwrite,
            string customerName,
            int maxSalesOrders,
            bool addCustomerDetails)
        {
            string fileName = string.Format(fileNameFormat, "CustomerPage", customerName, DateTime.Now);
            string filePath = Path.Combine(exportFolder, fileName);

            if (!overwrite && File.Exists(filePath))
                return false;


            PageXml content = new PageXml {Customer = new CustomerXml {Name = customerName}};

            using (EfRepository repository = new EfRepository())
            {
                if (maxSalesOrders > 0)
                {
                    var orders = repository.GetEntities<Order>()
                                           .Where(o => o.Customer.CompanyName == customerName)
                                           .OrderBy(o => o.OrderDate)
                                           .Take(maxSalesOrders);

                    //enrich content with orders
                    // ...
                }

                if (addCustomerDetails)
                {
                    var customer = repository.GetEntities<Customer>()
                                             .Where(c => c.CompanyName == customerName);

                    // enrich content with customer data
                    // ...
                }
            }


            XmlSerializer serializer = new XmlSerializer(typeof (PageXml));
            using (StreamWriter sw = File.CreateText(filePath))
            {
                serializer.Serialize(sw, content);
            }
            return true;
        }

        public bool ExportCustomerPageWithExternalData(
            string fileNameFormat,
            bool overwrite,
            string customerName,
            int maxSalesOrders,
            bool addCustomerDetails,
            PageData externalData,
            ICrmService crmService,
            ILocationService locationService)
        {
            string fileName = string.Format(fileNameFormat, "CustomerPage", customerName, DateTime.Now);
            string filePath = Path.Combine(exportFolder, fileName);

            if (!overwrite && File.Exists(filePath))
                return false;


            PageXml content = new PageXml {Customer = new CustomerXml {Name = customerName}};

            if (externalData.CustomerData != null)
            {
                // enrich with externalData.CustomerData 
                // ...
            }
            else
            {
                CustomerInfo customerData = crmService.GetCustomerInfo(content.Customer.Name);

                // enrich content with customer data
                // ...
            }

            using (EfRepository repository = new EfRepository())
            {
                if (maxSalesOrders > 0)
                {
                    var orders = repository.GetEntities<Order>()
                                           .Where(o => o.Customer.CompanyName == content.Customer.Name)
                                           .OrderBy(o => o.OrderDate)
                                           .Take(maxSalesOrders);

                    //enrich content with orders
                }

                if (addCustomerDetails)
                {
                    var customer = repository.GetEntities<Customer>()
                                             .Where(c => c.CompanyName == customerName);

                    // enrich content by merging the external customer data with what read from DB
                    // ...
                }
            }

            if (locationService != null)
            {
                foreach (var address in content.Customer.Addresses)
                {
                    Coordinates coordinates = locationService.GetCoordinates(address.City, address.Street, address.Number);
                    if (coordinates != null)
                        address.Coordinates = string.Format("{0},{1}", coordinates.Latitude, coordinates.Longitude);
                }
            }


            XmlSerializer serializer = new XmlSerializer(typeof (PageXml));
            using (StreamWriter sw = File.CreateText(filePath))
            {
                serializer.Serialize(sw, content);
            }
            return true;
        }

        public bool ExportOrders(
			string fileNameFormat, 
			bool overwrite, 
			string customerName)
        {
            string fileName = string.Format(fileNameFormat, "CustomerOrdersPage", customerName, DateTime.Now);
            string filePath = Path.Combine(exportFolder, fileName);

            if (!overwrite && File.Exists(filePath))
                return false;

            PageXml content = new PageXml {Customer = new CustomerXml {Name = customerName}};

            using (EfRepository repository = new EfRepository())
            {
                var orders = repository.GetEntities<Order>()
                                       .Where(o => o.Customer.CompanyName == content.Customer.Name)
                                       .OrderBy(o => o.ApprovedAmmount)
                                       .ThenBy(o => o.OrderDate);

                //enrich content with orders
            }

            XmlSerializer serializer = new XmlSerializer(typeof (PageXml));
            using (StreamWriter sw = File.CreateText(filePath))
            {
                serializer.Serialize(sw, content);
            }
            return true;
        }

        public IEnumerable<PageXml> GetPagesFromOrders(
			IEnumerable<Order> orders,
            int maxSalesOrders,
            ICrmService crmService,
            ILocationService locationService)
        {
            Dictionary<string, IEnumerable<Order>> customerOrders = GroupOrdersByCustomer(orders);
            foreach (var customerName in customerOrders.Keys)
            {
                PageXml content = new PageXml {Customer = new CustomerXml {Name = customerName}};

                if (crmService != null)
                {
                    CustomerInfo customerData = crmService.GetCustomerInfo(content.Customer.Name);
                    //enrich with data from crm
                }

                var recentOrders = customerOrders[customerName]
                    .OrderBy(o => o.OrderDate)
                    .Take(maxSalesOrders);
                foreach (var order in recentOrders)
                {
                    // enrich content with orders
                    // ...
                }

                if (locationService != null)
                {
                    foreach (var address in content.Customer.Addresses)
                    {
                        Coordinates coordinates = locationService.GetCoordinates(address.City, address.Street, address.Number);
                        if (coordinates != null)
                            address.Coordinates = string.Format("{0},{1}", coordinates.Latitude, coordinates.Longitude);
                    }
                }

                yield return content;
            }
        }

        public bool ExportPagesFromOrders(string fileNameFormat,
            bool overwrite,
            IEnumerable<Order> orders,
            int maxSalesOrders,
            ICrmService crmService,
            ILocationService locationService)
        {
            IEnumerable<PageXml> pages = GetPagesFromOrders(orders, maxSalesOrders, crmService, locationService);
            foreach (var pageXml in pages)
            {
                string customerName = pageXml.Customer.Name;
                string fileName = string.Format(fileNameFormat, "CustomerOrdersPage", customerName, DateTime.Now);
                string filePath = Path.Combine(exportFolder, fileName);
                if (!overwrite && File.Exists(filePath))
                    return false;

                XmlSerializer serializer = new XmlSerializer(typeof (PageXml));
                using (StreamWriter sw = File.CreateText(filePath))
                {
                    serializer.Serialize(sw, pageXml);
                }
            }
            return true;
        }

        private Dictionary<string, IEnumerable<Order>> GroupOrdersByCustomer(IEnumerable<Order> orders)
        {
            // group orders by customer name and return them in a dictionary, ordered by OrderDate
            throw new NotImplementedException();
        }
    }
}