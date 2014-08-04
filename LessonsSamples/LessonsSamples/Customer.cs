using System;
using System.Collections.Generic;

namespace ClassLibrary1
{
    class Customer
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        ICollection<Customer> Cusotmers { get; set; } 
    }

    class Order
    {
        public string Description { get; set; }
        public Customer Customer { get; set; }
        public DateTime PlaceAt { get; set; }
    }

    class Address
    {
        public string Streat { get; set; }
        public string Number { get; set; }
    }
}