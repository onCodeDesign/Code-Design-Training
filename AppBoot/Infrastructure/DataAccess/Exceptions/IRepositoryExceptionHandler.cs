using System;

namespace DataAccess.Exceptions
{
    interface IRepositoryExceptionHandler
    {
        void Handle(Exception exception);
    }
}