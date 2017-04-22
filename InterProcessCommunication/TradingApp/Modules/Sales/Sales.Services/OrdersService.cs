using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts.Quotations.Services;
using Contracts.Sales.Services;
using iQuarc.AppBoot;

namespace Sales.Services
{
    [Service(typeof(IOrdersService))]
    class OrderingService : IOrdersService
    {
        private readonly IQuotationService quotationService;
        private readonly IRepository repository;

        public OrderingService(IQuotationService quotationService, IRepository repository)
        {
            this.quotationService = quotationService;
            this.repository = repository;
        }

        public void PlaceSellLimitOrder(string securityCode, decimal sellingPrice, DateTime validUntil)
        {
            List<LimitOrder> limitOrders = new List<LimitOrder>();
            var todayQuotations = quotationService.GetQuotations(securityCode, DateTime.Today.AddDays(-1), DateTime.Today);
            foreach (var quotation in todayQuotations)
            {
                if (quotation.AskPrice >= sellingPrice)
                {
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

            repository.SaveAll(limitOrders);
        }

        public void PlaceBuyLimitOrder(string securityCode, decimal buyingPrice, DateTime validUntil)
        {
            List<LimitOrder> limitOrders= new List<LimitOrder>();
            var todayQuotations = quotationService.GetQuotations(securityCode, DateTime.Today.AddDays(-1), DateTime.Today);
            foreach (var quotation in todayQuotations)
            {
                if (quotation.BidPrice <= buyingPrice)
                {

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

            repository.SaveAll(limitOrders);
        }

        public LimitOrder[] GetLimitOrders()
        {
            return repository.GetEntities<LimitOrder>().ToArray();
        }
    }
}
