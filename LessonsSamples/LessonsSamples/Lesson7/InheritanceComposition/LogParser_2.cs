using System;
using System.Collections.Generic;
using System.Linq;

namespace LessonsSamples.Lesson7.InheritanceComposition
{
    sealed class LogParser_2
    {
        private readonly ILogFormatReader formatReader;

        public LogParser_2(ILogFormatReader formatReader)
        {
            this.formatReader = formatReader;
        }

        public IEnumerable<LogEntry> GetAllLogEntries()
        {
            IEnumerable<string> logTraces = LoadAllLogEntires();

            foreach (var logTrace in logTraces)
            {
                yield return new LogEntry
                {
                    Time = formatReader.GetTime(logTrace),
                    Severity = formatReader.GetSeverity(logTrace),
                    Description = formatReader.GetDescription(logTrace),
                    Version = formatReader.GetVersion(logTrace),
                    Body = logTrace
                };
            }
        }

        public IEnumerable<LogEntry> GetCriticalLogEntries()
        {
            return GetAllLogEntries().Where(l => l.Severity > 10);
        }

        private IEnumerable<string> LoadAllLogEntires()
        {
            // this is the algorithm / code we would like to reuse
            // any communication /  interaction between this code and the format readers must be explicit into the interface

            throw new NotImplementedException();
        }
    }

    internal class XmlReader : ILogFormatReader
    {
        public string GetVersion(string logTrace)
        {
            throw new NotImplementedException();
        }

        public DateTime GetTime(string logTrace)
        {
            throw new NotImplementedException();
        }

        public int GetSeverity(string logTrace)
        {
            throw new NotImplementedException();
        }

        public string GetDescription(string logTrace)
        {
            throw new NotImplementedException();
        }
    }

    class CsvReader : ILogFormatReader
    {
        public string GetVersion(string logTrace)
        {
            throw new NotImplementedException();
        }

        public DateTime GetTime(string logTrace)
        {
            throw new NotImplementedException();
        }

        public int GetSeverity(string logTrace)
        {
            throw new NotImplementedException();
        }

        public string GetDescription(string logTrace)
        {
            throw new NotImplementedException();
        }
    }
}