using iQuarc.DataAccess;

namespace LessonsSamples.Lesson8.AuditLog
{
    public abstract class EntityInterceptor<T> : IEntityInterceptor<T> where T : class
    {
        public virtual void OnLoad(IEntityEntry<T> entry, IRepository repository)
        {
        }

        public virtual void OnSave(IEntityEntry<T> entry, IUnitOfWork unitOfWork)
        {
        }

        public virtual void OnDelete(IEntityEntry<T> entry, IUnitOfWork unitOfWork)
        {
        }

        public void OnLoad(IEntityEntry entry, IRepository repository)
        {
            OnLoad(entry.Convert<T>(), repository);
        }

        public void OnDelete(IEntityEntry entry, IUnitOfWork unitOfWork)
        {
            OnDelete(entry.Convert<T>(), unitOfWork);
        }

        public void OnSave(IEntityEntry entry, IUnitOfWork unitOfWork)
        {
            OnSave(entry.Convert<T>(), unitOfWork);
        }
    }
}