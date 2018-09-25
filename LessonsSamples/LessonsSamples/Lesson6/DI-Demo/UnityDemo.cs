using Unity;
using Unity.Lifetime;

namespace LessonsSamples.Lesson6
{
	static class UnityDemo
	{
		public static void MainFunc()
		{
			UnityContainer container = new UnityContainer();

			//container.RegisterType<IMovieConsoleCreator, MovieConsoleCreator>();
			//container.RegisterType<IMovieTranslator, MovieTranslator>();

			// Demo the difference between PerResolveLifetimeManager and TransientLifetimeManager
			container.RegisterType<ITextStorage, FileStorage>(new TransientLifetimeManager()); 


			var app = container.Resolve<MovieConsoleApplication>();
			app.Run();
		}
	}
}