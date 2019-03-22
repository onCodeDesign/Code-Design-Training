using CommonServiceLocator;

namespace LessonsSamples.Lesson6
{
    interface IEntityReader
    {
        IEntityFieldsReader<T> BeginEntityRead<T>();
    }

    class EntityReader : IEntityReader
    {
        private readonly IServiceLocator serviceLocator;

        public EntityReader(IServiceLocator serviceLocator)
        {
            this.serviceLocator = serviceLocator;
        }

        public IEntityFieldsReader<T> BeginEntityRead<T>()
        {
            return serviceLocator.GetInstance<IEntityFieldsReader<T>>();
        }
    }
}