namespace LessonsSamples.Lesson7.CohesionCoupling
{
    public interface IPageFileWriter
    {
        bool WriteFile(PageXml page, string filePrefix);
    }

    public interface IPageWriter
    {
        bool Write(PageXml page);
    }

    public  static class PageFileWriterExtensions
{
        public static bool WriteFile(this IPageFileWriter writer, PageXml page)
        {
            return writer.WriteFile(page, string.Empty);
        }
}
}