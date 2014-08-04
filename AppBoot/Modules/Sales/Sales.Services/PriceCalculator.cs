using Sales.DataModel;
using Seido.AppBoot;

namespace Sales
{
    public interface IPriceCalculator
    {
        decimal CalculateTaxes(SalesOrderHeader o, Customer c);

        decimal CalculateDiscount(SalesOrderHeader o, Customer c);
    }

    [Service(typeof (IPriceCalculator), Lifetime.Instance)]
    public class PriceCalculator : IPriceCalculator
    {
        public decimal CalculateTaxes(SalesOrderHeader o, Customer c)
        {
            // do actual calculation
            return 10;
        }

        public decimal CalculateDiscount(SalesOrderHeader o, Customer c)
        {
            // do actual calculation
            return 20;
        }
    }

    
}