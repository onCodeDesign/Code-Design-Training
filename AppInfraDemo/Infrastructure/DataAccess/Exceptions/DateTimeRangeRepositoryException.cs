using System;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace DataAccess.Exceptions
{
    [Serializable]
    public class DateTimeRangeRepositoryException : RepositoryException
    {
        public DateTimeRangeRepositoryException()
        {
        }

        public DateTimeRangeRepositoryException(string errorMessage)
            : base(errorMessage)
        {
        }

        public DateTimeRangeRepositoryException(SqlException exception)
            : base(exception)
        {
        }

        public DateTimeRangeRepositoryException(string message, Exception exception)
            : base(message, exception)
        {
        }

        protected DateTimeRangeRepositoryException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}