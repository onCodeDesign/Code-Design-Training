using System;
using System.Collections.Generic;
using System.Linq;

namespace LessonsSamples.Lesson6
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
            using (ProcessContext contex = new ProcessContext(expense))
            {
                foreach (var processStep in steps)
                {
                    bool shouldContinue = processStep.Process(expense, contex);
                    if (!shouldContinue)
                    {
                        HandlePartialResult(contex);
                    }
                }
            }
            HandleCompleteResult(expense);
        }

        private void HandleCompleteResult(ExpenseData expense)
        {
        }

        private void HandlePartialResult(ProcessContext contex)
        {
        }

        public void Approve(ExpenseData expense)
        {
        }
    }

    // a business object encapsulating the logic and state of running a expense processing process
    class ProcessContext : IDisposable
    {
        private readonly ExpenseData expense;
        private readonly List<ExpenseData> additions = new List<ExpenseData>(); 

        public ProcessContext(ExpenseData expense)
        {
            this.expense = expense;
        }

        public void AdditionalExpenses(ExpenseData additional)
        {
            additions.Add(additional);
        }

        public decimal GetAdditionalAmount()
        {
            return additions.Sum(data => data.Amount);
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
}