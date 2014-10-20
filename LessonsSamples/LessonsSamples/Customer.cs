using System;
using System.Collections.Generic;

namespace LessonsSamples
{
    public class Customer
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        ICollection<Customer> Cusotmers { get; set; } 
    }

    public class Order
    {
        public string Description { get; set; }
        public Customer Customer { get; set; }
        public DateTime PlaceAt { get; set; }
    }

    public class Address
    {
        public string Streat { get; set; }
        public string Number { get; set; }
    }
}