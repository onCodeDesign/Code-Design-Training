namespace LessonsSamples.Lesson6
{
    public interface IConsoleCommand
    {
        void Execute();
        char KeyChar { get; }
        string MenuEntry { get; }
    }
}