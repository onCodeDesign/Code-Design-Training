using System.Runtime.InteropServices.WindowsRuntime;

namespace LessonsSamples.Lesson7.InheritanceComposition
{
    static class AccountClientCode
    {
        public static decimal CalculateTotalMonthlyInterest(Account[] accounts)
        {
            decimal ammount = 0;
            for (int i = 0; i < accounts.Length; i++)
            {
                decimal interest = accounts[i].MonthlyInterest();

                if (accounts[i] is AutoLoanAccount)
                    interest = -1*interest;

                ammount += interest;
            }

            return ammount;
        }
    }


    class Account
    {
        private decimal ammount;
        private decimal interestRate;

        protected decimal CalculateLastMonthTaxes()
        {   // ...
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

            decimal lastMontProfit = CalculateLastMonthProfit();

            return taxes - lastMontProfit + MonthlyInterest();
        }

        private decimal CalculateLastMonthProfit()
        {
            throw new System.NotImplementedException();
        }
    }

    class CheckingAccount : Account
    {
        public decimal InvestmentBenefits()
        {
            decimal lastMonthTaxes = CalculateLastMonthTaxes();
            
            // ... 

            return 10;
        }
    }

    class AutoLoanAccount : Account
    {
        public override void MonthlyRenewal()
        {
            decimal monthlyTaxes = CalculateLastMonthTaxes(); 

            Ammount = Ammount - MonthlyInterest() - monthlyTaxes;
        }
    }
}