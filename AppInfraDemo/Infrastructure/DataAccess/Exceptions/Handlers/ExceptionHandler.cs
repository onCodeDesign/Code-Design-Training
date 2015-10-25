using System;

namespace DataAccess.Exceptions.Handlers
{
    class ExceptionHandler : IExceptionHandler
    {
        private readonly IExceptionHandler chainHead =
            new SqlExceptionHandler(
                new ConcurrencyExceptionHandler(
                    new UpdateExceptionHandler(
                        new DbEntityValidationExceptionHandler(
                            new DefaultExceptionHandler())))
                );

        public void Handle(Exception exception)
        {
            chainHead.Handle(exception);
        }
    }
}