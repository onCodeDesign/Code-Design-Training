using System;
using System.Collections.Generic;
using System.Linq;
using iQuarc.AppBoot;
using iQuarc.SystemEx.Priority;

namespace LessonsSamples.Lesson6
{
    class ExpensesService : IExpensesService
    {
        private readonly IEnumerable<IExpenseProcessStep> steps;

        public ExpensesService(IExpenseProcessStep[] steps)
        {
            this.steps = steps.OrderByPriority();
        }

	    public void Process(ExpenseData expense)
	    {
		    using (ProcessContext contex = new ProcessContext())
		    {
			    foreach (var processStep in steps)
			    {
				    bool shouldContinue = processStep.Process(expense, contex);
				    if (!shouldContinue)
				    {
					    HandlePartialResult(contex);
				    }
			    }

			    HandleCompleteResult(contex, expense);
		    }
	    }

	    private void HandleCompleteResult(ProcessContext contex, ExpenseData expense)
        {
            
        }

        private void HandlePartialResult(ProcessContext contex)
        {
        }

        public void Approve(ExpenseData expense)
        {
        }
    }

    // A business object encapsulating the state of the running of an expense processing process
    //  It hides the state and gives meaningful functions to access and alter it 
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
        bool Process(ExpenseData expense, ProcessContext contex);
    }

    [Service("ProcessByExpenseTypeStep", typeof(IExpenseProcessStep))]
    [Priority(Priorities.High)]
    class ProcessByExpenseTypeStep : IExpenseProcessStep
    {
        public bool Process(ExpenseData expense, ProcessContext contex)
        {
            throw new NotImplementedException();
        }
    }

    [Service("ProcessesByAmmountStep", typeof(IExpenseProcessStep))]
    class ProcessesByAmmountStep : IExpenseProcessStep
    {
        public bool Process(ExpenseData expense, ProcessContext contex)
        {
            throw new NotImplementedException();
        }
    }


}