using System;
using System.Runtime.Serialization;

namespace DataAccess.Exceptions
{
    public class RepositoryException : Exception
    {
        private const string ErrorMessageKey = "ErrorMessage";
        private readonly string errorMessage;

        public string ErrorMessage
        {
            get { return this.errorMessage; }
        }

        public RepositoryException()
            : this(string.Empty)
        {
        }

        public RepositoryException(string errorMessage)
            : base(errorMessage)
        {
            this.errorMessage = errorMessage;
        }

        public RepositoryException(Exception exception)
            : base(exception.Message, exception)
        {
            this.errorMessage = exception.Message;
        }

        public RepositoryException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected RepositoryException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.errorMessage = info.GetString(ErrorMessageKey);
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(ErrorMessageKey, this.errorMessage, typeof(string));
        }
    }
}