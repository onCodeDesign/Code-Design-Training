using System.Collections.Generic;

namespace Export.Services.PageXmlDemo
{
    public class PageXml
    {
        public CustomerXml Customer { get; set; }
    }

    public class CustomerXml
    {
        public string Name { get; set; }
        public List<AddressXml> Addresses { get; set; }
    }

    public class AddressXml
    {
        public string Street { get; set; }
        public string City { get; set; }
        public string Number { get; set; }
        public string Coordinates { get; set; }
    }
}