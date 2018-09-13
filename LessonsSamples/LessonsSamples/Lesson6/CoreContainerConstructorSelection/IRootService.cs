using System;
using System.Collections.Generic;
using LessonsSamples.Lesson6.CoreContainerLifetime;

namespace LessonsSamples.Lesson6.CoreContainerConstructorSelection
{
    public interface IRootService
    {
        IEnumerable<string> GetHellos();
    }

    public class RootService : IRootService
    {
        public IService1 Service1 { get; }
        public IService2 Service2 { get; }

        public RootService(IService1 service1)
        {
            Service1 = service1;
        }

        public RootService(IService2 service2)
        {
            Service2 = service2;
        }

        public RootService(IService1 service1, IService2 service2)
        {
            Service1 = service1;
            Service2 = service2;
        }

        public IEnumerable<string> GetHellos()
        {
            yield return $"Service1: {Service1?.Hello()}";
            yield return $"Service2: {Service2?.Hello()}";
        }
    }
}