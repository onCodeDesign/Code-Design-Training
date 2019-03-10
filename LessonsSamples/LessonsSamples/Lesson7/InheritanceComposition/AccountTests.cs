using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LessonsSamples.Lesson7.InheritanceComposition
{
    [TestClass]
    public abstract class AccountContractTests
    {
        [TestMethod]
        public void MonthlyInterest_AmountIsPositive_InterestAppliedAsPercentage()
        {
            Account account = GetTarget(50);
            account.Amount = 100;

            decimal interest = account.MonthlyInterest();

            Assert.AreEqual(50m, interest);
        }

        protected abstract Account GetTarget(decimal interestRate);
    }

    [TestClass]
    public class SavingsAccountTests : AccountContractTests
    {
        protected override Account GetTarget(decimal interestRate)
        {
            return new SavingsAccount(interestRate);
        }
    }

    [TestClass]
    public class CheckingAccountTests : AccountContractTests
    {
        protected override Account GetTarget(decimal interestRate)
        {
            return new CheckingAccount(interestRate);
        }
    }

    [TestClass]
    public class AutoLoanAccountTests : AccountContractTests
    {
        protected override Account GetTarget(decimal interestRate)
        {
            return new AutoLoanAccount(interestRate);
        }
    }
}