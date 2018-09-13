using System;

namespace LessonsSamples.Lesson6.CoreContainerConstructorSelection
{
    public interface IService2
    {
        string Hello();
    }

    class Service2 : IService2
    {
        public string Hello() => $"Hello from {GetType().Name}";
    }
}