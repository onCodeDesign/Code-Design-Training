using System;
using DataAccess.EfRepositoryExceptionHandler;

namespace DataAccess.Exceptions
{
    class DefaultExceptionHandler : IExceptionHandler
    {
        public void Handle(Exception exception)
        {
            throw new RepositoryViolationException(exception);
        }
    }
}