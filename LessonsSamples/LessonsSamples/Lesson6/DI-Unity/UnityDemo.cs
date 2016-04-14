using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace LessonsSamples.Lesson6.DI_Unity
{
	static class UnityDemo
	{
		public static void MainFunc()
		{
			UnityContainer container = new UnityContainer();

			container.RegisterType<IMovieConsoleCreator, MovieConsoleCreator>();
			container.RegisterType<IMovieTransformer, MovieTransformer>();
			container.RegisterType<ITextStorage, FileStorage>(new PerResolveLifetimeManager());
			container.RegisterType<IMenu, Menu>();
			container.RegisterType<IConsoleCommand, CreateMoviesCommand>("Create Commands");
			container.RegisterType<ICreateMoviesCommand, CreateMoviesCommand>();
			container.RegisterType<IConsoleCommand, TransformMoviesCommand>("Transform Movies");

			IServiceLocator serviceLoc = new UnityServiceLocator(container);
			ServiceLocator.SetLocatorProvider(() => serviceLoc);


			var app = ServiceLocator.Current.GetInstance<MovieConsoleApplication>();
			app.Run();


		}
	}


	
}