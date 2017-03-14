using System;
using System.Collections.Generic;

namespace LessonsSamples
{
    public class Customer
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        ICollection<Order> Orders { get; set; }
        public string CompanyName { get; set; }
        public int AreadID { get; set; }
    }

    public class Order
    {
        public int ID { get; set; }
        public string Description { get; set; }
        public Customer Customer { get; set; }
        public decimal ApprovedAmmount { get; set; }
        public DateTime OrderDate { get; set; }
        public ICollection<OrderLine> OrderLines { get; set; }
    }

    public class OrderLine
    {
        public int OrderID;
        public Product Product { get; set; }   
    }

    public class Product
    {
        public Producer Producer { get; set; }
    }

    public class Producer
    {
        public int AreaID;
    }

    internal class SalesArea
    {
        public string CountryCode { get; set; }
    }

    public class Address
    {
	    public int CountryID;
	    public string Street { get; set; }
        public string Number { get; set; }
	    public string PostCode { get; set; }
	    public string City { get; set; }
    }
}