using System;
using System.Collections.Generic;
using System.Linq;

namespace LessonsSamples.Lesson7.InheritanceComposition
{
    abstract class LogSource
    {
        protected int messageIndex;

        public IEnumerable<LogEntry> GetAllLogEntries()
        {
            IEnumerable<string> logMessages = LoadLogMessages();

            foreach (var message in logMessages)
            {
                yield return new LogEntry
                {
                    Time = GetTime(message),
                    Severity = GetSeverity(message),
                    Description = GetDescription(message),
                    Version = GetVersion(message),
                    Body = message
                };
            }
        }

        private IEnumerable<string> LoadLogMessages()
        {
            messageIndex = 0;
            string logMessage = string.Empty;

            // This is the algorithm / code we would like to reuse.
            //    it reads the data source with the log traces and splits it in trace messages 
            
            // Base class may put here, or in GetAllLogEntries(), some data into some protected fields to make them available to the inheritors
            messageIndex++;

            yield return logMessage;
        }

        protected abstract string GetVersion(string logMessage);
        protected abstract DateTime GetTime(string logMessage);
        protected abstract string GetDescription(string logMessage);
        protected abstract int GetSeverity(string logMessage);

        public IEnumerable<LogEntry> GetCriticalLogEntries()
        {
            return GetAllLogEntries().Where(l => l.Severity > 10);
        }
    }


    class XmlLogSource : LogSource
    {
        protected override string GetVersion(string logMessage)
        {
            int index = messageIndex;
            throw new NotImplementedException();
        }

        protected override DateTime GetTime(string logMessage)
        {
            int index = messageIndex;
            throw new NotImplementedException();
        }

        protected override string GetDescription(string logMessage)
        {
            int index = messageIndex;
            throw new NotImplementedException();
        }

        protected override int GetSeverity(string logMessage)
        {
            int index = messageIndex;
            throw new NotImplementedException();
        }
    }

    class CsvLogSource : LogSource
    {
        protected override string GetVersion(string logMessage)
        {
            int index = messageIndex;
            throw new NotImplementedException();
        }

        protected override DateTime GetTime(string logMessage)
        {
            int index = messageIndex;
            throw new NotImplementedException();
        }

        protected override string GetDescription(string logMessage)
        {
            int index = messageIndex;
            throw new NotImplementedException();
        }

        protected override int GetSeverity(string logMessage)
        {
            int index = messageIndex;
            throw new NotImplementedException();
        }
    }
}