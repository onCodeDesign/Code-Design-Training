using System;
using System.Collections.Generic;
using System.Linq;

namespace LessonsSamples.Lesson7.InheritanceComposition
{
    sealed class LogSource_2
    {
        private readonly ILogMessageParser messageParser;
        private int messageIndex;

        public LogSource_2(ILogMessageParser messageParser)
        {
            this.messageParser = messageParser;
        }

        public IEnumerable<LogEntry> GetAllLogEntries()
        {
            IEnumerable<string> logMessages = LoadLogMessages();

            foreach (var message in logMessages)
            {
                yield return new LogEntry
                {
                    Time = messageParser.GetTime(message, messageIndex),
                    Severity = messageParser.GetSeverity(message, messageIndex),
                    Description = messageParser.GetDescription(message, messageIndex),
                    Version = messageParser.GetVersion(message, messageIndex),
                    Body = message
                };
            }
        }

        public IEnumerable<LogEntry> GetCriticalLogEntries()
        {
            return GetAllLogEntries().Where(l => l.Severity > 10);
        }

        private IEnumerable<string> LoadLogMessages()
        {
            messageIndex = 0;
            string logMessage = string.Empty;

            // This is the algorithm / code we would like to reuse.
            //    it reads the data source with the log traces and splits it in trace messages 

            // Any communication /  interaction between this code and the parsers must be explicit into the interface

            yield return logMessage;
        }
    }

    internal class XmlLogMessageParser : ILogMessageParser
    {
        public string GetVersion(string logMessage, int messageIndex)
        {
            throw new NotImplementedException();
        }

        public DateTime GetTime(string logMessage, int messageIndex)
        {
            throw new NotImplementedException();
        }

        public int GetSeverity(string logMessage, int messageIndex)
        {
            throw new NotImplementedException();
        }

        public string GetDescription(string logMessage, int messageIndex)
        {
            throw new NotImplementedException();
        }
    }

    class CsvLogMessageParser : ILogMessageParser
    {
        public string GetVersion(string logMessage, int messageIndex)
        {
            throw new NotImplementedException();
        }

        public DateTime GetTime(string logMessage, int messageIndex)
        {
            throw new NotImplementedException();
        }

        public int GetSeverity(string logMessage, int messageIndex)
        {
            throw new NotImplementedException();
        }

        public string GetDescription(string logMessage, int messageIndex)
        {
            throw new NotImplementedException();
        }
    }
}