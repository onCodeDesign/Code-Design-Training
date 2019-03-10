using System.Collections.Generic;

namespace LessonsSamples.Lesson7.CohesionCoupling
{
    class PageXmlExportClient
    {
        public void Func(IEnumerable<string> customers)
        {
            var exporter = new PageXmlExport();

            foreach (var customer in customers)
            {
                exporter.ExportCustomerPage("{0}_{1}_{2}", true, customer, 10, true);
            }
        }
    }
}