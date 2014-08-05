using System;

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