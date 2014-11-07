using System;
using System.Collections.Generic;
using System.Linq;

namespace LessonsSamples.Lesson7.InheritanceComposition
{
    abstract class LogSource
    {
        protected abstract string GetVersion(string logTrace);
        protected abstract DateTime GetTime(string logTrace);
        protected abstract string GetDescription(string logTrace);
        protected abstract int GetSeverity(string logTrace);

        public IEnumerable<LogEntry> GetAllLogEntries()
        {
            IEnumerable<string> logTraces = LoadAllLogEntires();

            foreach (var logTrace in logTraces)
            {
                yield return new LogEntry
                {
                    Time = GetTime(logTrace),
                    Severity = GetSeverity(logTrace),
                    Description = GetDescription(logTrace),
                    Version = GetVersion(logTrace),
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
            // base class may put here, or in GetAllLogEntries, some data into some protected fields to make them available to the inheritors

            throw new NotImplementedException();
        }
    }


    class XmlLogSource : LogSource
    {
        protected override string GetVersion(string logTrace)
        {
            throw new NotImplementedException();
        }

        protected override DateTime GetTime(string logTrace)
        {
            throw new NotImplementedException();
        }

        protected override string GetDescription(string logTrace)
        {
            throw new NotImplementedException();
        }

        protected override int GetSeverity(string logTrace)
        {
            throw new NotImplementedException();
        }
    }

    class CsvLogSource : LogSource
    {
        protected override string GetVersion(string logTrace)
        {
            throw new NotImplementedException();
        }

        protected override DateTime GetTime(string logTrace)
        {
            throw new NotImplementedException();
        }

        protected override string GetDescription(string logTrace)
        {
            throw new NotImplementedException();
        }

        protected override int GetSeverity(string logTrace)
        {
            throw new NotImplementedException();
        }
    }
}