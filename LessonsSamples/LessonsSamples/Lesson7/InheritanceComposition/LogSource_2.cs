using System;
using System.Collections.Generic;
using System.Linq;

namespace LessonsSamples.Lesson7.InheritanceComposition
{
    sealed class LogSource_2
    {
        private readonly ILogTraceParser traceParser;

        public LogSource_2(ILogTraceParser traceParser)
        {
            this.traceParser = traceParser;
        }

        public IEnumerable<LogEntry> GetAllLogEntries()
        {
            IEnumerable<string> logTraces = LoadAllLogEntires();

            foreach (var logTrace in logTraces)
            {
                yield return new LogEntry
                {
                    Time = traceParser.GetTime(logTrace),
                    Severity = traceParser.GetSeverity(logTrace),
                    Description = traceParser.GetDescription(logTrace),
                    Version = traceParser.GetVersion(logTrace),
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

    internal class XmlLogTraceParser : ILogTraceParser
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

    class CsvLogTraceParser : ILogTraceParser
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