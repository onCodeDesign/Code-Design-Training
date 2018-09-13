using System;
using System.Collections.Generic;
using System.Linq;

namespace LessonsSamples.Lesson6.Expenses
{
    class ExpensesService : IExpensesService
    {
        private readonly IExpenseProcessStep[] steps;

        public ExpensesService(IExpenseProcessStep[] steps)
        {
            this.steps = steps;
        }

	    public void Process(ExpenseData expense)
	    {
		    using (ProcessContext context = new ProcessContext())
		    {
			    foreach (var processStep in steps)
			    {
				    bool shouldContinue = processStep.Process(expense, context);
				    if (!shouldContinue)
				    {
					    HandlePartialResult(context);
				    }
			    }

			    HandleCompleteResult(context, expense);
		    }
	    }

	    private void HandleCompleteResult(ProcessContext context, ExpenseData expense)
        {
            
        }

        private void HandlePartialResult(ProcessContext context)
        {
        }

        public void Approve(ExpenseData expense)
        {
        }
    }

    // A business object encapsulating the state of the running of an expense processing process
    //  It hides its inner state and gives meaningful functions to access and alter it 
    class ProcessContext : IDisposable
    {
        private readonly List<ExpenseData> additionalExpenses = new List<ExpenseData>(); 

        public void AdditionalExpenses(ExpenseData additional)
        {
            // ...
            additionalExpenses.Add(additional);
        }

        public decimal GetAdditionalAmount()
        {
            return additionalExpenses.Sum(data => data.Amount);
        }

        public void Dispose()
        {
            ProcessFinished();
        }

        private void ProcessFinished()
        {
        }
    }

    interface IExpenseProcessStep
    {
        bool Process(ExpenseData expense, ProcessContext context);
    }
}