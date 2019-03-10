using System.Collections.Generic;
using CommonServiceLocator;

namespace LessonsSamples.Lesson7.CohesionCoupling
{
    class PageXmlExportClient_1
    {
        public void ExportDataForCustomers(IEnumerable<string> customers)
        {
            var exporter = new PageXmlExport_1("{0}_{1}_{2}", true, 10, true);

            foreach (var customer in customers)
            {
                exporter.ExportCustomerPage(customer);
            }
        }
    }

    class PageXmlExportClient_12
    {
        public void ExportDataForCustomers(IEnumerable<string> customers)
        {
            var exporter = new PageXmlExport_1("{0}_{1}_{2}", true, 10, true);
            ICrmService crmService = ServiceLocator.Current.GetInstance<ICrmService>();
            ILocationService locationService = ServiceLocator.Current.GetInstance<ILocationService>();

            foreach (var customer in customers)
            {
                PageData userInput = GetUserInput(customer);
                exporter.ExportCustomerPageWithExternalData(customer, userInput, crmService, locationService);
            }
        }

        private PageData GetUserInput(string customer)
        {
            // TODO: take this data from a view model
            return new PageData();
        }
    }
}