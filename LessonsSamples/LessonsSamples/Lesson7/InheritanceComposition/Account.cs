using System;

namespace LessonsSamples.Lesson7.InheritanceComposition
{
    class Account
    {
        private decimal ammount;
        private decimal interestRate;

        protected decimal CalculateLastMonthTaxes()
        {
            // ...
            return 100;
        }

        public decimal Ammount
        {
            get { return ammount; }
            protected set { ammount = value; }
        }

        public decimal MonthlyInterest()
        {
            return ammount*interestRate/100;
        }

        public virtual void MonthlyRenewal()
        {
            ammount = ammount + MonthlyInterest() - CalculateLastMonthTaxes();
        }
    }

    class SavingsAccount : Account
    {
        public decimal YearlyProfit()
        {
            // ... 
            decimal taxes = CalculateLastMonthTaxes();
            decimal deposits = CalculateYearlyDeposits();
            // ... 

            return Ammount - deposits - taxes + MonthlyInterest();
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
            decimal lastMonthTaxes = CalculateLastMonthTaxes();
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
            decimal taxes = CalculateLastMonthTaxes();
	        decimal interest = MonthlyInterest();
			decimal deposits = MonthlyDepozits();
	        decimal withdrawals = MontlyWithdrawals();

	        Ammount = Ammount - interest + deposits - withdrawals - taxes;
        }

        private decimal MonthlyDepozits()
        {
            throw new NotImplementedException();
        }

	    private decimal MontlyWithdrawals()
	    {
		    throw new NotImplementedException();
	    }

        public decimal TotalPayments()
        {
            throw new NotImplementedException();
        }
    }
}