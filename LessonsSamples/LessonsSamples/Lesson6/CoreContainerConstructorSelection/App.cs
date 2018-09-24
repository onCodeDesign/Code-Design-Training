using System;
using LessonsSamples.Lesson6.CoreContainerLifetime;
using Microsoft.Extensions.DependencyInjection;

namespace LessonsSamples.Lesson6.CoreContainerConstructorSelection
{
    public class App
    {
        private readonly IRootService rootService;

        public App(IRootService rootService)
        {
            this.rootService = rootService;
        }

        public void Hello()
        {
            foreach (var hello in rootService.GetHellos())
            {
                Console.WriteLine(hello);
            }
        }
    }
}