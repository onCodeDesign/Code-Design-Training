namespace LessonsSamples.Lesson6
{
    interface IEntityReader
    {
        IEntityFieldsReader<T> BeginEntityRead<T>();
    }

    class EntityReader : IEntityReader
    {
        public IEntityFieldsReader<T> BeginEntityRead<T>()
        {
            throw new System.NotImplementedException();
        }
    }
}