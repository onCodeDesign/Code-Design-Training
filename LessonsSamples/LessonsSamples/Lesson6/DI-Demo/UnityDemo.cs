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
		    ConfigureServiceLocator(container);

			container.RegisterType<ICommand, MovieConsoleCreator>(nameof(MovieConsoleCreator));
			container.RegisterType<ICommand, MovieTranslator>(nameof(MovieTranslator));
		    container.RegisterType<IConsole, AppConsole>();

		    container.RegisterType<IEntityReader, EntityReader>();
		    container.RegisterType<IEntityFieldsReader<Movie>, MovieFieldsReader>();
		    container.RegisterType(typeof(IEntityFieldsReader<>), typeof(GenericFieldsReader<>));

		    container.RegisterType<IEntityRepository, InMemoryFileRepository>();


		    // Demo the difference between PerResolveLifetimeManager and TransientLifetimeManager
			container.RegisterType<ITextStorage, FileStorage>(new PerResolveLifetimeManager()); 

			var app = container.Resolve<MovieConsoleApplication>();
			app.Run();
		}

	    private static void ConfigureServiceLocator(IUnityContainer container)
	    {
	        var serviceLocator = new UnityServiceLocator(container);
            ServiceLocator.SetLocatorProvider(() => serviceLocator);
	    }
	}
}