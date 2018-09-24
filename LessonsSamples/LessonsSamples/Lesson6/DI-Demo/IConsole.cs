namespace LessonsSamples.Lesson6
{
    internal interface IConsole
    {
        string AskInput(string message);
        void WriteEntity<T>(T salesOrderInfo);
        void WriteLine(string line);
    }
}