namespace LessonsSamples.Lesson6.Expenses
{
    interface IExpensesService
    {
	    void Process(ExpenseData expense);
	    void Approve(ExpenseData expense);
    }
}