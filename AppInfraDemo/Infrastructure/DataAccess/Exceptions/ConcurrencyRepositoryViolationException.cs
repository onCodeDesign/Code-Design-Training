using System;
using System.Data.Entity.Core;
using System.Linq;
using System.Runtime.Serialization;

namespace DataAccess.Exceptions
{
    [Serializable]
    public class ConcurrencyRepositoryViolationException : RepositoryViolationException
    {
        private const string RepositoryEntityKey = "RepositoryEntity";
        public IAuditable RepositoryEntity { get; set; }

        public ConcurrencyRepositoryViolationException()
        {
        }

        public ConcurrencyRepositoryViolationException(string errorMessage)
            : base(errorMessage)
        {
        }

        public ConcurrencyRepositoryViolationException(UpdateException exception)
            : base(exception)
        {
            var auditable = exception.StateEntries.FirstOrDefault(e => e.Entity is IAuditable);
            if (auditable != null)
            {
                this.RepositoryEntity = auditable.Entity as IAuditable;
            }
        }

        public ConcurrencyRepositoryViolationException(string message, Exception exception)
            : base(message, exception)
        {
        }


        protected ConcurrencyRepositoryViolationException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.RepositoryEntity = (IAuditable)info.GetValue(RepositoryEntityKey, typeof(IAuditable));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(RepositoryEntityKey, this.RepositoryEntity, typeof(string));
        }
    }
}