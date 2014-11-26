using System;
using System.Runtime.Serialization;

namespace DataAccess.Exceptions
{
    public class RepositoryViolationException : Exception
    {
        private const string ErrorMessageKey = "ErrorMessage";
        private readonly string errorMessage;

        public string ErrorMessage
        {
            get { return this.errorMessage; }
        }

        public RepositoryViolationException()
            : this(string.Empty)
        {
        }

        public RepositoryViolationException(string errorMessage)
            : base(errorMessage)
        {
            this.errorMessage = errorMessage;
        }

        public RepositoryViolationException(Exception exception)
            : base(exception.Message, exception)
        {
            this.errorMessage = exception.Message;
        }

        public RepositoryViolationException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        protected RepositoryViolationException(SerializationInfo info, StreamingContext context)
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