using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using iQuarc.SystemEx;

namespace DataAccess.Exceptions.Handlers
{
    class DbEntityValidationExceptionHandler : IExceptionHandler
    {
        private readonly IExceptionHandler successor;

        public DbEntityValidationExceptionHandler(IExceptionHandler successor)
        {
            this.successor = successor;
        }

        public void Handle(Exception exception)
        {
            var validationException = exception.FirstInner<DbEntityValidationException>();
            if (validationException != null)
            {
                IEnumerable<DataValidationResult> errors = GetErrors(validationException);
                throw new DataValidationException(validationException.Message, errors, validationException);
            }

            successor.Handle(exception);
        }

        private IEnumerable<DataValidationResult> GetErrors(DbEntityValidationException validationException)
        {
            foreach (var dbEntityValidationResult in validationException.EntityValidationErrors)
            {
                IEntityEntryFacade entry = new EntityEntry(dbEntityValidationResult.Entry);
                IEnumerable<ValidationError> entryErrors = GetEntryErrors(dbEntityValidationResult.ValidationErrors);
                yield return new DataValidationResult(entry, entryErrors);
            }
        }

        private IEnumerable<ValidationError> GetEntryErrors(IEnumerable<DbValidationError> validationErrors)
        {
            foreach (var dbValidationError in validationErrors)
            {
                yield return new ValidationError(dbValidationError.PropertyName, dbValidationError.ErrorMessage);
            }
        }
    }
}