namespace LessonsSamples.Lesson6.Logger
{
	public class LogEntry
	{
		public string Headline { get; private set; }
		public string Message { get; private set; }
		public Severity Error { get; private set; }

		public LogEntry(string headline, string message, Severity error)
		{
			Headline = headline;
			Message = message;
			Error = error;
		}
	}

	public enum Severity
	{
		Error,
		Warning,
		Info,
		Trace,
		Debug
	}
}