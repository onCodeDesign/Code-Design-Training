using System;

namespace LessonsSamples.Lesson7.InheritanceComposition
{
    internal interface ILogTraceParser
    {
        string GetVersion(string logTrace);
        DateTime GetTime(string logTrace);
        int GetSeverity(string logTrace);
        string GetDescription(string logTrace);
    }
}