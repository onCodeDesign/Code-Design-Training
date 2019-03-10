using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LessonsSamples.Lesson7.InheritanceComposition
{
    [TestClass]
    public class AccountClientCodeTests
    {
        [TestMethod]
        public void CalculateTotalInterestValue_MoreAccounts_InterestSummedFromAll()
        {
            Account[] accounts =
            {
                new Account(50) {Amount = 1},   //+0.5
                new Account(50) {Amount = 1},   //+0.5
                new Account(50) {Amount = 1},   //+0.5
            };
            decimal actualInterest = AccountClientCode.CalculateTotalInterestValue(accounts);

            Assert.AreEqual(1.5m, actualInterest);
        }

        [TestMethod]
        public void CalculateTotalInterestValue_AllAccountTypes_InterestSummedFromAll()
        {
            Account[] accounts =
            {
                new SavingsAccount(50) {Amount = 1},   //+0.5
                new CheckingAccount(50) {Amount = 1},  //+0.5
                new AutoLoanAccount(50) {Amount = 1},  //-0.5
            };
            decimal actualInterest = AccountClientCode.CalculateTotalInterestValue(accounts);

            Assert.AreEqual(0.5m, actualInterest);
        }
    }
}