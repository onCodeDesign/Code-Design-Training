namespace LessonsSamples.Lesson6
{
    interface IEntityReader
    {
        IEntityFieldsReader<T> BeginEntityRead<T>();
    }
}