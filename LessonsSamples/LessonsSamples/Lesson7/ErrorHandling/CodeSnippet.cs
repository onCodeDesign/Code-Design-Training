using ClassLibrary1.Lesson7;

namespace LessonsSamples.Lesson7.ErrorHandling
{
    class CodeSnippet
    {
        private ExpensesReport expenseReport;

        private int Ex(Employee employee)
        {
            int m_total = 0;
            try
            {
                MealExpenses expenses = expenseReport.GetMeals(employee);
                m_total += expenses.GetTotal();
            }
            catch (MealExpensesNotFound e)
            {
                m_total += GetMealPerDiem();
            }

            return m_total;
        }

        private int GetMealPerDiem()
        {
            throw new System.NotImplementedException();
        }
    }

    class Employee
    {
    }

    class ExpensesReport
    {
        public MealExpenses GetMeals(object employee)
        {
            throw new System.NotImplementedException();
        }
    }
}