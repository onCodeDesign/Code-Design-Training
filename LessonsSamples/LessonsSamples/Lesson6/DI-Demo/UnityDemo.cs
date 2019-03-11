using CommonServiceLocator;
using Unity;
using Unity.Lifetime;
using Unity.ServiceLocation;

namespace LessonsSamples.Lesson6
{
	static class UnityDemo
	{
		public static void MainFunc()
		{
			UnityContainer container = new UnityContainer();
		    IServiceLocator serviceLocator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() =>serviceLocator );

		    container.RegisterInstance(serviceLocator);

            container.RegisterType<IConsoleCommand, MovieConsoleCreator>(nameof(MovieConsoleCreator));
			container.RegisterType<IConsoleCommand, MovieTranslator>(nameof(MovieTranslator));
		    container.RegisterType<IEntityReader, EntityReader>();
            container.RegisterType<IEntityFieldsReader<Movie>, MovieFieldsReader>();
		    container.RegisterType<IConsole, AppConsole>();


			// Demo the difference between PerResolveLifetimeManager and TransientLifetimeManager
			container.RegisterType<ITextStorage, FileStorage>(new PerResolveLifetimeManager()); 


			var app = container.Resolve<MovieConsoleApplication>();
			app.Run();
		}
	}
}