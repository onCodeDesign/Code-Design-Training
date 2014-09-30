using System;
using Microsoft.Practices.ServiceLocation;

namespace LessonsSamples.Lesson6.ServiceLocatorTestability
{
    public static class ServiceLocatorDoubleStorage
    {
        [ThreadStatic]
        private static IServiceLocator current;

        public static IServiceLocator Current
        {
            get { return current; }
        }

        public static void SetInstance(IServiceLocator sl)
        {
            current = sl;
        }

        public static void Cleanup()
        {
            SetInstance(null);
        }
    }
}