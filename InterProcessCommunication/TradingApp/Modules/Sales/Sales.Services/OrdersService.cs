using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Contracts.Quotations.Services;
using Contracts.Sales.Services;
using iQuarc.AppBoot;

namespace Sales.Services
{
    [Service(typeof(IOrdersService))]
    public class OrderingService : IOrdersService
    {
        private readonly IQuotationService quotationService;

        private readonly List<LimitOrder> limitOrders = new List<LimitOrder>();

        public OrderingService(IQuotationService quotationService)
        {
            this.quotationService = quotationService;
        }

        public void PlaceSellLimitOrder(string securityCode, decimal sellingPrice, DateTime validUntil)
        {
            var todayQuotations = quotationService.GetQuotations(securityCode, DateTime.Today.AddDays(-1), DateTime.Today);
            foreach (var quotation in todayQuotations)
            {
                if (quotation.AskPrice >= sellingPrice)
                    limitOrders.Add(new LimitOrder
                    {
                        SecurityCode = securityCode,
                        PlacedAt = DateTime.UtcNow,
                        Type = OrderType.Sell,
                        Price = sellingPrice,
                        ValidUntil = validUntil
                    });
            }
        }

        public void PlaceBuyLimitOrder(string securityCode, decimal buyingPrice, DateTime validUntil)
        {
            var todayQuotations = quotationService.GetQuotations(securityCode, DateTime.Today.AddDays(-1), DateTime.Today);
            foreach (var quotation in todayQuotations)
            {
                if (quotation.BidPrice <= buyingPrice)
                    limitOrders.Add(new LimitOrder
                    {
                        SecurityCode = securityCode,
                        PlacedAt = DateTime.UtcNow,
                        Type = OrderType.Buy,
                        Price = buyingPrice,
                        ValidUntil = validUntil
                    });
            }
        }

        public LimitOrder[] GetLimitOrders()
        {
            return limitOrders.ToArray();
        }
    }
}
