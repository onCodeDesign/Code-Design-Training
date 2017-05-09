using System;

namespace Contracts.Quotations.Services
{
    public interface IQuotationService
    {
        Quotation[] GetQuotations(string exchange, string instrument, DateTime from, DateTime to);
        Quotation[] GetQuotations(string securityCode, DateTime from, DateTime to);
        Quotation[] GetQuotations(string[] securities, DateTime from, DateTime to);
    }
}
