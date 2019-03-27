using System;

namespace LessonsSamples.Lesson7.InheritanceComposition
{
    public class Account
    {
        private decimal amount;
        private readonly decimal interestRate;

        public Account(decimal interestRate)
        {
            this.interestRate = interestRate;
        }

        protected decimal CalculateTaxesForMoth(Month month)
		{
            // ...
            return 100;
        }

        public decimal Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        public decimal MonthlyInterest()
        {
            return amount*interestRate/100;
        }

        public virtual void MonthlyRenewal(Month currentMonth)
        {
			decimal interest = MonthlyInterest();
	        decimal taxes = CalculateTaxesForMoth(currentMonth);

	        amount = amount + interest - taxes;
        }
    }

	class SavingsAccount : Account
    {
        public SavingsAccount(decimal interestRate) : base(interestRate)
        {
        }

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
        public CheckingAccount(decimal interestRate) : base(interestRate)
        {
        }

        public decimal TransactionsCosts()
        {
			// ... 
			Month lastMonth = new Month();
			var lastMonthTaxes = CalculateTaxesForMoth(lastMonth);
			decimal lastMonthBankCharges = CalculateLastMonthBankCharges();
            // ... 

            return lastMonthBankCharges + lastMonthTaxes;
        }

        private decimal CalculateLastMonthBankCharges()
        {
            throw new NotImplementedException();
        }
    }

    class AutoLoanAccount : Account
    {
        public AutoLoanAccount(decimal interestRate) : base(interestRate)
        {
        }

        public override void MonthlyRenewal(Month currentMonth)
        {
	        decimal interest = MonthlyInterest();
	        decimal taxes = CalculateTaxesForMoth(currentMonth);

	        Amount = Amount - interest - taxes;
        }

        public decimal TotalPayments()
        {
            throw new NotImplementedException();
        }
    }
}