using System;

namespace LessonsSamples.Lesson7.InheritanceComposition
{
    class LogEntry
    {
        public DateTime Time { get; set; }
        public int Severity { get; set; }
        public string Version { get; set; }
        public string Description { get; set; }
        public string Body { get; set; }
    }
}