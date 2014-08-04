using Contracts.Sales;
using Sales.DataModel;
using Seido.AppBoot;

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