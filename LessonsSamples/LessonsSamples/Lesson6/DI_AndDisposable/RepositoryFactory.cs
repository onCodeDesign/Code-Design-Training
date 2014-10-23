using Microsoft.Practices.ServiceLocation;

namespace LessonsSamples.Lesson6.DI_AndDisposable
{
    interface IRepositoryFactory
    {
        IRepository CreateRepository();
        IUnitOfWork CreateUnitOfWork();
    }

    class RepositoryFactory : IRepositoryFactory
    {
        public IRepository CreateRepository()
        {
            return ServiceLocator.Current.GetInstance<IRepository>();
        }

        public IUnitOfWork CreateUnitOfWork()
        {
            return ServiceLocator.Current.GetInstance<IUnitOfWork>();
        }
    }
}