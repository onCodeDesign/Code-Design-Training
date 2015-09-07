using System;
using System.Data.Entity.Core;
using DataAccess.Exceptions;
using iQuarc.SystemEx;

namespace DataAccess.EfRepositoryExceptionHandler
{
    class UpdateExceptionHandler : IExceptionHandler
    {
        private readonly IExceptionHandler successor;

        public UpdateExceptionHandler(IExceptionHandler successor)
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