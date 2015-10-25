using System;

namespace DataAccess.Exceptions.Handlers
{
    class DefaultExceptionHandler : IExceptionHandler
    {
        public void Handle(Exception exception)
        {
            throw new RepositoryException(exception);
        }
    }
}