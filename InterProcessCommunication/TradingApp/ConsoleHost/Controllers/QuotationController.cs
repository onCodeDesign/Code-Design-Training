using System;
using System.Collections.Generic;
using System.Web.Http;
using Contracts.Quotations.Services;

namespace ConsoleHost.Controllers
{
    public class QuotationController : ApiController
    {
        private readonly IQuotationService quotationService;
        public QuotationController(IQuotationService quotationService)
        {
            this.quotationService = quotationService;
        }

        public IEnumerable<Quotation> GetByExchange(string exchange, string instrument, DateTime @from, DateTime to)
        {
            return quotationService.GetQuotations(exchange, instrument, from, to);
        }

        public IEnumerable<Quotation> GetBySecurity([FromUri] string securityCode, [FromUri] DateTime from, [FromUri] DateTime to)
        {
            return quotationService.GetQuotations(securityCode, from, to);
        }

        public IEnumerable<Quotation> GetBySecurities([FromUri] string[] securities, [FromUri] DateTime from, [FromUri] DateTime to)
        {
            return quotationService.GetQuotations(securities, from, to);
        }
    }
}