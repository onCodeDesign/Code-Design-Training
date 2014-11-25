using Contracts.Sales;
using iQuarc.AppBoot;
using Sales.DataModel;

namespace Sales
{
    public interface IPriceCalculator
    {
        decimal CalculateTaxes(OrderRequest o, Customer c);

        decimal CalculateDiscount(OrderRequest o, Customer c);
    }

    [Service(typeof (IPriceCalculator), Lifetime.Instance)]
    public class PriceCalculator : IPriceCalculator
    {
        public decimal CalculateTaxes(OrderRequest o, Customer c)
        {
            // do actual calculation
            return 10;
        }

        public decimal CalculateDiscount(OrderRequest o, Customer c)
        {
            // do actual calculation
            return 20;
        }
    }

    
}