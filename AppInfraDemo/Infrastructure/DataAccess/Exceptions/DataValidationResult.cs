using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Exceptions
{
	[Serializable]
	public class DataValidationResult
	{
		private readonly List<ValidationError> errors;

		public DataValidationResult(IEntityEntryFacade entry, IEnumerable<ValidationError> errors)
		{
			Entry = entry;
			this.errors = errors.ToList();
		}

		public IEntityEntryFacade Entry { get; private set; }

		public IEnumerable<ValidationError> Errors
		{
			get { return errors; }
		}
	}
}