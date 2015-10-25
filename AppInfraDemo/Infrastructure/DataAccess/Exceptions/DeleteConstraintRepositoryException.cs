using System;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace DataAccess.Exceptions
{
    [Serializable]
    public class DeleteConstraintRepositoryException : RepositoryException
    {
        public DeleteConstraintRepositoryException()
        {
        }

        public DeleteConstraintRepositoryException(string errorMessage)
            : base(errorMessage)
        {
        }

        public DeleteConstraintRepositoryException(SqlException exception)
            : base(exception)
        {
        }

        public DeleteConstraintRepositoryException(string message, Exception exception)
            : base(message, exception)
        {
        }

        protected DeleteConstraintRepositoryException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}