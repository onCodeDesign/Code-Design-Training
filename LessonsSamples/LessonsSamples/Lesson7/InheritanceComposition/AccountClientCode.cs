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
}