using System;
using System.Collections.Generic;
using ClassLibrary1;

namespace LessonsSamples.Lesson3.DataModel
{
    public partial class SalesOrderHeader
    {
        public SalesOrderHeader()
        {
            this.SalesOrderDetails = new HashSet<SalesOrderDetail>();
        }

        public int Id { get; set; }
        public decimal SubTotal { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal TotalDue { get; set; }
        public string Comment { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<SalesOrderDetail> SalesOrderDetails { get; set; }
        public virtual SalesPerson SalesPerson { get; set; }
        public virtual SalesTerritory SalesTerritory { get; set; }
    }

    public partial class SalesOrderHeader
    {
        public bool Validate()
        {
            if (TotalDue > SubTotal)
                return false;

            if (IsTerritoryWithTaxes(SalesTerritory) && TaxAmt < 0)
            {
                TaxAmt = CalculateDefaultTaxes();
            }

            return true;
        }

        private decimal CalculateDefaultTaxes()
        {
            throw new NotImplementedException();
        }

        private bool IsTerritoryWithTaxes(SalesTerritory salesTerritory)
        {
            throw new NotImplementedException();
        }
    }

    public class SalesOrderDetail
    {
    }

    public class SalesPerson
    {
        public string Name { get; set; }
    }

    public class SalesTerritory
    {
    }
}