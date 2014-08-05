using System;
using System.Data.SqlClient;
using iQuarc.SystemEx;

namespace DataAccess.Exceptions
{
    class RepositorySqlExceptionHandler : IRepositoryExceptionHandler
    {
        public void Handle(Exception exception)
        {
            var sqlException = exception.FirstInner<SqlException>();
            if (sqlException != null)
            {
                switch (sqlException.Number)
                {
                    case 242:
                        throw new DateTimeRangeRepositoryViolationException(sqlException);
                    case 547:
                        throw new DeleteConstraintRepositoryViolationException(sqlException);
                    case 1205:
                        throw new DeadlockVictimRepositoryViolationException(sqlException);
                    case 2601:
                    case 2627:
                        throw new UniqueConstraintRepositoryViolationException(sqlException);
                    default:
                        throw new RepositoryViolationException(sqlException);
                }
            }
        }
    }
}