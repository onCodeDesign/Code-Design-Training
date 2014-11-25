using System;
using System.Data.SqlClient;
using System.Runtime.Serialization;

namespace DataAccess.Exceptions
{
    [Serializable]
    public class DeadlockVictimRepositoryViolationException : RepositoryViolationException
    {
        public DeadlockVictimRepositoryViolationException()
        {
        }

        public DeadlockVictimRepositoryViolationException(string errorMessage)
            : base(errorMessage)
        {
        }

        public DeadlockVictimRepositoryViolationException(SqlException exception)
            : base(exception)
        {
        }

        public DeadlockVictimRepositoryViolationException(string message, Exception exception)
            : base(message, exception)
        {
        }

        protected DeadlockVictimRepositoryViolationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}