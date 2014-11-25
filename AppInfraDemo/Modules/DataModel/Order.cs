using System;

namespace DataModel
{
    public class Order
    {
        public Customer Customer { get; set; }
        public DateTime Date { get; set; }
    }
}