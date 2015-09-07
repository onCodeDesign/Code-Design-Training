using System;

namespace DataAccess.EfRepositoryExceptionHandler
{
    public interface IExceptionHandler
    {
        void Handle(Exception exception);
    }
}