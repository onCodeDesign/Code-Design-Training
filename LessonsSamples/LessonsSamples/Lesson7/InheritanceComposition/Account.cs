using System;

namespace LessonsSamples.Lesson7.InheritanceComposition
{
    class Account
    {
        private decimal amount;
        private decimal interestRate;

        protected decimal CalculateTaxesForMoth(Month month)
		{
            // ...
            return 100;
        }

        public decimal Amount
        {
            get { return amount; }
            protected set { amount = value; }
        }

        public decimal MonthlyInterest()
        {
            return amount*interestRate/100;
        }

        public virtual void MonthlyRenewal()
        {
			decimal interest = MonthlyInterest();
	        decimal taxes = CalculateTaxesForMoth(CurrentMonth);

	        amount = amount + interest - taxes;
        }

	    public Month CurrentMonth { get; set; }
    }

	class SavingsAccount : Account
    {
        public decimal YearlyProfit()
        {
			// ... 
	        decimal taxes = 0;
			Month moth = new Month();
			
            // for each month
				taxes += CalculateTaxesForMoth(moth);

	        decimal deposits = CalculateYearlyDeposits();
            // ... 

            return Amount - deposits - taxes + MonthlyInterest();
        }

        private decimal CalculateYearlyDeposits()
        {
            throw new NotImplementedException();
        }
    }

    class CheckingAccount : Account
    {
        public decimal TransactionsCosts()
        {
			// ... 
			Month lastMonth = new Month();
			var lastMonthTaxes = CalculateTaxesForMoth(lastMonth);
			decimal lastMonthCommissions = CalculateLastMonthCommision();
            // ... 

            return lastMonthCommissions + lastMonthTaxes;
        }

        private decimal CalculateLastMonthCommision()
        {
            throw new NotImplementedException();
        }
    }

    class AutoLoanAccount : Account
    {
        public override void MonthlyRenewal()
        {
	        decimal interest = MonthlyInterest();
	        decimal taxes = CalculateTaxesForMoth(CurrentMonth);

	        Amount = Amount - interest - taxes;
        }

        public decimal TotalPayments()
        {
            throw new NotImplementedException();
        }
    }
}