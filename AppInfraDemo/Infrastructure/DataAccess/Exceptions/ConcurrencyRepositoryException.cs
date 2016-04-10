using System;
using System.Data.Entity.Core;
using System.Linq;
using System.Runtime.Serialization;

namespace DataAccess.Exceptions
{
    [Serializable]
    public class ConcurrencyRepositoryException : RepositoryException
    {
        private const string RepositoryEntityKey = "Entity";
        public object Entity { get; set; }

        public ConcurrencyRepositoryException()
        {
        }

        public ConcurrencyRepositoryException(string errorMessage)
            : base(errorMessage)
        {
        }

        public ConcurrencyRepositoryException(UpdateException exception)
            : this(string.Empty, exception)
        {
        }

        public ConcurrencyRepositoryException(string message, UpdateException exception)
            : base(message, exception)
        {
            if (exception.StateEntries != null)
            {
                var entry = exception.StateEntries.FirstOrDefault();
                if (entry != null)
                    this.Entity = entry.Entity;
            }
        }


        protected ConcurrencyRepositoryException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            this.Entity = info.GetValue(RepositoryEntityKey, typeof (object));
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue(RepositoryEntityKey, this.Entity, typeof (string));
        }
    }
}