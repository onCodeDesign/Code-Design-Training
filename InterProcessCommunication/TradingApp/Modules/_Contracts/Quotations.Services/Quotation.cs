using System;

namespace Contracts.Quotations.Services
{
    public class Quotation
    {
        public DateTime Timestamp { get; set; }
        public decimal BidPrice { get; set; }
        public decimal AskPrice { get; set; }
        public string SecurityCode { get; set; }
    }
}