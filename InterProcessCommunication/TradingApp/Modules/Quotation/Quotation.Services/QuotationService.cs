using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;

namespace Quotation.Services
{
    public class QuotationService : IQuotationService
    {
        public IObservable<Contracts.Quotation> GetQuotations(string exchange, string instrument)
        {
            throw new NotImplementedException();
        }
    }
}
