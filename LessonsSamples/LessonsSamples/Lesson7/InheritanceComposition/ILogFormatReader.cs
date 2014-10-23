using System;

namespace LessonsSamples.Lesson7.InheritanceComposition
{
    internal interface ILogFormatReader
    {
        string GetVersion(string logTrace);
        DateTime GetTime(string logTrace);
        int GetSeverity(string logTrace);
        string GetDescription(string logTrace);
    }
}