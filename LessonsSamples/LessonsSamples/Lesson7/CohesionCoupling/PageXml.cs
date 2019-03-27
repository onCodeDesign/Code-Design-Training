using System.Collections.Generic;

namespace LessonsSamples.Lesson7.CohesionCoupling
{
    public class PageXml
    {
        public CustomerXml Customer { get; set; }

        //.... other properties that describe the XML format of a page w/ customer data
    }

    public class CustomerXml
    {
        public string Name { get; set; }
        public List<AddressXml> Addresses { get; set; }

        //.... other properties that describe the XML format of a customer
    }

    public class AddressXml
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Number { get; set; }
        public string Coordinates { get; set; }
    }
}