using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Contracts.Crm;
using Contracts.Location;
using Contracts.Sales;
using DataAccess;
using Export.DataModel;

namespace Export.Services.PageXmlDemo
{
    public class PageXmlExport_1
    {
        private readonly string fileNamePrefix;
        private readonly bool overwrite;
        private readonly int maxSalesOrders;
        private bool addCustomerDetails;

        public PageXmlExport_1(string fileNamePrefix, bool overwrite, int maxSalesOrders, bool addCustomerDetails)
        {
            this.fileNamePrefix = fileNamePrefix;
            this.overwrite = overwrite;
            this.maxSalesOrders = maxSalesOrders;
            this.addCustomerDetails = addCustomerDetails;
        }

        private const string exportFolder = "c:\temp";

        public bool ExportCustomerPage(string customerName)
        {
            string fileName = string.Format("{0}-{1}.xml", fileNamePrefix, customerName);
            string filePath = Path.Combine(exportFolder, fileName);

            if (!overwrite && File.Exists(filePath))
                return false;


            PageXml content = new PageXml { Customer = new CustomerXml { Name = customerName } };

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

                    // enrich content with customer data
                }
            }


            XmlSerializer serializer = new XmlSerializer(typeof (PageXml));
            using (StreamWriter sw = File.CreateText(filePath))
            {
                serializer.Serialize(sw, content);
            }
            return true;
        }

        public bool ExportCustomerPageWithExternalData(string customerName, PageData externalData, ICrmService crmService, ILocationService locationService)
        {
            string fileName = string.Format("{0}-{1}.xml", fileNamePrefix, customerName);
            string filePath = Path.Combine(exportFolder, fileName);

            if (!overwrite && File.Exists(filePath))
                return false;


            PageXml content = new PageXml {Customer = new CustomerXml {Name = customerName}};

            if (externalData.CustomerData != null)
            {
                // enrich with externalData.CustomerData 
            }
            else
            {
                CustomerInfo customerData = crmService.GetCustomerInfo(content.Customer.Name);
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

                    // enrich content with customer data
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

        public bool ExportOrders(int maxSalesOrders, string customerName)
        {
            string fileName = string.Format("CustomerOrders-{0}-{1}.xml", customerName, DateTime.Now);
            string filePath = Path.Combine(exportFolder, fileName);

            PageXml content = new PageXml { Customer = new CustomerXml { Name = customerName } };

            using (EfRepository repository = new EfRepository())
            {
                var orders = repository.GetEntities<Order>()
                                       .Where(o => o.Customer.CompanyName == content.Customer.Name)
                                       .OrderBy(o => o.OrderDate)
                                       .Take(maxSalesOrders);

                //enrich content with orders
            }

            XmlSerializer serializer = new XmlSerializer(typeof(PageXml));
            using (StreamWriter sw = File.CreateText(filePath))
            {
                serializer.Serialize(sw, content);
            }
            return true;
        }

        public bool ExportOrders(IEnumerable<Order> orders, string orderSet, ICrmService crmService, ILocationService locationService)
        {
            string fileName = string.Format("Orders-{0}-{1}.xml", orderSet, DateTime.Now);
            string filePath = Path.Combine(exportFolder, fileName);

            PageXml content = new PageXml { Customer = new CustomerXml() };

            //enrich content with orders

            XmlSerializer serializer = new XmlSerializer(typeof(PageXml));
            using (StreamWriter sw = File.CreateText(filePath))
            {
                serializer.Serialize(sw, content);
            }
            return true;
        }
    }
}