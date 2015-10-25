using System;
using System.Data.SqlClient;
using iQuarc.SystemEx;

namespace DataAccess.Exceptions.Handlers
{
    class SqlExceptionHandler : IExceptionHandler
    {
        private readonly IExceptionHandler successor;

        public SqlExceptionHandler(IExceptionHandler successor)
        {
            this.successor = successor;
        }

        public void Handle(Exception exception)
        {
            var sqlException = exception.FirstInner<SqlException>();
            if (sqlException != null)
            {
                switch (sqlException.Number)
                {
                    case 242:
                        throw new DateTimeRangeRepositoryException(sqlException);
                    case 547:
                        throw new DeleteConstraintRepositoryException(sqlException);
                    case 1205:
                        throw new DeadlockVictimRepositoryException(sqlException);
                    case 2601:
                    case 2627:
                        throw new UniqueConstraintRepositoryException(sqlException);
                    default:
                        throw new RepositoryException(sqlException);
                }
            }

            successor.Handle(exception);
        }
    }
}