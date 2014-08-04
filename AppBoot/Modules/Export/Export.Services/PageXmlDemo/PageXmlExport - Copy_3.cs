using System;
using System.Collections.Generic;
using Contracts.Crm;
using Contracts.Location;
using Export.DataModel;

namespace Export.Services.PageXmlDemo
{
    public class PageXmlExport_3
    {
        private readonly IPageFileWriter fileWriter;
        private readonly IExportDataProvider dataProvider;


        public PageXmlExport_3(IPageFileWriter fileWriter, IExportDataProvider dataProvider)
        {
            this.fileWriter = fileWriter;
            this.dataProvider = dataProvider;
        }

        private const string exportFolder = "c:\temp";

        public bool ExportCustomerPage(string customerName)
        {
            PageXml content = new PageXml {Customer = new CustomerXml {Name = customerName}};

            IEnumerable<CustomerData> orders = dataProvider.GetCustomerOrders(customerName);

            // enrich content with orders

            // enrich content with customer data

            return fileWriter.WriteFile(content);
        }

        public bool ExportCustomerPageWithExternalData(string customerName, PageData externalData, ICrmService crmService, ILocationService locationService)
        {
            PageXml content = new PageXml {Customer = new CustomerXml {Name = customerName}};

            if (externalData.CustomerData != null)
            {
                // enrich with externalData.CustomerData 
            }
            else
            {
                CustomerInfo customerData = crmService.GetCustomerInfo(content.Customer.Name);
            }

            IEnumerable<CustomerData> orders = dataProvider.GetCustomerOrders(customerName);

            // enrich content with orders

            // enrich content with customer data

            if (locationService != null)
            {
                foreach (var address in content.Customer.Addresses)
                {
                    Coordinates coordinates = locationService.GetCoordinates(address.City, address.Street, address.Number);
                    if (coordinates != null)
                        address.Coordinates = string.Format("{0},{1}", coordinates.Latitude, coordinates.Longitude);
                }
            }

            return fileWriter.WriteFile(content);
        }

        public bool ExportOrders(string customerName)
        {
            PageXml content = new PageXml {Customer = new CustomerXml {Name = customerName}};

            IEnumerable<CustomerData> orders = dataProvider.GetCustomerOrders(customerName);

            // enrich content with orders

            return fileWriter.WriteFile(content);
        }

        public PageXml ExportOrders(IEnumerable<Order> orders, ICrmService crmService, ILocationService locationService)
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

        public interface IExportDataProvider
        {
            IEnumerable<CustomerData> GetCustomerOrders(string customerName);
        }
    }
}