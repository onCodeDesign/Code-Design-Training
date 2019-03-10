using System.Collections.Generic;
using CommonServiceLocator;

namespace LessonsSamples.Lesson7.CohesionCoupling
{
    class PageXmlExportClient_3
    {
        public void ExportDataForCustomers(IEnumerable<string> customers)
        {
            ICrmService crmService = ServiceLocator.Current.GetInstance<ICrmService>();
            ILocationService locationService = ServiceLocator.Current.GetInstance<ILocationService>();
            IPageFileWriter pageWriter = ServiceLocator.Current.GetInstance<IPageFileWriter>();

            var exporter = new PageXmlExport_3(pageWriter, 10, true, crmService, locationService);

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