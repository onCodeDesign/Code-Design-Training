using System;

namespace LessonsSamples.Lesson7.InheritanceComposition
{
    internal interface ILogMessageParser
    {
        string GetVersion(string logMessage, int messageIndex);
        DateTime GetTime(string logMessage, int messageIndex);
        int GetSeverity(string logMessage, int messageIndex);
        string GetDescription(string logMessage, int messageIndex);
    }
}