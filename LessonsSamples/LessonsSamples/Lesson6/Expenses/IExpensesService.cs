namespace LessonsSamples.Lesson6
{
    interface IExpensesService
    {
        void Approve(ExpenseData expense);
        void Process(ExpenseData expense);
    }
}