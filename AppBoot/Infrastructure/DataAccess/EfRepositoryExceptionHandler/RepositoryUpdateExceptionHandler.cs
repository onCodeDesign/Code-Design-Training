using System;
using System.Data.Entity.Core;
using DataAccess.Exceptions;
using iQuarc.SystemEx;

namespace DataAccess.EfRepositoryExceptionHandler
{
    class RepositoryUpdateExceptionHandler : IRepositoryExceptionHandler
    {
        private readonly IRepositoryExceptionHandler successor;

        public RepositoryUpdateExceptionHandler(IRepositoryExceptionHandler successor)
        {
            this.successor = successor;
        }

        public void Handle(Exception exception)
        {
            var updateException = exception.FirstInner<UpdateException>();
            if (updateException != null)
            {
                throw new RepositoryUpdateException(updateException);
            }

            successor.Handle(exception);
        }
    }
}