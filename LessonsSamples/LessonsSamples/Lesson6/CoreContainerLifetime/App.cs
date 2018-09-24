using System;
using Microsoft.Extensions.DependencyInjection;

namespace LessonsSamples.Lesson6.CoreContainerLifetime
{
    public class App
    {
        private readonly IServiceProvider appServices;

        public App(IServiceProvider appServices)
        {
            this.appServices = appServices;
        }

        public void NewRequest()
        {
            using (var scope = appServices.CreateScope())
            {
                IServiceProvider requestServices = scope.ServiceProvider;

                var controller = requestServices.GetService<MyController>();
                controller.ExecuteRequest();
            }
        }
    }
}