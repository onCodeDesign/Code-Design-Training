using System;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace DataAccess.Exceptions
{
    [Serializable]
    public class UniqueConstraintRepositoryException : RepositoryException
    {
        public UniqueConstraintRepositoryException()
        {
        }

        public UniqueConstraintRepositoryException(string errorMessage)
            : base(errorMessage)
        {
        }

        public UniqueConstraintRepositoryException(SqlException exception)
            : base(exception)
        {
        }

        public UniqueConstraintRepositoryException(string message, Exception exception)
            : base(message, exception)
        {
        }

        protected UniqueConstraintRepositoryException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}