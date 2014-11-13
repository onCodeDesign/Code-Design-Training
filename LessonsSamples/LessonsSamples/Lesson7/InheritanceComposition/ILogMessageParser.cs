using System;

namespace LessonsSamples.Lesson7.InheritanceComposition
{
    internal interface ILogMessageParser
    {
        string GetVersion(string logMessage);
        DateTime GetTime(string logMessage);
        int GetSeverity(string logMessage);
        string GetDescription(string logMessage);
    }
}