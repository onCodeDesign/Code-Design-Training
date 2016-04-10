using System;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace DataAccess.Exceptions
{
    [Serializable]
    public class DeadlockVictimRepositoryException : RepositoryException
    {
        public DeadlockVictimRepositoryException()
        {
        }

        public DeadlockVictimRepositoryException(string errorMessage)
            : base(errorMessage)
        {
        }

        public DeadlockVictimRepositoryException(SqlException exception)
            : base(exception)
        {
        }

        public DeadlockVictimRepositoryException(string message, Exception exception)
            : base(message, exception)
        {
        }

        protected DeadlockVictimRepositoryException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}