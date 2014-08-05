using System;
using System.Data.Entity.Core;
using iQuarc.SystemEx;

namespace DataAccess.Exceptions
{
    class RepositoryUpdateExceptionHandler : IRepositoryExceptionHandler
    {
        public void Handle(Exception exception)
        {
            var updateException = exception.FirstInner<UpdateException>();
            if (updateException != null)
            {
                throw new RepositoryUpdateException(updateException);
            }
        }
    }
}