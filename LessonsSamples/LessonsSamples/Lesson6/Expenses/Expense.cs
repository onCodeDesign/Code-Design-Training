using System;
using System.Collections.Generic;
using System.Data;

namespace LessonsSamples.Lesson6
{
    public interface IExpensesFeedReader
    {
        ExpenseData LoadExpenses(IEnumerable<MoneySpendingsData> spendings);
    }

    class ExpensesFeedReader : IExpensesFeedReader
    {
        public ExpenseData LoadExpenses(IEnumerable<MoneySpendingsData> spendings)
        {
            Expense expense = new Expense();

            foreach (var spending in spendings)
            {
                if (IsMarketingExpense(spending))
                    expense.AddMarketingExpense(spending.Amount);

                //...
            }


            return expense.GetExpenses(); // this may be more complex
        }

        private bool IsMarketingExpense(MoneySpendingsData spending)
        {
            throw new NotImplementedException();
        }
    }

    // Business object encapsulating the logic of calculating an expense
    class Expense
    {
        public void AddMarketingExpense(decimal amount)
        {
            // the state of the object is modified by the calculations of adding a marketing expense
        }

        public void AddSalesExpense(decimal amount, int inquiryId)
        {
        }

        public void AddTravelExpense(decimal amount, DateTime date)
        {
            
        }

        public ExpenseData GetExpenses()
        {
            return new ExpenseData();
        }
    }

    public class MoneySpendingsData
    {
        public decimal Amount { get; set; }
    }
}