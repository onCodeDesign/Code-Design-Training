using System;
using System.Data.Entity.Validation;
using System.Globalization;
using System.Text;
using iQuarc.SystemEx;

namespace DataAccess.Exceptions
{
    class RepositoryDbEntityValidationExceptionHandler : IRepositoryExceptionHandler
    {
        public void Handle(Exception exception)
        {
            var validationException = exception.FirstInner<DbEntityValidationException>();
            if (validationException != null)
            {
                var message = GetErrorMessage(validationException);
                throw new RepositoryViolationException(message, validationException);
            }
        }

        private static string GetErrorMessage(DbEntityValidationException validationException)
        {
            var sb = new StringBuilder();
            foreach (var entityErrors in validationException.EntityValidationErrors)
            {
                AppendLineFormat(sb, "Entity [{0}] in state {1} has the following errors: ", entityErrors.Entry.Entity.GetType().Name, entityErrors.Entry.State);
                foreach (var err in entityErrors.ValidationErrors)
                {
                    AppendLineFormat(sb,"\tPropery [{0}]: {1}", err.PropertyName, err.ErrorMessage);
                }
            }
            return sb.ToString();
        }

        private static StringBuilder AppendLineFormat(StringBuilder builder, string format, params object[] args)
        {
            return AppendLineFormat(builder, CultureInfo.InvariantCulture, format, args);
        }

        private static StringBuilder AppendLineFormat(StringBuilder builder, IFormatProvider formatProvider, string format, params object[] args)
        {
            return builder.AppendFormat(formatProvider, format, args)
                          .AppendLine();
        }
    }
}