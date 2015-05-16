namespace LessonsSamples.Lesson7.CohesionCoupling
{
	public interface IPageFileWriter
	{
		bool WriteFile(PageXml page, string fileType);
	}

	public static class PageFileWriterExtensions
	{
		public static bool WriteFile(this IPageFileWriter writer, PageXml page)
		{
			return writer.WriteFile(page, string.Empty);
		}
	}
}