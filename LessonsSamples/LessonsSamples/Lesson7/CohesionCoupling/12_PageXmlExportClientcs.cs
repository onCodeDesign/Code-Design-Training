using System.Collections.Generic;
using CommonServiceLocator;

namespace LessonsSamples.Lesson7.CohesionCoupling
{
    class PageXmlExportClient_2
    {
        public void ExportDataForCustomers(IEnumerable<string> customers)
        {
            ICrmService crmService = ServiceLocator.Current.GetInstance<ICrmService>();
            ILocationService locationService = ServiceLocator.Current.GetInstance<ILocationService>();
            var exporter = new PageXmlExport_2("{0}_{1}_{2}", true, 10, true, crmService, locationService);

            foreach (var customer in customers)
            {
                PageData userInput = GetUserInput(customer);
                exporter.ExportCustomerPageWithExternalData(customer, userInput);
            }
        }

        private PageData GetUserInput(string customer)
        {
            // TODO: take this data from a view model
            return new PageData();
        }
    }
}