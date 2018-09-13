using System;
using Microsoft.Extensions.DependencyInjection;

namespace LessonsSamples.Lesson6.CoreContainerConstructorSelection
{
    public static class NetCoreConstructorSelectionDemo
    {
        public static void MainFunc()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            ServiceProvider serviceProvider = services.BuildServiceProvider();

            var app = serviceProvider.GetService<App>();
            app.Hello();
        }

        private static void ConfigureServices(ServiceCollection services)
        {
            services.AddTransient<IRootService, RootService>();
            services.AddTransient<IService1, Service1>();
            services.AddTransient<IService2, Service2>();

            services.AddTransient<App>();
        }
    }
}