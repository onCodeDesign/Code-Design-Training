using System;
using DataAccess.EfRepositoryExceptionHandler;

namespace DataAccess.Exceptions
{
    class RepositoryDefaultExceptionHandler : IRepositoryExceptionHandler
    {
        public void Handle(Exception exception)
        {
            throw new RepositoryViolationException(exception);
        }
    }
}