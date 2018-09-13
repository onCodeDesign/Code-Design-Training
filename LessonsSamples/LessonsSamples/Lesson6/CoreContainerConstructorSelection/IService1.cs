using System;

namespace LessonsSamples.Lesson6.CoreContainerConstructorSelection
{
    public interface IService1
    {
        string Hello();
    }

    class Service1 : IService1
    {
        public string Hello() => $"Hello from {GetType().Name}";
    }
}