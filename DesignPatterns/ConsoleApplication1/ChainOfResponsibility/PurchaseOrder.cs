using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1.ChainOfResponsibility
{
    public class PurchaseOrder
    {
        public PurchaseOrder(int number, double amount, string assets)
        {
            Number = number;
            Amount = amount;
            Assets = assets;
        }

        public int Number { get; set; }
        public double Amount { get; set; }
        public string Assets { get; set; }
    }
}
