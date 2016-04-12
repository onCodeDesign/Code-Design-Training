namespace LessonsSamples.Lesson6
{
    interface IExpensesService
    {
	    void Process(ExpenseData expense);
	    void Approve(ExpenseData expense);
    }
}