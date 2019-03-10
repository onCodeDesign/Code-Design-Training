namespace LessonsSamples.Lesson7.InheritanceComposition
{
    static class AccountClientCode
    {
        public static decimal CalculateTotalInterestValue(Account[] accounts)
        {
            decimal amount = 0;
            for (int i = 0; i < accounts.Length; i++)
            {
                decimal interest = accounts[i].MonthlyInterest();

                if (accounts[i] is AutoLoanAccount)
                    interest = -1*interest;

                amount += interest;
            }

            return amount;
        }
    }
}