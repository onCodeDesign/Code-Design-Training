using System.Collections.Generic;
using System.Web.Http;
using Contracts.Quotations.Services;

namespace ConsoleHost.Controllers
{
    public class QuotationController : ApiController
    {
        private readonly Quotation[] array =
        {
            new Quotation {AskPrice = 10.50m, BidPrice = 10.55m, SecurityCode = "ING.S.NYSE"},
            new Quotation {AskPrice = 12.50m, BidPrice = 12.55m, SecurityCode = "ING.B.NYSE"},
            new Quotation {AskPrice = 10.70m, BidPrice = 10.75m, SecurityCode = "AAPL.B.NASDAQ"},
            new Quotation {AskPrice = 11.50m, BidPrice = 11.55m, SecurityCode = "AAPL.S.NASDAQ"},
            new Quotation {AskPrice = 16.50m, BidPrice = 16.55m, SecurityCode = "MSFT.B.NASDAQ"},
            new Quotation {AskPrice = 17.50m, BidPrice = 17.55m, SecurityCode = "ING.B.AEX"},
            new Quotation {AskPrice = 10.51m, BidPrice = 10.59m, SecurityCode = "ING.S.AEX"},
        };

        public IEnumerable<Quotation> GetQuotations()
        {
            return array;
        }
    }
}
