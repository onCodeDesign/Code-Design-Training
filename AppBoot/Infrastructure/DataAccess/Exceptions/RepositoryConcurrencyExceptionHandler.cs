using System;
using System.Data.Entity.Core;
using iQuarc.SystemEx;

namespace DataAccess.Exceptions
{
    class RepositoryConcurrencyExceptionHandler : IRepositoryExceptionHandler
    {
        public void Handle(Exception exception)
        {
            var concurrencyException = exception.FirstInner<OptimisticConcurrencyException>();
            if (concurrencyException != null)
            {
                throw new ConcurrencyRepositoryViolationException(concurrencyException);
            }
        }
    }
}