namespace LessonsSamples.Lesson8.AuditLog
{
    internal interface IAuditLog
    {
        void Write(AuditType read, string empty, User user);
    }
}