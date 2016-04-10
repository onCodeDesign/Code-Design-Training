using System;
using System.Data.Entity.Core;
using iQuarc.SystemEx;

namespace DataAccess.Exceptions.Handlers
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