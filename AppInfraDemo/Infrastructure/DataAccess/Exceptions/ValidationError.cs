using System;

namespace DataAccess.Exceptions
{
	[Serializable]
	public class ValidationError
	{
		public ValidationError(string propertyName, string errorMessage)
		{
			PropertyName = propertyName;
			ErrorMessage = errorMessage;
		}

		public string PropertyName { get; private set; }
		public string ErrorMessage { get; private set; }
	}
}