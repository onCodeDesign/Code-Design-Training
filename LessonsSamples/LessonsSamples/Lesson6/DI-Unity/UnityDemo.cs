using Microsoft.Practices.Unity;

namespace LessonsSamples.Lesson6.DI_Unity
{
	static class UnityDemo
	{
		public static void MainFunc()
		{
			UnityContainer container = new UnityContainer();

			container.RegisterType<IMovieConsoleCreator, MovieConsoleCreator>();
			container.RegisterType<IMovieTranslator, MovieTranslator>();

			// Demo the difference between PerResolveLivetimeManager and TransientLifetimeManager
			container.RegisterType<ITextStorage, FileStorage>(new TransientLifetimeManager()); 


			var app = container.Resolve<MovieConsoleApplication>();
			app.Run();
		}
	}
}