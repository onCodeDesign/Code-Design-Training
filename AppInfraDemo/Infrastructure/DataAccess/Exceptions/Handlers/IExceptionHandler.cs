using System;

namespace DataAccess.Exceptions.Handlers
{
	interface IExceptionHandler
    {
        void Handle(Exception exception);
    }
}