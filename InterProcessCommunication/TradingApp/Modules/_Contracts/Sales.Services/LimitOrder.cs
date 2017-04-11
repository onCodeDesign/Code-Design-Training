using System;

namespace Contracts.Sales.Services
{
    public class LimitOrder
    {
        public string SecurityCode { get; set; }
        public DateTime PlacedAt { get; set; }
        public OrderType Type { get; set; }
        public decimal Price { get; set; }

        public DateTime ValidUntil { get; set; }
    }

    public enum OrderType
    {
        Sell,
        Buy
    }
}