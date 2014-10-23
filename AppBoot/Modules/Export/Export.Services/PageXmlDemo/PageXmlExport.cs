using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml.Serialization;
using Contracts.Crm;
using Contracts.Location;
using DataAccess;
using Export.DataModel;

namespace Export.Services.PageXmlDemo
{
    public class PageXmlExport
    {
        private const string exportFolder = "c:\temp";

        private readonly IRepository repository;

        public PageXmlExport(IRepository repository)
        {
            this.repository = repository;
        }

        public bool ExportCustomerPage(string fileNamePrefix, bool overwrite,
            string customerName, int maxSalesOrders, bool addCustomerDetails)
        {
            string fileName = string.Format("{0}-{1}.xml", fileNamePrefix, customerName);
            string filePath = Path.Combine(exportFolder, fileName);

            if (!overwrite && File.Exists(filePath))
                return false;


            PageXml content = new PageXml {Customer = new CustomerXml {Name = customerName}};

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


            XmlSerializer serializer = new XmlSerializer(typeof (PageXml));
            using (StreamWriter sw = File.CreateText(filePath))
            {
                serializer.Serialize(sw, content);
            }
            return true;
        }

        public bool ExportCustomerPageWithExternalData(string fileNamePrefix, bool overwrite,
            string customerName, int maxSalesOrders, bool addCustomerDetails,
            PageData externalData, ICrmService crmService, ILocationService locationService)
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

            PageXml content = new PageXml {Customer = new CustomerXml {Name = customerName}};

            var orders = repository.GetEntities<Order>()
                                   .Where(o => o.Customer.CompanyName == content.Customer.Name)
                                   .OrderBy(o => o.OrderDate)
                                   .Take(maxSalesOrders);

            //enrich content with orders

            XmlSerializer serializer = new XmlSerializer(typeof (PageXml));
            using (StreamWriter sw = File.CreateText(filePath))
            {
                serializer.Serialize(sw, content);
            }
            return true;
        }

        public PageXml GetPageForOrders(IEnumerable<Order> orders, ICrmService crmService, ILocationService locationService)
        {
            string customerName = GetCustomerNameFromFirstOrder();

            PageXml content = new PageXml {Customer = new CustomerXml {Name = customerName}};

            if (crmService != null)
            {
                CustomerInfo customerData = crmService.GetCustomerInfo(content.Customer.Name);
                //enrich with data from crm
            }

            //enrich content with orders

            if (locationService != null)
            {
                foreach (var address in content.Customer.Addresses)
                {
                    Coordinates coordinates = locationService.GetCoordinates(address.City, address.Street, address.Number);
                    if (coordinates != null)
                        address.Coordinates = string.Format("{0},{1}", coordinates.Latitude, coordinates.Longitude);
                }
            }

            return content;
        }

        private string GetCustomerNameFromFirstOrder()
        {
            throw new NotImplementedException();
        }

        #region Old Samle

        //    public void ExportOrders(IEnumerable<Order> orders, ICrmService crmService, ILocationService locationService)
        //    {
        //        string currentCustomer = string.Empty;
        //        string curretFilePath = string.Empty;
        //        PageXml currentPage = null;

        //        foreach (var order in orders.OrderBy(o => o.Customer.Name))
        //        {
        //            if (currentCustomer != order.Customer.Name)
        //            {
        //                if (currentPage != null)
        //                {
        //                    XmlSerializer serializer = new XmlSerializer(typeof (PageXml));
        //                    using (StreamWriter sw = File.CreateText(curretFilePath))
        //                    {
        //                        serializer.Serialize(sw, currentPage);
        //                    }
        //                }

        //                string fileName = string.Format("CustomerOrders-{0}-{1}.xml", currentCustomer, DateTime.Now);
        //                curretFilePath = Path.Combine(exportFolder, fileName);
        //                currentPage = new PageXml {Customer = new CustomerXml {Name = currentCustomer}};
        //            }

        //            AddOrderToPage(currentPage, order);
        //        }
        //    }

        //    private void AddOrdersToPage(PageXml page, IEnumerable<Order> orders)
        //    {
        //        foreach (var o in orders)
        //        {
        //            AddOrderToPage(page, o);
        //        }
        //    }

        //    private void AddOrderToPage(PageXml currentPage, Order order)
        //    {
        //        //TODO: implement this
        //    }

        #endregion
    }
}