using System;
using System.Collections.Generic;
using System.Linq;
using Contracts.Portfolio.Services;
using Contracts.Quotations.Services;
using iQuarc.AppBoot;

namespace Portfolio.Services
{
    [Service(typeof(IPortfolioService))]
    public class PortfolioService : IPortfolioService
    {
        private readonly IQuotationService quotationService;

        public PortfolioService(IQuotationService quotationService)
        {
            this.quotationService = quotationService;
        }

        public decimal GetPortfolioValue()
        {
            var securities = GetCurrentUserSecurities().ToArray();
            DateTime to = DateTime.UtcNow;
            DateTime from = to.AddHours(-1);

            var quotes = quotationService.GetQuotations(securities, from, to);
            return quotes.Sum(q => q.BidPrice);
        }

        private IEnumerable<string> GetCurrentUserSecurities()
        {
            return new[] {"AAPL.B.NASDAQ", "MSFT.B.NASDAQ"};
        }
    }
}
