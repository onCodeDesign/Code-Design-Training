using System;
using Microsoft.Extensions.DependencyInjection;

namespace LessonsSamples.Lesson6.CoreContainerLifetime
{
    public static class NetCoreLifetimeDemo
    {
        public static void MainFunc()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            var app = serviceProvider.GetService<App>();

            Console.WriteLine("First Request");
            app.NewRequest();

            Console.WriteLine();
            Console.WriteLine("-------------------------------");
            Console.WriteLine("Second Request");
            app.NewRequest();
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<IOperationTransient, Operation>();
            services.AddScoped<IOperationScoped, Operation>();
            services.AddSingleton<IOperationSingleton, Operation>();
            services.AddSingleton<IOperationSingletonInstance>(new Operation(Guid.NewGuid()));

            services.AddTransient<IService, Service>();
            services.AddTransient<MyController, MyController>();
            services.AddTransient<App, App>();
        }
    }
}